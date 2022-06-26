using Db.Entities;
using Db.Data;
using Service.Interface;

namespace Services.Service
{
    public class AccountService : IAccountService
    {
       

        public  Account? Get(string Username)
        {
            using var context = new MainDbContext();

            try
            {
                var ret = context.Accounts?.Single(b => b.Name == Username);

                return ret;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public uint GetStatus(int Id)
        {
            using var context = new MainDbContext();
            try
            {
                
                var ret = context.Accounts?.Single(b => b.Id == Id);

                if (ret != null)
                return ret.Status;
                
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SetStatus(int Id, uint Status)
        {
            using var context = new MainDbContext();
            try
            {
                var ret = context.Accounts?.Single(b => b.Id == Id);

                if (ret != null)
                    ret.Status = Status;

                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Account data)
        {
            using var context = new MainDbContext();
            try
            {
                context.Update(data);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //not implement in interface
         protected List<Account> GetListConnected()
        {
            using var context = new MainDbContext();
            try
            {
                return context.Accounts.Where(b => b.Status > 0).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateAll()
        {
            using var context = new MainDbContext();
            try
            {
                List<Account> newList = GetListConnected();

                foreach (var acc in newList)
                {
                    acc.Status = 0;
                    context.Accounts.SingleUpdate(acc);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Account data, string field)
        {
            using var context = new MainDbContext();
            try
            {
                context.Attach(data);
                context.Entry(data).Property(field).IsModified = true;
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
