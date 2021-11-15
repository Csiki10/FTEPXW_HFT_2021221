using FTEPXW_HFT_2021221.Models;
using FTEPXW_HFT_2021221.Repository;
using System;
using System.Linq;
using System.Collections.Generic;

namespace FTEPXW_HFT_2021221.Logic
{
    public class ProtagonistLogic
    {
        IProtagonistRepository protRep;

        public ProtagonistLogic(IProtagonistRepository protRep)
        {
            this.protRep = protRep;
        }

        // CRUD
        public void Create(Protagonist prot)
        {
            protRep.Create(prot);
        }
        public Protagonist Read(int id)
        {
            return protRep.Read(id);
        }
        public IEnumerable<Protagonist> ReadAll()
        {
            return protRep.ReadAll();
        }
        public void Delete(int id)
        {
            protRep.Delete(id);
        }
        public void Update(Protagonist prot)
        {
            protRep.Update(prot);
        }

        
        // NONCRUD			
        
        public IEnumerable<object> ProtagonistMoviesCount16HanzZimmer()
        {
            var q2 = from x in protRep.ReadAll().SelectMany(t => t.Movies)
                     where x.AgeLimit >= 16 && x.Music == "Hans Zimmer"
                     group x by x.Protagonist.Name into g
                     select new
                     {
                         _NAME = g.Key,
                         _DB = g.Count(),
                         
                     };

            return q2;
        }      
        public IEnumerable<object> ProtagonistMoviesCount()
        {            
            var q2 = from x in protRep.ReadAll().SelectMany(t => t.Movies)
                     group x by x.Protagonist.Name into g
                     select new 
                     {
                         _NAME = g.Key,
                         _DB = g.Count()
                     };
                     
            
            return q2;
        }

    }
}