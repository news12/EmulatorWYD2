using System.Net;

namespace Db.Entities
{
    public class Account
    {
        public int Id { get; protected set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Numeric { get; private set; }
        public ushort CharOnline { get; set; }
        public ushort Channel { get; set; }
        public uint Status { get; set; }
        public uint NumericFail { get; set; }
        public List<Character>? Characters { get;  set; }
        public Character Character { get; set; }




    }
}
