using PlaceMyBetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBetAPI.Controllers
{
    public class ApuestasController : ApiController
    {
        // Ejercicio 2
        // GET: api/Apuestas?mercadoId=value
        public IEnumerable<Apuesta> GetApuestasDesdeMercadoId(int mercadoId)
        {
            var repo = new ApuestasRepository();
            List<Apuesta> apuestasFiltro = repo.GetApuestasMercadoIdConFiltro(mercadoId);

            return apuestasFiltro;
        }

        // GET: api/Apuestas
        public IEnumerable<Apuesta> Get()
        {
            var repo = new ApuestasRepository();
            //List<Apuesta> apuestas = repo.Retrieve();
            List<Apuesta> apuestas = repo.Retrieve();

            return apuestas;
        }

        // GET: api/Apuestas/5
        public List<Apuesta> Get(int id)
        {
            return null;
        }

        // GET: api/Apuestas?email=valor
        public IEnumerable<Apuesta> GetApuestas(string email)
        {
            var repo = new ApuestasRepository();
            var repoUser = new UsuariosRepository();
            List<Usuario> usuarios = repoUser.Retrieve();

            List<Apuesta> apuestas = repo.ObtenerApuestasPorEmailQuery(email, usuarios);

            return apuestas;
        }

        // GET: api/Apuestas?merId=valor
        [Authorize(Roles ="admin")]
        public IEnumerable<Apuesta> GetApuestasPorMercadoId(int merId)
        {
            var repo = new ApuestasRepository();

            List<Apuesta> apuestas = repo.ObtenerApuestasPorMercadoIdQuery(merId);        
            return apuestas;
        }

        // POST: api/Apuestas
        [Authorize]
        public String Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestasRepository();
            repo.Save(apuesta);
            /*var repoUpdate = new MercadosRepository();
            repoUpdate.UpdateMercadoExistente(apuesta.MercadoId, apuesta);*/

            // EJERCICIO 3
            var repoUsuario = new UsuariosRepository();
            int apuestasUsuario = repoUsuario.CuantasApuestasTieneElUsuario(apuesta.UsuarioId);
            return GetMessage(apuestasUsuario);
        }

        // EJERCICIO 3
        public String GetMessage(int apuestas)
        {
            return "El usuario tiene " + apuestas + " apuestas actualmente.";
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
