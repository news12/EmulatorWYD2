

using Db.Entities;

namespace Service.Interface
{
    public interface IBotTelegram
    {
        BotDonate? Get(string name);
        List<BotDonate> GetAll();
        List<BotDonate> GetListStatus(int status);
        void Create(BotDonate data);
        void Update(BotDonate data);
    }
}
