using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace CharBaseEditor
{
    public class Config
    {
        public static string? ConfigTkBase { get; set; }
        public static string? ConfigFmBase { get; set; }
        public static string? ConfigBmBase { get; set; }
        public static string? ConfigHtBase { get; set; }
        public static List<ClassBase>? ClassBase { get; set; }

        public static int refClass { get; set; }

        public static void ConfigLoad()
        {
            try
            {
                ConfigTkBase = AppDomain.CurrentDomain.BaseDirectory + "ConfigEx/TkBase.xml";
                ConfigFmBase = AppDomain.CurrentDomain.BaseDirectory + "ConfigEx/FmBase.xml";
                ConfigBmBase = AppDomain.CurrentDomain.BaseDirectory + "ConfigEx/BmBase.xml";
                ConfigHtBase = AppDomain.CurrentDomain.BaseDirectory + "ConfigEx/HtBase.xml";

                ClassBase = new List<ClassBase>();

                string str = File.ReadAllText(ConfigTkBase);
                XmlSerializer serialize = new(typeof(ClassBase));

                using StringReader reader0 = new(str);
                ClassBase.Add(serialize.Deserialize(reader0) as ClassBase);

                str = File.ReadAllText(ConfigFmBase);

                using StringReader reader1 = new(str);
                ClassBase.Add(serialize.Deserialize(reader1) as ClassBase);

                str = File.ReadAllText(ConfigBmBase);

                using StringReader reader2 = new(str);
                ClassBase.Add(serialize.Deserialize(reader2) as ClassBase);

                str = File.ReadAllText(ConfigHtBase);

                using StringReader reader3 = new(str);
                ClassBase.Add(serialize.Deserialize(reader3) as ClassBase);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
    }
}
