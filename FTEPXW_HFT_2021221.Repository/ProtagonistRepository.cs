using FTEPXW_HFT_2021221.Data;
using FTEPXW_HFT_2021221.Models;
using System;
using System.Linq;

namespace FTEPXW_HFT_2021221.Repository
{
    public class ProtagonistRepository : IProtagonistRepository
    {
        MovieDatabaseContext db;
        public ProtagonistRepository(MovieDatabaseContext db)
        {
            this.db = db;
        }
        // CRUD
        public void Create(Protagonist prot)
        {
            db.Protagonists.Add(prot);
            db.SaveChanges();

        }
        public Protagonist Read(int id)
        {
            return db.Protagonists.FirstOrDefault(a => a.ProtagonistID == id);
        }
        public IQueryable<Protagonist> ReadAll()
        {
            return db.Protagonists;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
        public void Update(Protagonist prot)
        {
            var old = Read(prot.ProtagonistID);
            old.Name = prot.Name;
            old.CharacterName = prot.CharacterName;
            old.Gender = prot.Gender;
            old.Age = prot.Age;
            old.Oscar = prot.Oscar;
            db.SaveChanges();
        }


    }
}