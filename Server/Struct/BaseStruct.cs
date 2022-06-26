using Service.Generic;
using System.Runtime.InteropServices;

namespace Application.Struct
{
    public class BaseStruct
    {

    }

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
	public struct CooCity
    {
		
		public SPoint<uint> Base;//594DD8 594DDC
	
		public SPoint<uint> Recall;//594DE0 594DE4
	
		public SPoint<uint> LimitWarInf;//594DE8 594DEC
		
		public SPoint<uint> LimitWarSup;//594DF0 594DF4
		
		public SPoint<uint> LimitWarInf2;//594DF8 594DFC
		
		public SPoint<uint> LimitWarSup2;//594E00 594E04
		
		public SPoint<uint> WarMove1;//594E08 594E0C
	
		public SPoint<uint> WarMove2;//594E10 594E14

		public static CooCity New(int city = 0)
		{
			CooCity temp = new();
			temp.Base = new SPoint<uint>(Const.StaticCooCity[city, 0], Const.StaticCooCity[city, 1]);
			temp.Recall = new SPoint<uint>(Const.StaticCooCity[city, 2], Const.StaticCooCity[city, 3]);
			temp.LimitWarInf = new SPoint<uint>(Const.StaticCooCity[city, 4], Const.StaticCooCity[city, 5]);
			temp.LimitWarSup = new SPoint<uint>(Const.StaticCooCity[city, 6], Const.StaticCooCity[city, 7]);
			temp.LimitWarInf2 = new SPoint<uint>(Const.StaticCooCity[city, 8], Const.StaticCooCity[city, 9]);
			temp.LimitWarSup2 = new SPoint<uint>(Const.StaticCooCity[city, 10], Const.StaticCooCity[city, 11]);
			temp.WarMove1 = new SPoint<uint>(Const.StaticCooCity[city, 12], Const.StaticCooCity[city, 13]);
			temp.WarMove2 = new SPoint<uint>(Const.StaticCooCity[city, 14], Const.StaticCooCity[city, 15]);

			return temp;
		}


	}

}
