using System.Xml.Serialization;

namespace Application.Class
{
    [XmlRoot("item")]
    public class ItemListXML
    {
        [XmlElement("ID")]
        public int Id { get; set; }
        [XmlElement("NAME")]
        public string Name { get; set; }
        [XmlElement("MESH.TEXTURE")]
        public string Mesh_Texture { get; set; }
        [XmlElement("LVL.STR.INT.DEX.CON")]
        public string Status { get; set; }
        [XmlElement("PRICE")]
        public int Price { get; set; }
        [XmlElement("UNIQUE")]
        public int Unique { get; set; }
        [XmlElement("SLOT")]
        public int Slot { get; set; }
        [XmlElement("EXTREME")]
        public int Extreme { get; set; }
        [XmlElement("GRADE")]
        public int Grade { get; set; }
        [XmlElement("EF1")]
        public int EF1 { get; set; }
        [XmlElement("EFV1")]
        public int EFV1 { get; set; }
        [XmlElement("EF2")]
        public int EF2 { get; set; }
        [XmlElement("EFV2")]
        public int EFV2 { get; set; }
        [XmlElement("EF3")]
        public int EF3 { get; set; }
        [XmlElement("EFV3")]
        public int EFV3 { get; set; }
        [XmlElement("EF4")]
        public int EF4 { get; set; }
        [XmlElement("EFV4")]
        public int EFV4 { get; set; }
        [XmlElement("EF5")]
        public int EF5 { get; set; }
        [XmlElement("EFV5")]
        public int EFV5 { get; set; }
        [XmlElement("EF6")]
        public int EF6 { get; set; }
        [XmlElement("EFV6")]
        public int EFV6 { get; set; }
        [XmlElement("EF7")]
        public int EF7 { get; set; }
        [XmlElement("EFV7")]
        public int EFV7 { get; set; }
        [XmlElement("EF8")]
        public int EF8 { get; set; }
        [XmlElement("EFV8")]
        public int EFV8 { get; set; }
        [XmlElement("EF9")]
        public int EF9 { get; set; }
        [XmlElement("EFV9")]
        public int EFV9 { get; set; }
        [XmlElement("EF10")]
        public int EF10 { get; set; }
        [XmlElement("EFV10")]
        public int EFV10 { get; set; }

    }
}

