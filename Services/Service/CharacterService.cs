﻿using Db.Entities;
using Db.Data;
using Service.Interface;

namespace Service.Service
{
    public class CharacterService : ICharacterService
    {
        public void Create(Character data)
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

                    throw;
                }
            }
        }

        public Character? Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<Character> GetAll()
        {
            using var context = new MainDbContext();
            try
            {
                return context.Characters.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Character data)
        {
            using var context = new MainDbContext();
            try
            {
                context.Characters.SingleUpdate(data);
                context.SaveChanges();

              /*  context.Attach(data);
                context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();*/
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
