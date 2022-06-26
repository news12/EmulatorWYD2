using Service.Interface;
using Db.Entities;
using Application.Config;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using Service.Service;
using Application.Class;

namespace Application.Controller
{
    public class AccountController
    {
        protected readonly IAccountService _accountService;
        protected readonly ICharacterService _characterService;
        protected readonly IBotTelegram _botTelegramService;

        //constructor

        public AccountController(IAccountService accountService) => _accountService = accountService;
        public AccountController(ICharacterService characterService) => _characterService = characterService;
        public AccountController(IBotTelegram botTelegramService) => _botTelegramService = botTelegramService;

        public AccountController()
        {
            _accountService = new AccountService();
            _characterService = new CharacterService();
            _botTelegramService = new BotTelegramService();
        }

        public void Update(Account accout, string data)
        {
            _accountService.Update(accout, data);
        }

        public void UpdateDonate(DonateGame donate, string data)
        {
            _accountService.UpdateDonate(donate, data);
        }

        public void UpdatePass(PassGame pass, string data)
        {
            _accountService.UpdatePassword(pass, data);
        }

        public void UpdateAll()
        {
            _accountService.UpdateAll();
        }

        public Account GetAccount(string name)
        {
            return _accountService.Get(name);
        }

        public List<Character> GetAllCharater()
        {
            return _characterService.GetAll();
        }

        public List<BotDonate> GetListBotDonateNotSend()
        {
            return _botTelegramService.GetListStatus(0);
        }

        public List<BotDonate> GetAllBotDonate()
        {
            return _botTelegramService.GetAll();
        }

        public void CreateCharater(Character Data)
        {
            _characterService.Create(Data);
        }

        public void CreateDonate(DonateGame Data)
        {
            _accountService.CreateDonate(Data);
        }

        public void UpdateCharater(Character Data)
        {
            if (Data.User_Id == 0 || Data.Game_id == 0)
                return;

            _characterService.Update(Data);
        }

