using PlaceMyBetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBetAPI.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET: api/Usuarios
        public IEnumerable<Usuario> Get()
        {
            var repo = new UsuariosRepository();
            List<Usuario> usuarios = repo.Retrieve();
            return usuarios;
        }

        // GET: api/Usuarios/5
        public List<Usuario> Get(int id)
        {
            return null;
        }

        // GET: api/Usuarios/email=email
        public Usuario GetUserByEmail(string email)
        {
            var repo = new UsuariosRepository();
            Usuario usuario = repo.GetUserByEmail(email);
            return usuario;
        }

        // GET: api/Usuarios?username=username
        public Usuario GetUserByUsername(string username)
        {
            var repo = new UsuariosRepository();
            Usuario usuario = repo.GetUserByUsername(username);
            return usuario;
        }

        // POST: api/Usuarios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuarios/5
        public void Delete(int id)
        {
        }
    }
}
