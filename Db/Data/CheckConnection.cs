using StarDb;

namespace Db.Data
{
    public class CheckConnection
    {
        public static bool GetConnection()
        {
            using (var context = new MainDbContext())
            {
                try
                {
                    return context.Database.CanConnect();
                }
                catch (Exception)
                {

                    return false;
                }


            }

        }
    }
}
