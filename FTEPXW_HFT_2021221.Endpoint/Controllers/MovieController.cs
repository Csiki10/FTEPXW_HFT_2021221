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
    public class MovieController : ControllerBase
    {
        IMovieLogic mLog;

        public MovieController(IMovieLogic mLog)
        {
            this.mLog = mLog;
        }

        // GET: /movie
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return mLog.ReadAll();
        }

        // GET /movie/4
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return mLog.Read(id);
        }

        // POST /movie
        [HttpPost]
        public void Post([FromBody] Movie value)
        {
            mLog.Create(value);
        }

        // PUT /movie
        [HttpPut]
        public void Put([FromBody] Movie value)
        {
            mLog.Update(value);

        }

        // DELETE /movie/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            mLog.Delete(id);
        }
    }
}
