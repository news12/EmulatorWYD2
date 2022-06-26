using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Entities
{
    public class BotDonate
    {
        public int Id { get; protected set; }
        public int User_Id { get; protected set; }
        public int Admin_Id { get; protected set; }
        public string? Name { get; set; }
        public string? Token { get; set; }
        public int Value { get; set; }
        public int Status { get; set; }

        public void SetUserId(int id)
        {
            User_Id = id;
        }

        public void SetAdminId(int id)
        {
            Admin_Id = id;
        }
    }
}
