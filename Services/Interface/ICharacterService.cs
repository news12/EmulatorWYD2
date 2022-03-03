using Db.Entities;

namespace Service.Interface
{
    public interface ICharacterService
    {
        List<Character>? Get(int AccountId);
        Character? GetOne(int AccountId, int slot);
        Character Create(Character data);
        void CreateLastPosition(CharacterLastPosition data);
        void CreatBag(CharacterBag data);
        void CreateEquip(CharacterEquip data);
        void CreateBaseStatus(CharacterStatus data);
    }
}
