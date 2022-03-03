using Db.Data;
using Db.Entities;
using Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Services.Service
{
    public class CharacterService : ICharacterService
    {

        public List<Character>? Get(int AccountId)
        {
            using (var context = new MainDbContext())
            {
                try
                {
                    var ret = context.Characters?.
                        Include(b => b.Affect).
                        Include(b => b.Bag).
                        Include(b => b.Equip).
                        Include(b => b.CurrentStatus).
                        Include(b => b.LastPosition).
                       // Include(b => b.InvExtra).
                        Where(b => b.AccountId == AccountId).
                        Take(4).
                        ToList();
                    return ret;
                }
                catch (Exception)
                {

                    return null;
                }



            }

        }

        public Character? GetOne(int AccountId, int slot)
        {
            using (var context = new MainDbContext())
            {
                try
                {
                    var ret = context.Characters?.
                        Include(b => b.Affect).
                        Include(b => b.Bag).
                        Include(b => b.Equip).
                        Include(b => b.CurrentStatus).
                        Include(b => b.LastPosition).
                        //Include(b => b.InvExtra).
                        Where(b => b.AccountId == AccountId).
                        Single(b => b.Slot == slot);
                    return ret;
                }
                catch (Exception)
                {

                    return null;
                }



            }

        }

        public Character Create(Character data)
        {
            
            using (var context = new MainDbContext())
            {
                try
                {
                    context.Characters.Add(data);
                    context.SaveChanges();

                   
                }
                catch (Exception)
                {

                   return null;
                }
            }

            return data;
        }
        public void CreateLastPosition(CharacterLastPosition data)
        {
            using (var context = new MainDbContext())
            {
                try
                {
                    context.CharacterLastPosition.Add(data);
                    context.SaveChanges();

                }
                catch (Exception)
                {


                }
            }
        }

        public void CreatBag(CharacterBag data)
        {
            using (var context = new MainDbContext())
            {
                try
                {
                    context.CharacterBag.Add(data);
                    context.SaveChanges();

                }
                catch (Exception)
                {


                }
            }
        }

        public void CreateEquip(CharacterEquip data)
        {
            using (var context = new MainDbContext())
            {
                try
                {
                    context.CharacterEquip.Add(data);
                    context.SaveChanges();

                }
                catch (Exception)
                {


                }
            }
        }
        public void CreateBaseStatus(CharacterStatus data)
        {
            using (var context = new MainDbContext())
            {
                try
                {
                    context.CharacterStatus.Add(data);
                    context.SaveChanges();

                }
                catch (Exception)
                {


                }
            }
        }
    }
}