using FTEPXW_HFT_2021221.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTEPXW_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IMovieLogic ml;

        public StatController(IMovieLogic ml)
        {
            this.ml = ml;
        }

        // GET: /stat/protagonistGroup
        [HttpGet]
        public IEnumerable<object> ProtagonistGroup()
        {
            return ml.ProtagonistGroup();
        }

        // GET: /stat/protagonistAgeGroup
        [HttpGet]
        public IEnumerable<object> ProtagonistAgeGroup()
        {
            return ml.ProtagonistAgeGroup();
        }

        // GET: /stat/directorGroup
        [HttpGet]
        public IEnumerable<object> DirectorGroup()
        {
            return ml.DirectorGroup();
        }

        // GET: /stat/genre
        [HttpGet]
        public IEnumerable<object> Genre()
        {
            return ml.Genre();
        }

        // GET: /stat/directorGenderGroup
        [HttpGet]
        public IEnumerable<object> DirectorGenderGroup()
        {
            return ml.DirectorGenderGroup();
        }
    }
}
