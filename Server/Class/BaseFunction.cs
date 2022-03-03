using Application.Config;
using Application.Struct;
using Db.Entities;
using System.Net;

namespace Application.Class
{
    public static class Function
    {
        public static string GetString(byte[] data)
        {
            if (data == null)
            {
                throw new Exception("data == null");
            }

            return Cfg.Encoding.GetString(data).TrimEnd('\0');
        }

        public static string GetIpEndPoint(EndPoint e)
        {
            IPEndPoint ip = e as IPEndPoint;
            return ip.Address.ToString();
        }

        public static string GetBaseLogAccount(object obj)
        {
            var newObj = (SLogAccount)obj;
            string msg = $"A Account[{newObj.Name}]Ip[{GetIpEndPoint(newObj.Ip)}]=> {newObj.Msg} ";
            return msg;
        }

        private struct SLogAccount
        {
            public string Name { get; set; }
            public EndPoint Ip { get; set; }
            public string Msg { get; set; }
        }

        public static SItem[] GetEquipDb(List<CharacterEquip> list)
        {
            int countEquip = list.Count;
            SItem[] tempItem = new SItem[16];

            for (int i = 0; i < countEquip; i++)
            {
                tempItem[i].Ef = new SItemEffect[3];
                tempItem[i].Id = (short)list[i].ItemId;
                tempItem[i].Ef[0].Type = (byte)list[i].Ef1;
                tempItem[i].Ef[0].Value = (byte)list[i].Efv1;
                tempItem[i].Ef[1].Type = (byte)list[i].Ef2;
                tempItem[i].Ef[1].Value = (byte)list[i].Efv2;
                tempItem[i].Ef[2].Type = (byte)list[i].Ef3;
                tempItem[i].Ef[2].Value = (byte)list[i].Efv3;
            }

            return tempItem;

        }

        public static SItem[] GetBagDb(List<CharacterBag> list)
        {
            int countEquip = list.Count;
            SItem[] tempItem = new SItem[64];

            for (int i = 0; i < countEquip; i++)
            {
                tempItem[i].Ef = new SItemEffect[3];
                tempItem[i].Id = (short)list[i].ItemId;
                tempItem[i].Ef[0].Type = (byte)list[i].Ef1;
                tempItem[i].Ef[0].Value = (byte)list[i].Efv1;
                tempItem[i].Ef[1].Type = (byte)list[i].Ef2;
                tempItem[i].Ef[1].Value = (byte)list[i].Efv2;
                tempItem[i].Ef[2].Type = (byte)list[i].Ef3;
                tempItem[i].Ef[2].Value = (byte)list[i].Efv3;
            }

            return tempItem;

        }

        public static SStatus  GetBaseStatus(ClassBase classBase)
        {
            SStatus temp = new();
            temp.Special = new short[4];
            string[] buff = classBase.BaseStatus.Split(',');
            temp.Str = short.Parse(buff[0]);
            temp.Int = short.Parse(buff[1]);
            temp.Dex = short.Parse(buff[2]);
            temp.Con = short.Parse(buff[3]);
            temp.Attack = classBase.Attack;
            temp.ChaosRate = classBase.ChaosRate;
            temp.CurHP = classBase.CurHP;
            temp.CurMP = classBase.CurMP;
            temp.Defense = classBase.Defense;
            temp.Direction = classBase.Direction;
            temp.Level = (short)classBase.Level;
            temp.MaxHP = classBase.MaxHP;
            temp.MaxMP = classBase.MaxMP;
            temp.Merchant = classBase.Merchant;
            temp.MobSpeed = classBase.MobSpeed;
            buff = classBase.Special.Split(',');
            temp.Special[0] = short.Parse(buff[0]);
            temp.Special[1] = short.Parse(buff[1]);
            temp.Special[2] = short.Parse(buff[2]);
            temp.Special[3] = short.Parse(buff[3]);

            return temp;
        }

        public static SStatus GetCurrentStatus(CharacterStatus status)
        {
            SStatus temp = new();
            temp.Special = new short[4];
            temp.Str = status.SStr;
            temp.Int = status.SInt;
            temp.Dex = status.SDex;
            temp.Con = status.SCon;
            temp.Attack = status.Attack;
            temp.ChaosRate = status.ChaosRate;
            temp.CurHP = status.CurHP;
            temp.CurMP = status.CurMP;
            temp.Defense = status.Defense;
            temp.Direction = status.Direction;
            temp.Level = (short)status.Level;
            temp.MaxHP = status.MaxHP;
            temp.MaxMP = status.MaxMP;
            temp.Merchant = status.Merchant;
            temp.MobSpeed = status.MobSpeed;
            temp.Special[0] = (short)status.WMaster;
            temp.Special[1] = (short)status.FMaster;
            temp.Special[2] = (short)status.SMaster;
            temp.Special[3] = (short)status.TMaster;

            return temp;
        }


    }
}
