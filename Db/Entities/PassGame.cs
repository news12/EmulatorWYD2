
namespace Db.Entities
{
    public class PassGame
    {
        public int Id { get; protected set; }
        public int Game_Id { get; protected set; }
        public string Password { get; set; }
        public string Numeric { get; set; }
        public int Status { get; set; }
    }
}
