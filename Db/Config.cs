using System.Xml;
namespace Db
{
    public static class Config
    {
        public static string? ConfigPath { get; set; }
        public static string? MysqlConnectionString { get; set; }
        public static void ConfigLoad()
        {
            try
            {
                ConfigPath = AppDomain.CurrentDomain.BaseDirectory + "ConfigEx/Config.xml";
                using (XmlReader reader = XmlReader.Create(ConfigPath))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            //return only when you have START tag  
                            switch (reader.Name.ToString())
                            {

                                case "StringConnection":
                                    MysqlConnectionString = reader.ReadString();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

                throw;
            }

        }


    }
}
