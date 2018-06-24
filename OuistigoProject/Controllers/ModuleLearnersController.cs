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
using System.Web.Http.Description;
using OuistigoProject.Models;

namespace OuistigoProject.Controllers
{
    public class ModuleLearnersController : ApiController
    {
        private OuistigoProjectContext db = new OuistigoProjectContext();

        // GET: api/ModuleLearners
        public IQueryable<ModuleLearner> GetModuleLearner()
        {
            return db.ModuleLearner;
        }

        // GET: api/ModuleLearners/5
        [ResponseType(typeof(ModuleLearner))]
        public async Task<IHttpActionResult> GetModuleLearner(int id)
        {
            ModuleLearner moduleLearner = await db.ModuleLearner.FindAsync(id);
            if (moduleLearner == null)
            {
                return NotFound();
            }

            return Ok(moduleLearner);
        }

        // PUT: api/ModuleLearners/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModuleLearner(int id, ModuleLearner moduleLearner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != moduleLearner.IdModuleLearner)
            {
                return BadRequest();
            }

            db.Entry(moduleLearner).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleLearnerExists(id))
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

        // POST: api/ModuleLearners
        [ResponseType(typeof(ModuleLearner))]
        public async Task<IHttpActionResult> PostModuleLearner(ModuleLearner moduleLearner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ModuleLearner.Add(moduleLearner);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = moduleLearner.IdModuleLearner }, moduleLearner);
        }

        // DELETE: api/ModuleLearners/5
        [ResponseType(typeof(ModuleLearner))]
        public async Task<IHttpActionResult> DeleteModuleLearner(int id)
        {
            ModuleLearner moduleLearner = await db.ModuleLearner.FindAsync(id);
            if (moduleLearner == null)
            {
                return NotFound();
            }

            db.ModuleLearner.Remove(moduleLearner);
            await db.SaveChangesAsync();

            return Ok(moduleLearner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModuleLearnerExists(int id)
        {
            return db.ModuleLearner.Count(e => e.IdModuleLearner == id) > 0;
        }
    }
}