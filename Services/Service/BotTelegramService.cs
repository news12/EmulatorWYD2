using Db.Data;
using Db.Entities;
using Service.Interface;
namespace Service.Service
{

    public class BotTelegramService : IBotTelegram
    {
        public void Create(BotDonate data)
        {
            using (var context = new MainDbContext())
            {
                try
                {
                    context.BotDonates.Add(data);
                    context.SaveChanges();


                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public BotDonate? Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<BotDonate> GetAll()
        {
            using var context = new MainDbContext();
            try
            {
                return context.BotDonates.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<BotDonate> GetListStatus(int status)
        {
            using var context = new MainDbContext();
            try
            {
                return context.BotDonates.Where(b => b.Status == status).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(BotDonate data)
        {
            using var context = new MainDbContext();
            try
            {
                context.BotDonates.SingleUpdate(data);
                context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
