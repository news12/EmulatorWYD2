using Db.Entities;

namespace Service.Interface
{
    public interface IAccountService
    {
        Account? Get(string Username);
        int GetStatus(int Id);
        void SetStatus(int Id, int Status);
        void Update(Account data);
        void UpdateAll();
        void Update(Account data, string field);
        List<Account> GetAccounts(int status);
        List<DonateGame> GetDonations(int gameId, int status);
        void UpdateDonate(DonateGame data, string field);
        void CreateDonate(DonateGame data);
        List<PassGame> GetPasswords(int gameId, int status);
        void UpdatePassword(PassGame data, string field);

    }

    
}
