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
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class Formation_UnitController : ApiController
    {
        private OuistigoProjectContext db = new OuistigoProjectContext();

        // GET: api/Formation_Unit
        public IQueryable<Formation_Unit> GetFormation_Unit()
        {
            return db.Formation_Unit;
        }

        // GET: api/Formation_Unit/5
        [ResponseType(typeof(Formation_Unit))]
        public async Task<IHttpActionResult> GetFormation_Unit(int id)
        {
            Formation_Unit formation_Unit = await db.Formation_Unit.FindAsync(id);
            if (formation_Unit == null)
            {
                return NotFound();
            }

            return Ok(formation_Unit);
        }

        // PUT: api/Formation_Unit/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFormation_Unit(int id, Formation_Unit formation_Unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != formation_Unit.IdFormation_unit)
            {
                return BadRequest();
            }

            db.Entry(formation_Unit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Formation_UnitExists(id))
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

        // POST: api/Formation_Unit
        [ResponseType(typeof(Formation_Unit))]
        public async Task<IHttpActionResult> PostFormation_Unit(Formation_Unit formation_Unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Formation_Unit.Add(formation_Unit);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = formation_Unit.IdFormation_unit }, formation_Unit);
        }

        // DELETE: api/Formation_Unit/5
        [ResponseType(typeof(Formation_Unit))]
        public async Task<IHttpActionResult> DeleteFormation_Unit(int id)
        {
            Formation_Unit formation_Unit = await db.Formation_Unit.FindAsync(id);
            if (formation_Unit == null)
            {
                return NotFound();
            }

            db.Formation_Unit.Remove(formation_Unit);
            await db.SaveChangesAsync();

            return Ok(formation_Unit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Formation_UnitExists(int id)
        {
            return db.Formation_Unit.Count(e => e.IdFormation_unit == id) > 0;
        }
    }
}