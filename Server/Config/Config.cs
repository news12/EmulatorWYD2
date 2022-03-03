using Application.Class;
using Application.Packet;
using Application.Struct;
using NLog;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace Application.Config
{
    public static class Cfg
    {
        public const uint MaxAffect = 32;
        public const uint MaxSlotBag = 60;
        public const uint MaxSlotEquip = 16;
        public static string? ConfigPath { get; set; }
        public static string? ConfigLang { get; set; }
        public static LangXml? LangXml { get; set; }
        public static ConfigXml ConfigXml { get; set; }

        public static string? ConfigTkBase { get; set; }
        public static string? ConfigFmBase { get; set; }
        public static string? ConfigBmBase { get; set; }
        public static string? ConfigHtBase { get; set; }
        public static List<ClassBase>? ClassBase { get; set; }
        public static CooCity[] BaseCooCity { get; set; }

        public static DateTime Time => DateTime.UtcNow;
        public static readonly CultureInfo Culture = new("pt-BR");
        public static readonly Encoding Encoding = Encoding.GetEncoding("Windows-1252");
        public static void ConfigLoad()
        {
            try
            {
                BaseCooCity = new CooCity[5];
                for (int i = 0; i < 5; i++)
                {
                    BaseCooCity[i] = CooCity.New(i);
                }

                ConfigPath = AppDomain.CurrentDomain.BaseDirectory + "ConfigEx/Config.xml";
                ConfigLang = AppDomain.CurrentDomain.BaseDirectory + "ConfigEx/LangServer.xml";

                ConfigTkBase = AppDomain.CurrentDomain.BaseDirectory + "ConfigEx/TkBase.xml";
                ConfigFmBase = AppDomain.CurrentDomain.BaseDirectory + "ConfigEx/FmBase.xml";
                ConfigBmBase = AppDomain.CurrentDomain.BaseDirectory + "ConfigEx/BmBase.xml";
                ConfigHtBase = AppDomain.CurrentDomain.BaseDirectory + "ConfigEx/HtBase.xml";

                Log.LogApp = LogManager.GetLogger("app");
                Log.LogUser = LogManager.GetLogger("user");
                Log.LogDb = LogManager.GetLogger("db");
                Log.LogPacket = LogManager.GetLogger("packet");

                ClassBase = new List<ClassBase>();

                string str = File.ReadAllText(ConfigLang);
                XmlSerializer serialize = new(typeof(LangXml));

                using (StringReader reader = new(str))
                {
                    LangXml = serialize.Deserialize(reader) as LangXml;
                }

                
                str = File.ReadAllText(ConfigPath);
                serialize = new(typeof(ConfigXml));

                using (StringReader reader = new(str))
                {
                    ConfigXml = serialize.Deserialize(reader) as ConfigXml;
                }


                str = File.ReadAllText(ConfigTkBase);
                serialize = new(typeof(ClassBase));

                using (StringReader reader = new(str))
                {
                   ClassBase.Add(serialize.Deserialize(reader) as ClassBase);
                }

                str = File.ReadAllText(ConfigFmBase);
                using (StringReader reader = new(str))
                {
                    ClassBase.Add(serialize.Deserialize(reader) as ClassBase);
                }
                str = File.ReadAllText(ConfigBmBase);
                using (StringReader reader = new(str))
                {
                    ClassBase.Add(serialize.Deserialize(reader) as ClassBase);
                }

                str = File.ReadAllText(ConfigHtBase);
                using (StringReader reader = new(str))
                {
                    ClassBase.Add(serialize.Deserialize(reader) as ClassBase);
                }



            }
            catch (Exception e)
            {

                Log.LogApp?.Error(e.Message);

                throw;
            }

        }


    }

}
