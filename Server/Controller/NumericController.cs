using Application.Config;
using Application.OpCode;
using Application.Packet;
using System.Text.RegularExpressions;

namespace Application.Controller
{
    public class NumericController
    {
        private readonly AccountController _accountController;

        public NumericController(AccountController accountController) => _accountController = accountController;
        public void Controller(ClientSession client, MsgServerNumeric data)
        {
            if (!Regex.IsMatch(data.Numeric, @"^[0-9]{4,6}$"))
            {
                string msg = "Somente números. 4 a 6 caracteres.";
                client.Send(MsgClient.New(msg));
                client.Close();
            }
        }

        public void GetNumeric(ClientSession client, MsgServerNumeric data)
        {
          
            if (client.GetAccount().Id != 0)
            {
                string Numeric = client.GetAccount().Numeric;
                if (String.IsNullOrEmpty(Numeric))
                {
                    client.AccountUpdate(client.GetAttributeNumeric(), data.Numeric);

                    _accountController.Update(client.GetAccount(), client.GetAttributeNumeric());
                    client.Send(MsgServerNumeric.New(Numeric));
                    client.SendMsg($"Nova senha cadastrada.");


                    return;
                }
                try
                {
                    if (!ValidateNumeric(client, data.Numeric))
                    {
                        client.SendMsg($"Senha numerica incorreta.");
                        client.GetAccount().NumericFail++;
                        client.Send(MsgServerNumeric.New(Numeric, OpCodeType.pNumericFailClient));
                    }
                    else
                    {
                        client.SendMsg($"Aceso liberado.");
                        client.Send(MsgServerNumeric.New(Numeric));
                    }

                }
                catch (Exception e)
                {
                    client.SendMsg($"Não foi possivel verificar sua senha numerica.");
                    client.GetAccount().NumericFail++;
                    client.Send(MsgServerNumeric.New(Numeric, OpCodeType.pNumericFailClient));
                    Log.LogApp.Error("Numeric Error: {0}", e.Message);
                    throw;
                }
            }
        }
        protected bool ValidateNumeric(ClientSession client, string Numeric)
        {
            bool nReturn = false;

            if (client.GetAccount().Numeric.Length > 3)
                nReturn = Numeric.Equals(client.GetAccount().Numeric);

            return nReturn;


        }
    }
}
