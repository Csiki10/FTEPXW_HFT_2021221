using FTEPXW_HFT_2021221.Data;
using FTEPXW_HFT_2021221.Models;
using System;
using System.Linq;

namespace FTEPXW_HFT_2021221.Repository
{
    public class DirectorRepository : IDirectorRepository
    //IDirectorRepository
    {
        MovieDatabaseContext db;
        public DirectorRepository(MovieDatabaseContext db)
        {
            this.db = db;
        }
        // CRUD
        public void Create(Director dir)
        {
            db.Directors.Add(dir);
            db.SaveChanges();
        }
        public Director Read(int id)
        {
            return db.Directors.FirstOrDefault(a => a.DirectorID == id);
        }
        public IQueryable<Director> ReadAll()
        {
            return db.Directors;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
        public void Update(Director dir)
        {
            var old = Read(dir.DirectorID);
            old.Name = dir.Name;
            old.Gender = dir.Gender;
            old.Age = dir.Age;
            db.SaveChanges();
        }
    }
}