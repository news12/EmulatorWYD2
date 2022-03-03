using Db.Entities;
using Application.Config;
using Application.Controller;
using Application.OpCode;
using Application.Packet;
using Service.Interface;
using Services.Service;
using Application;

namespace Application.Packet
{
    public  class PacketController
    {
        private static readonly string Lock = "";

        private readonly AccountController _accountController;
        private readonly NumericController _numericController;
        private readonly CharacterController _characterController;
        public PacketController()
        {
            IAccountService accountService = new AccountService();
            _accountController = new AccountController(accountService);

            _numericController = new NumericController(_accountController);

            ICharacterService characterService = new CharacterService();
            _characterController = new CharacterController(characterService);
        }
      
        // Packet Controller
        public  void Controller(ClientSession client, byte[] data)
        {
            lock (Lock)
            {
                MsgHeader header = PacketConvert.ToStruct<MsgHeader>(data);
#if (DEBUG)
                Log.Rcv(client, header);
#endif
                Log.LogPacket.Trace($"Rcv Cli:{header.ClientId} Packet:{header.PacketId}");
                if (header.PacketId == 0x03A0)
                {
                    if (header.Size != 12 || data.Length != 12)
                    {
                        client.Close();
                    }

                    return;
                }
                else if (header.PacketId == (ushort)OpCodeType.pLoginCheck)
                {
                    Log.LogUser.Error($"Enviou packet [{header.PacketId}] e foi retornado para a tela de login");
                    client.Send(MsgClient.New(Cfg.LangXml.LoginVerify));
                    client.Close();
                }

                OpCodeType validCode = CheckOpCode.Check(header.PacketId, header.Size);

                if (validCode == 0)
                {
                    client.Close();
                    return;
                }
                else
                {
                    switch (validCode)
                    {
                        case OpCodeType.pMove:
                            //func moviment map
                            break;
                        case OpCodeType.pUpdateCity:
                            //func update citys
                            break;
                        case OpCodeType.pLogin:
                            _accountController.Login(client, PacketConvert.ToStruct<MsgServerLogin>(data));

                            break;
                        case OpCodeType.pNumeric:
                            _numericController.GetNumeric(client, PacketConvert.ToStruct<MsgServerNumeric>(data));

                            break;
                        case OpCodeType.pCharacterCreate:
                            {
                               Character createdCharacter = _characterController.Create(client, PacketConvert.ToStruct<MsgServerCharacterCreate>(data));
                               
                                if(createdCharacter != null)
                                {
                                    
                                    client.Send(MsgClientCharacterCreate.New(client));
                                    client.Send(MsgClient.New(Cfg.LangXml.CharacterCreateSuccess));
                                }
                                else
                                    client.Send(MsgClient.New(Cfg.LangXml.CharacterCreateFail));
                                

                                break;
                            }
                        case OpCodeType.pCharacterLogin:
                            {
                                _characterController.CharacterLogin(client, PacketConvert.ToStruct<MsgServerCharacterLogin>(data));

                                break;
                            }
                        default:
                            break;
                    }
                }


            }
        }
    }
}
