using Db.Entities;
using Application.Enum;

namespace Application.Class
{
    public class Client
    {
        public ushort Channel { get; private set; }
        public bool Active { get; private set; }

        public ClientStatus Status { get; set; }

        public DateTime ConnectionTime { get; private set; }

        // account
        public Account? Account { get; private set; }

        public int ClientId { get; set; }

        public Map? Map { get; set; }

        public Character? Character { get; set; }

        public Render? Render { get; set; }
    }
}
