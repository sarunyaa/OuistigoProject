using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using OuistigoProject.Models;

namespace OuistigoProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SecretariatsController : ApiController
    {
        private OuistigoProjectContext db = new OuistigoProjectContext();

        // GET: api/Secretariats
        public IQueryable<Secretariat> GetSecretariats()
        {
            return db.Secretariats;
        }

        // GET: api/Secretariats/5
        [ResponseType(typeof(Secretariat))]
        public async Task<IHttpActionResult> GetSecretariat(int id)
        {
            Secretariat secretariat = await db.Secretariats.FindAsync(id);
            if (secretariat == null)
            {
                return NotFound();
            }

            return Ok(secretariat);
        }

        // PUT: api/Secretariats/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSecretariat(int id, Secretariat secretariat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != secretariat.Id_secretariat)
            {
                return BadRequest();
            }

            db.Entry(secretariat).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecretariatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Secretariats
        [ResponseType(typeof(Secretariat))]
        public async Task<IHttpActionResult> PostSecretariat(Secretariat secretariat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Secretariats.Add(secretariat);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = secretariat.Id_secretariat }, secretariat);
        }

        // DELETE: api/Secretariats/5
        [ResponseType(typeof(Secretariat))]
        public async Task<IHttpActionResult> DeleteSecretariat(int id)
        {
            Secretariat secretariat = await db.Secretariats.FindAsync(id);
            if (secretariat == null)
            {
                return NotFound();
            }

            db.Secretariats.Remove(secretariat);
            await db.SaveChangesAsync();

            return Ok(secretariat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SecretariatExists(int id)
        {
            return db.Secretariats.Count(e => e.Id_secretariat == id) > 0;
        }
    }
}