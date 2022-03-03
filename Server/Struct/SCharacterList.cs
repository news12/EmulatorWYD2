using Service.Interface;
using Db.Entities;
using Application.Config;
using System.Runtime.InteropServices;

namespace Application.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct SCharacterList
    {
        public short PosX;

        public short PosY;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string Name;

        public SStatus Status;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public SItem[] Equip;

        public ushort Guild;

        public uint Gold;

        public ulong Exp;

        // Construtores
        public static List<SCharacterList> New(ClientSession client)
        {

            List<SCharacterList> newList = new();
            SCharacterList tmp = new()
            {
              
                PosX = 0,
                PosY = 0,

                Name = "",
                Status = new SStatus { },
                Equip = new SItem[16],

 
                Gold = 0,
                Exp = 0
            };

            tmp.Status = SStatus.New();

            for (int i = 0; i < Cfg.MaxSlotEquip; i++)
                tmp.Equip[i] = SItem.New();
            
            List<Character> Characters =  client.GetAccount().Characters;
            int maxChar = 4;
            int cListCount = Characters == null ? 0 : Characters.Count;
     
            if (cListCount > 0)
            {

                foreach (var character in Characters)
                {
                    Character mob = character;
                    tmp.PosX = mob.LastPosition.X;
                    tmp.PosY = mob.LastPosition.Y;

                    tmp.Name = mob.Name;
                    tmp.Status.Level = (short)mob.CurrentStatus.Level;
                    tmp.Status.Defense = mob.CurrentStatus.Defense;
                    tmp.Status.Attack = mob.CurrentStatus.Attack;
                    tmp.Status.Merchant = mob.CurrentStatus.Merchant;
                    tmp.Status.MobSpeed = mob.CurrentStatus.MobSpeed;
                    tmp.Status.Direction = mob.CurrentStatus.Direction;
                    tmp.Status.ChaosRate = mob.CurrentStatus.ChaosRate;
                    tmp.Status.MaxHP = mob.CurrentStatus.MaxHP;
                    tmp.Status.MaxMP = mob.CurrentStatus.MaxMP;
                    tmp.Status.CurHP = mob.CurrentStatus.CurHP;
                    tmp.Status.CurMP = mob.CurrentStatus.CurMP;
                    tmp.Status.Str = mob.CurrentStatus.SStr;
                    tmp.Status.Int = mob.CurrentStatus.SInt;
                    tmp.Status.Dex = mob.CurrentStatus.SDex;
                    tmp.Status.Con = mob.CurrentStatus.SCon;

                    tmp.Status.Special[0] = (short)mob.CurrentStatus.WMaster;
                    tmp.Status.Special[1] = (short)mob.CurrentStatus.FMaster;
                    tmp.Status.Special[2] = (short)mob.CurrentStatus.SMaster;
                    tmp.Status.Special[3] = (short)mob.CurrentStatus.TMaster;
                    for (int i = 0; i < Cfg.MaxSlotEquip; i++)
                    {
                        tmp.Equip[i].Id = (short)mob.Equip[i].ItemId;
                        tmp.Equip[i].Ef[0].Type = (byte)mob.Equip[i].Ef1;
                        tmp.Equip[i].Ef[0].Value = (byte)mob.Equip[i].Efv1;
                        tmp.Equip[i].Ef[1].Type = (byte)mob.Equip[i].Ef2;
                        tmp.Equip[i].Ef[1].Value = (byte)mob.Equip[i].Efv2;
                        tmp.Equip[i].Ef[2].Type = (byte)mob.Equip[i].Ef3;
                        tmp.Equip[i].Ef[2].Value = (byte)mob.Equip[i].Efv3;
                    }

                    tmp.Gold = mob.Gold;
                    tmp.Exp = mob.Exp;

                  newList.Add(tmp);
                }
                
            }
            for (int j = cListCount; j < maxChar; j++)
            {

                tmp.PosX = 0;
                tmp.PosY = 0;

                tmp.Name = "";
                tmp.Status = SStatus.New();
                tmp.Equip = new SItem[16];

                tmp.Gold = 0;
                tmp.Exp = 0;

                newList.Add(tmp);
            }

            return newList;
        }

     
    }
}
