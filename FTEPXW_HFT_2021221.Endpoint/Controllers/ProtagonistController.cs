using FTEPXW_HFT_2021221.Logic;
using FTEPXW_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FTEPXW_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProtagonistController : ControllerBase
    {
        IProtagonistLogic pLog;

        public ProtagonistController(IProtagonistLogic pLog)
        {
            this.pLog = pLog;

        }

        // GET: /protagonist
        [HttpGet]
        public IEnumerable<Protagonist> Get()
        {
            return pLog.ReadAll();
        }

        // GET protagonist/5
        [HttpGet("{id}")]
        public Protagonist Get(int id)
        {
            return pLog.Read(id);
        }

        // POST /protagonist
        [HttpPost]
        public void Post([FromBody] Protagonist value)
        {
            pLog.Create(value);
        }

        // PUT /protagonist
        [HttpPut]
        public void Put([FromBody] Protagonist value)
        {
            pLog.Update(value);
        }

        // DELETE /protagonist/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pLog.Delete(id);
        }
    }
}