        public void GetDonations(int status)
        {
            List<Account> accounts = _accountService.GetAccounts(1);
         
            if (accounts != null)
            {
                foreach (var account in accounts)
                {
                    if (account.Status == 1)
                    {
                        try
                        {
                            List<DonateGame> donations = _accountService.GetDonations(account.Id, status);
                            foreach (var donation in donations)
                            {
                                if (donation.Status == 0)
                                {
                                    if (ImportDonate(account.Name, donation.Donate))
                                    {
                                        donation.Status = 1;

                                        UpdateDonate(donation, "Status");

                                        Log.LogUser.Info($"Account({account.Name}) msg({donation.Donate} Donate - {Cfg.LangXml.ImportedFromGame})");
                                    }
                                    else
                                        Log.LogUser.Info($"Account({account.Name}) msg(Importação(Donate) anterior pendente no emulador-{Cfg.LangXml.ImportFail})");
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Log.LogUser.Error($"Account({account.Name}) msg(Donate-{Cfg.LangXml.ImportFail})");
                            throw;
                        }


                    }
                }
            }
        }

        public void GetPasswords(int status)
        {
            List<Account> accounts = _accountService.GetAccounts(1);

            if (accounts != null)
            {
                foreach (var account in accounts)
                {
                    if (account.Status == 1)
                    {
                        try
                        {
                            List<PassGame> passwords = _accountService.GetPasswords(account.Id, status);
                            foreach (var password in passwords)
                            {
                                if (password.Status == 0)
                                {
                                    if (ImportPass(account.Name, password.Password, password.Numeric))
                                    {
                                        password.Status = 1;

                                        UpdatePass(password, "Status");

                                        Log.LogUser.Info($"Account({account.Name}) msg({password.Password} Senha/Numeric - {Cfg.LangXml.ImportedFromGame})");
                                    }
                                    else
                                        Log.LogUser.Info($"Account({account.Name}) msg(Importação(Senha) anterior pendente no emulador-{Cfg.LangXml.ImportFail})");
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Log.LogUser.Error($"Account({account.Name}) msg(Senha-{Cfg.LangXml.ImportFail})");
                            throw;
                        }


                    }
                }
            }
        }

        public void GetPlayers()
        {
            GetXmlPlayer();
            List<Character> Charaters = GetAllCharater();

            //varre a lista de players vindo do xml
            foreach (var player in Cfg.Players)
            {
                bool isUpdate = false;
                if (Charaters.Count > 0)//se tiver retorno de dados do banco
                {
                    foreach (var character in Charaters)//varre a lista de character vindas do banco
                    {
                        //compara se o player vindo do xml já tem no banco
                        if (player.Name.ToLower().Equals(character.Name.ToLower()))
                        {
                            //atualiza o character com a info vinda do xml
                            UpdateCharater(ConvertToCharater(player, character.Id));
                            isUpdate = true;
                            break;
                        }
                    }

                }

                if (!isUpdate)
                    CreateCharater(ConvertToCharater(player));

            }


        }

        private Character ConvertToCharater(Player p, int id = 0)
        {
            Account acc = GetAccount(p.UserName.ToLower());

            Character character = new()
            {
                User_Id = acc != null ? acc.User_Id : 0,
                Game_id = acc != null ? acc.Id : 0,
                Name = p.Name.ToLower(),
                UserName = p.UserName.ToLower(),
                Fame = p.Fame,
                CapeInfo = p.CapeInfo,
                GuildIndex = p.GuildIndex,
                ClassInfo = p.ClassInfo,
                Exp = p.Exp,
                Level = p.Level,
                GuildMemberType = p.GuildMemberType,
                Evo = p.Evo
            };

            if (id > 0)
                character.SetId(id);

            return character;
        }

        private void GetXmlPlayer()
        {
            if (!Directory.Exists(Cfg.ConfigXml.ImportCharacter))
                Directory.CreateDirectory(Cfg.ConfigXml.ImportCharacter);

            DirectoryInfo dirInfo = new(Cfg.ConfigXml.ImportCharacter);
            XmlSerializer serialize = new(typeof(Player));

            Cfg.Players.Clear();

            foreach (FileInfo file in dirInfo.GetFiles("*.xml"))
            {
                string str = File.ReadAllText(file.FullName);

                using StringReader reader = new(str);
                Cfg.Players.Add(serialize.Deserialize(reader) as Player);

            }
        }

        public void GetAcccounts(int status)
        {
            List<Account> accounts = _accountService.GetAccounts(status);
            if (accounts != null)
            {
                foreach (var account in accounts)
                {
                    if (account.Status == 0)
                    {
                        try
                        {
                          ImportUser(account.Name, PasswordDecrypt(account.Password));
                            account.Status = 1;

                            Update(account, "Status");

                            Log.LogUser.Info($"Account({account.Name}) msg({Cfg.LangXml.ImportedFromGame})");
                        }
                        catch (Exception)
                        {
                            Log.LogUser.Error($"Account({account.Name}) msg({Cfg.LangXml.ImportFail})");
                            throw;
                        }
                       

                    }
                }
            }
        }

       private static void ImportUser(string name, string pass)
        {
            string path = Cfg.ConfigXml.ImportUser + name + ".txt";
            string import = name + " " + pass + " 0"; 
             File.WriteAllTextAsync(path, import);
        }

        private static  bool ImportDonate(string name, int donate)
        {
            string path = Cfg.ConfigXml.ImportDonate + name + ".txt";
            string import = name + " " + donate.ToString();
            if (!File.Exists(path))
            { 
                File.WriteAllText(path, import); 
                return true; 
            }

            return false;
        }

        private static bool ImportPass(string name, string pass, string num)
        {
            string passDec = PasswordDecrypt(pass);
            string path = Cfg.ConfigXml.ImportPass + name + ".txt";
            string import = name + " " + passDec + " " + num;
            if (!File.Exists(path))
            {
                File.WriteAllText(path, import);
                return true;
            }

            return false;
        }

        public bool ImportNotice(string notice)
        {
            int count = 0;
            string[] fileEntries = Directory.GetFiles(Cfg.ConfigXml.ImportNotice);

            count = fileEntries.Length;

            count++;
            string path = Cfg.ConfigXml.ImportNotice + count + ".txt";
            string import = notice;
         
            File.WriteAllText(path, import);
            return true;
        }

        private static string PasswordDecrypt(string password)
        {
            string secret = "PAUNOFURICODOABNER";
            string pass = password;

            SHA256 mySHA256 = SHA256.Create();
            byte[] key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(secret));

            // Create secret IV
            byte[] iv = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            Encrypt enc = new();

            string decrypted = enc.DecryptString(pass, key, iv);

            return decrypted;
        }
    }

}
