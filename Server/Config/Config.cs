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

        public static Dictionary<int, string> msgBotDonate { get; set; }
        public static int TimeDelaySendCharacter { get; set;}
        public static List<Player>? Players { get; set; }

        public static DateTime Time => DateTime.UtcNow;
        public static readonly CultureInfo Culture = new("pt-BR");
        public static readonly Encoding Encoding = Encoding.GetEncoding("Windows-1252");
        public static void ConfigLoad()
        {
            try
            {
              

                ConfigPath = AppDomain.CurrentDomain.BaseDirectory + "ConfigEx/Config.xml";
                ConfigLang = AppDomain.CurrentDomain.BaseDirectory + "ConfigEx/LangServer.xml";


                Log.LogApp = LogManager.GetLogger("app");
                Log.LogUser = LogManager.GetLogger("user");
                Log.LogDb = LogManager.GetLogger("db");
                Log.LogPacket = LogManager.GetLogger("packet");

                msgBotDonate = new();
                Players = new List<Player>();
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


            }
            catch (Exception e)
            {

                Log.LogApp?.Error(e.Message);

                throw;
            }

        }


    }

}
