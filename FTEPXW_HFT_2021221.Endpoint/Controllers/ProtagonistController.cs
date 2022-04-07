using FTEPXW_HFT_2021221.Endpoint.Services;
using FTEPXW_HFT_2021221.Logic;
using FTEPXW_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;
        public ProtagonistController(IProtagonistLogic pLog, IHubContext<SignalRHub> hub)
        {
            this.pLog = pLog;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("ProtagonistCreated", value);
        }

        // PUT /protagonist
        [HttpPut]
        public void Put([FromBody] Protagonist value)
        {
            pLog.Update(value);
            this.hub.Clients.All.SendAsync("ProtagonistUpdated", value);
        }

        // DELETE /protagonist/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var protagonistToDelete = this.pLog.Read(id);
            pLog.Delete(id);
            this.hub.Clients.All.SendAsync("ProtagonistDeleted", protagonistToDelete);
        }
    }
}
