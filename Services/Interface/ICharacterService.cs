using Db.Entities;

namespace Service.Interface
{
    public interface ICharacterService
    {
        Character? Get(string name);
        List<Character> GetAll();
        void Create(Character data);
        void Update(Character data);
    }
}
