
namespace Db.Entities
{
    public class Character
    {
        public int Id { get; protected set; }
        public int User_Id { get;  set; }
        public int Game_id { get;  set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public int Fame { get; set; }
        public int CapeInfo { get; set; }
        public int GuildIndex { get; set; }
        public int ClassInfo { get; set; }
        public Int64 Exp { get; set; }
        public int Level { get; set; }
        public int GuildMemberType { get; set; }
        public int Evo { get; set; }
        public int Status { get; set; }
        public void SetId(int id)
        {
            Id = id;
        }

      
    }
}
