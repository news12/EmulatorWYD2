namespace Db.Entities
{
    public class DonateGame
    {
        public int Id { get; protected set; }
        public int Game_Id { get; protected set; }
        public int User_Id { get; protected set; }
        public int Donate { get; protected set; }
        public int Status { get; set; }
        public DateTime Created_At { get;  set; }

        public void SetGameId(int id)
        {
            Game_Id = id;
        }

        public void SetUserId(int id)
        {
            User_Id = id;
        }

        public void SetDonate(int value)
        {
            Donate = value;
        }


    }
}
