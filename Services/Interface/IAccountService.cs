using Db.Entities;

namespace Service.Interface
{
    public interface IAccountService
    {
        Account? Get(string Username);
        uint GetStatus(int Id);
        void SetStatus(int Id, uint Status);
        void Update(Account data);
        void UpdateAll();
        void Update(Account data, string field);

     
    }

    
}
