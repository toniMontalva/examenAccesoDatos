﻿using PlaceMyBetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBetAPI.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public IEnumerable<Evento> Get()
        {
            var repo = new EventosRepository();
            //List<Evento> eventos = repo.Retrieve();
            List<Evento> eventos = repo.Retrieve();

            return eventos;
        }

        // GET: api/Eventos/5
        public List<Evento> Get(int id)
        {
            /*var repo = new EventosRepository();
            List<Evento> eventos = repo.Retrieve();

            return eventos;*/
            return null;
        }

        // POST: api/Eventos
        public void Post([FromBody]Evento evento)
        {
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
