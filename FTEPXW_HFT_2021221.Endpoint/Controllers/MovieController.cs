﻿using FTEPXW_HFT_2021221.Endpoint.Services;
using FTEPXW_HFT_2021221.Logic;
using FTEPXW_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;

        public MovieController(IMovieLogic mLog, IHubContext<SignalRHub> hub)
        {
            this.mLog = mLog;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("MovieCreated", value);
        }

        // PUT /movie
        [HttpPut]
        public void Put([FromBody] Movie value)
        {
            mLog.Update(value);
            this.hub.Clients.All.SendAsync("MovieUpdated", value);

        }

        // DELETE /movie/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var movieToDelete = this.mLog.Read(id);
            mLog.Delete(id);
            this.hub.Clients.All.SendAsync("MovieDeleted", movieToDelete);
        }
    }
}
