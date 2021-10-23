using FTEPXW_HFT_2021221.Models;
using FTEPXW_HFT_2021221.Repository;
using System;
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
    }
}