using FTEPXW_HFT_2021221.Logic;
using FTEPXW_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FTEPXW_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        IDirectorLogic dLog;

        public DirectorController(IDirectorLogic dLog)
        {
            this.dLog = dLog;
        }


        // GET: /director
        [HttpGet]
        public IEnumerable<Director> Get()
        {
            return dLog.ReadAll();
        }

        // GET a/director/5
        [HttpGet("{id}")]
        public Director Get(int id)
        {
            return dLog.Read(id);
        }

        // POST /director
        [HttpPost]
        public void Post([FromBody] Director value)
        {
            dLog.Create(value);
        }

        // PUT a/director/5
        [HttpPut]
        public void Put([FromBody] Director value)
        {
            dLog.Update(value);
        }

        // DELETE /director/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dLog.Delete(id);
        }
    }
}
