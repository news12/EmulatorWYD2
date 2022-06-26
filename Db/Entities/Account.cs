using System.Net;

namespace Db.Entities
{
    public class Account
    {
        public int Id { get; protected set; }
        public int User_Id { get; protected set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public int Donate { get; set; }
        public List<DonateGame>? Donates { get; set; }
        public int Status { get; set; }
       

    }
}
