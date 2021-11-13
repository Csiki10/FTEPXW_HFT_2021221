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

        // TODO
        // NONCRUD			
        
        public IQueryable Oszcar()
        {
            // var oscaros= protRep.ReadAll().Where(p => p.Oscar);
            

            var q2 = from x in protRep.ReadAll()
                     group x by x.Movies into g
                     select new
                     {
                         _NAME = g.Key,
                         _COUNT = g.Sum(t => t.ProtagonistID)
                     };
            return q2;
        }

        public IQueryable TobbFilmesFerfiKor()
        {
            // var q1 = protRep.ReadAll().Where(p => p.Age > 20).Where(k => k.Gender =="férfi").Sum(t => t.Movies.Count);
            var q2 = from x in protRep.ReadAll()
                     where x.Age > 20 && x.Gender == "man" && x.Movies.Count > 1
                     select new
                     {
                         _NAME = x.Name,
                         _MOVIECOUNT = x.Movies.Count

                     };

            return q2;
        }
        	
    }
}