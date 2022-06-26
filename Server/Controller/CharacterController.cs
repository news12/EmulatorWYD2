using Db.Entities;
using Application.Config;
using Application.Packet;
using Service.Interface;
using Services.Service;
using Application.Enum;

namespace Application.Controller
{
    public class CharacterController
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService) => _characterService = characterService;

        public CharacterController()
        {
            _characterService = new CharacterService();
        }

        public Character Create(ClientSession client, MsgServerCharacterCreate data)
        {
            Character character = new();
            character.AccountId = client.GetAccount().Id;
            character.Affect = new List<CharacterAffect> { };

            for (int i = 0; i < Cfg.MaxAffect; i++)
                character.Affect.Add(CharacterAffect.New());

            character.LastPosition = new CharacterLastPosition { };

            character.LastPosition.X = (short)Cfg.ClassBase[data.Class].PosX;
            character.LastPosition.Y = (short)Cfg.ClassBase[data.Class].PosY;

            character.AffectInfo = 0;
            character.Bag = new List<CharacterBag> { };

            for (int i = 0; i < Cfg.MaxSlotBag; i++)
                character.Bag.Add(CharacterBag.New(i));

            character.CurrentStatus = new CharacterStatus { };

            character.CurrentStatus.Attack = Cfg.ClassBase[data.Class].Attack;
            character.CurrentStatus.ChaosRate = Cfg.ClassBase[data.Class].ChaosRate;
            character.CurrentStatus.CurHP = Cfg.ClassBase[data.Class].CurHP;
            character.CurrentStatus.CurMP = Cfg.ClassBase[data.Class].CurMP;
            character.CurrentStatus.Defense = Cfg.ClassBase[data.Class].Defense;
            character.CurrentStatus.Direction = Cfg.ClassBase[data.Class].Direction;

            string[] buff = Cfg.ClassBase[data.Class].Special.Split(',');
            character.CurrentStatus.WMaster = ushort.Parse(buff[0]);
            character.CurrentStatus.FMaster = ushort.Parse(buff[1]);
            character.CurrentStatus.SMaster = ushort.Parse(buff[2]);
            character.CurrentStatus.TMaster = ushort.Parse(buff[3]);

            character.CurrentStatus.Level = Cfg.ClassBase[data.Class].Level;
            character.CurrentStatus.MaxHP = Cfg.ClassBase[data.Class].MaxHP;
            character.CurrentStatus.MaxMP = Cfg.ClassBase[data.Class].MaxMP;
            character.CurrentStatus.Merchant = Cfg.ClassBase[data.Class].Merchant;
            character.CurrentStatus.MobSpeed = Cfg.ClassBase[data.Class].MobSpeed;

            buff = Cfg.ClassBase[data.Class].BaseStatus.Split(',');
            character.CurrentStatus.SStr = short.Parse(buff[0]);
            character.CurrentStatus.SInt = short.Parse(buff[1]);
            character.CurrentStatus.SDex = short.Parse(buff[2]);
            character.CurrentStatus.SCon = short.Parse(buff[3]);

            character.Equip = new List<CharacterEquip> { };

            character.Equip.Add(CharacterEquip.New(0, Cfg.ClassBase[data.Class].Face));
            character.Equip.Add(CharacterEquip.New(1, Cfg.ClassBase[data.Class].Helmet));
            character.Equip.Add(CharacterEquip.New(2, Cfg.ClassBase[data.Class].Armor));
            character.Equip.Add(CharacterEquip.New(3, Cfg.ClassBase[data.Class].Pant));
            character.Equip.Add(CharacterEquip.New(4, Cfg.ClassBase[data.Class].Glove));
            character.Equip.Add(CharacterEquip.New(5, Cfg.ClassBase[data.Class].Boot));
            character.Equip.Add(CharacterEquip.New(6, Cfg.ClassBase[data.Class].Weapon));
            character.Equip.Add(CharacterEquip.New(7, Cfg.ClassBase[data.Class].Shield));
            character.Equip.Add(CharacterEquip.New(8, Cfg.ClassBase[data.Class].Ring));
            character.Equip.Add(CharacterEquip.New(9, Cfg.ClassBase[data.Class].Amulet));
            character.Equip.Add(CharacterEquip.New(10, Cfg.ClassBase[data.Class].Orb));
            character.Equip.Add(CharacterEquip.New(11, Cfg.ClassBase[data.Class].Stone)); 
            character.Equip.Add(CharacterEquip.New(12, Cfg.ClassBase[data.Class].Traje));
            character.Equip.Add(CharacterEquip.New(13, Cfg.ClassBase[data.Class].Pixie));
            character.Equip.Add(CharacterEquip.New(14, Cfg.ClassBase[data.Class].Mount));
            character.Equip.Add(CharacterEquip.New(15, Cfg.ClassBase[data.Class].Mantle));

            character.CityId = 0;
            character.Name = data.MobName.ToString();
            character.Critical = Cfg.ClassBase[data.Class].Critikal;
            character.Gold = Cfg.ClassBase[data.Class].Coin;
            character.Exp = 0;
            character.Learn = Cfg.ClassBase[data.Class].LearnedSkill;
            character.MagicIncrement = Cfg.ClassBase[data.Class].Magic;
            character.MasterPoint = Cfg.ClassBase[data.Class].SpecialBonus;
            character.SkillPoint = Cfg.ClassBase[data.Class].SkillBonus;

            buff = Cfg.ClassBase[data.Class].Resist.Split(',');
            character.ResistFire = int.Parse(buff[0]);
            character.ResistHoly = int.Parse(buff[1]);
            character.ResistIce = int.Parse(buff[2]);
            character.ResistThunder = int.Parse(buff[3]);

            character.StatusPoint = 0;

            client.GetAccount().Characters = _characterService.Get(client.GetAccount().Id);
            character.Slot = client.GetAccount().Characters == null ? 0 : client.GetAccount().Characters.Count;
           
            return _characterService.Create(character);
        }

        public Character SelectOne(ClientSession client, int slot)
        {
            //int sessionId = Game.Clients.FindIndex(b => b.Id == client.Id);
            //Game.Clients[sessionId].GetAccount().Characters = new List<Character>();
           // Game.Clients[sessionId].GetAccount().Characters.Add(Db.Controller.CharacterController.GetOne(client.GetAccount().Id, slot));
            return _characterService.GetOne(client.GetAccount().Id, slot);
        }

        public List<Character> Select(ClientSession client)
        {
            
            return _characterService.Get(client.GetAccount().Id);

        }

        public void CharacterLogin(ClientSession client, MsgServerCharacterLogin data)
        {

            client.GetAccount().Character = SelectOne(client, data.Slot);

            if (client.GetAccount().Character == null)
            {
                client.Send(MsgClient.New(Cfg.LangXml.CharacterSelectFail));
                client.Close();
            }
            else
            {
                client.Send(MsgClientCharacterInfo.New(client.GetAccount().Character));
                client.Send(MsgClientSpawan.New(client));
                client.SendMsg(Cfg.LangXml.WellcometoWord, EColor.CornBlueName);
            }
        }


    }
}
