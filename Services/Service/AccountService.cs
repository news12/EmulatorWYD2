using Db.Entities;
using Db.Data;
using Service.Interface;

namespace Service.Service
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


        public int GetStatus(int Id)
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

        public void SetStatus(int Id, int Status)
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
         protected List<Account> GetListStatus(int status)
        {
            using var context = new MainDbContext();
            try
            {
                return context.Accounts.Where(b => b.Status == status).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        //not implement in interface
        protected List<DonateGame> GetDonateStatus(int gameId, int status)
        {
            using var context = new MainDbContext();
            try
            {
                return context.Donates.Where(b => b.Game_Id == gameId && b.Status == status).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        //not implement in interface
        protected List<PassGame> GetPassStatus(int gameId, int status)
        {
            using var context = new MainDbContext();
            try
            {
                return context.Passwords.Where(b => b.Game_Id == gameId && b.Status == status).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected List<Account> GetListAll()
        {
            using var context = new MainDbContext();
            try
            {
                return context.Accounts.ToList();

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
                List<Account> newList = GetListStatus(0);

                foreach (var acc in newList)
                {
                    acc.Status = 1;
                    context.Accounts.SingleUpdate(acc);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DonateGame> GetDonations(int gameId, int status)
        {
            using var context = new MainDbContext();
            try
            {
                List<DonateGame> newList = GetDonateStatus(gameId, status);

                return newList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Account> GetAccounts(int status)
        {
            using var context = new MainDbContext();
            try
            {
                List<Account> newList = GetListStatus(status);

                return newList;
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

        public void UpdateDonate(DonateGame data, string field)
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

        public List<PassGame> GetPasswords(int gameId, int status)
        {
            using var context = new MainDbContext();
            try
            {
                List<PassGame> newList = GetPassStatus(gameId, status);

                return newList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdatePassword(PassGame data, string field)
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

        public void CreateDonate(DonateGame data)
        {
            using (var context = new MainDbContext())
            {
                try
                {
                    context.Donates.Add(data);
                    context.SaveChanges();


                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
