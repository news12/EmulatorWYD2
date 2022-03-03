using Service.Interface;
using Db.Data;
using Db.Entities;
using Application.Config;
using Application.Enum;
using System.Text.RegularExpressions;
using Services.Service;
using Application.Packet;

namespace Application.Controller
{
    public class AccountController
    {
        protected readonly IAccountService _accountService;

        //constructor
        public AccountController(IAccountService accountService) => _accountService = accountService;

        public AccountController()
        {
            _accountService = new AccountService();
        }

        public void Login(ClientSession client, MsgServerLogin rcv)
        {
          
            if (!Regex.IsMatch(rcv.UserName, @"^[A-Za-z0-9]{4,12}$"))
            {
                client.Send(MsgClient.New(Cfg.LangXml.CharacterPass));
                client.Close();
            }
            else if (!Regex.IsMatch(rcv.Password, @"^[A-Za-z0-9]{4,10}$"))
            {
                client.Send(MsgClient.New(Cfg.LangXml.CharacterPass));
                client.Close();

            }
            else
            {
                //account log
                Log.LogApp.Info($"Login:{rcv.UserName} foi validado com sucesso.");
                Log.LogUser.Info($"UserName: {rcv.UserName}, {rcv.UserName.Length}");
                Log.LogUser.Info($"Password: {rcv.Password.GetHashCode()}, {rcv.Password.Length}");

                //verifica se tem conexão com o banco de dados
                if (CheckConnection.GetConnection())
                {
                    //faz a validação da autenticação do usuario
                    client.SetAccount(Validation(client, rcv.UserName, rcv.Password));

                    //se retornar nulo a função GetAccount cria uma acc nova
                    //então comparamos se o id é diferente de zero é pq retornou sucesso na validação
                    if (client.GetAccount().Id != 0)
                    {
                        SetStatus(client, ClientStatus.Login);
                        CharacterController characterController = new();
                        client.GetAccount().Characters = characterController.Select(client);
                        client.Send(MsgClientLogin.New(client));
                        client.Send(MsgClient.New(Cfg.LangXml.WellcomeToLogin));

                    }
                }
                else
                {
                    Log.LogUser.Error($"Login Error Account({rcv.UserName}) msg({Cfg.LangXml.DbNotConnected})");
                    client.Send(MsgClient.New(Cfg.LangXml.DbNotConnected));
                    client.Close();
                }


            }
        }

        protected  Account Validation(ClientSession client, string Name, string Pass)
        {
            //busca a conta no banco pelo nome de usuario
            Account acc = Get(Name);//AccountController.Get(Name);
            //se não tiver retornado nulo verifica se veio um id valido
            if (acc?.Id > 0)
            {
                //compara se a senha esta correta
                //obs Lembrar de colocar um hash
                if (acc.Password != Pass)
                {
                    Log.LogUser.Error($"Login Error Account({Name}) msg({Cfg.LangXml.IncorrectPass})");
                    client.Send(MsgClient.New(Cfg.LangXml.IncorrectPass));
                    client.Close();
                    acc = null;
                }
                //se o status for maior que zero essa conta já esta logada
                else if (acc.Status > 0)
                {
                    Log.LogUser.Error($"Login Error Account({Name}) msg({Cfg.LangXml.IsConnected})");
                    client.Send(MsgClient.New(Cfg.LangXml.IsConnected));
                    client.Close();
                    acc = null;
                }

                //Nota: em caso de falha na validação sempre retorne acc = null.

            }
            else// retornou nulo do banco
            {
                Log.LogUser.Error($"Login Error Account({Name}) msg({Cfg.LangXml.AccountNotFound})");
                client.Send(MsgClient.New(Cfg.LangXml.AccountNotFound));
                client.Close();
                acc = null;
            }

            return acc;
        }

        public void RemoveStatusLogin(ClientSession client)
        {
            //client.Account = AccountController.Get(data.Account);
            if (client.GetAccount().Id != 0)
            {
                uint status = GetStatus(client);
                if (status == (uint)ClientStatus.Login)
                    SetStatus(client, ClientStatus.Connection);

            }

        }

        public void SetStatus(ClientSession client, ClientStatus status)
        {
            if (client.GetAccount().Id != 0)
              _accountService.SetStatus(client.GetAccount().Id, (uint)status);

        }

        public uint GetStatus(ClientSession client)
        {
           return _accountService.GetStatus(client.GetAccount().Id);
        }

        public void Update(Account accout, string data)
        {
            _accountService.Update(accout, data);
        }

        public void UpdateAll()
        {
            _accountService.UpdateAll();
        }

        public Account Get(string name)
        {
            return _accountService.Get(name);
        }
    }

}
