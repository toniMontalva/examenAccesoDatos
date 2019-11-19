using PlaceMyBetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBetAPI.Controllers
{
    public class LeaguesController : ApiController
    {
        // Ejercicio 1

        // GET: api/Leagues
        public IEnumerable<Leagues> Get()
        {
            var repo = new LeagueRepository();            
            List<Leagues> ligas = repo.Retrieve();
            return ligas;
        }

        // GET: api/Leagues/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Leagues
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Leagues/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Leagues/5
        public void Delete(int id)
        {
        }
    }
}
