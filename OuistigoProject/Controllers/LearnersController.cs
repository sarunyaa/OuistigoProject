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
    public class LearnersController : ApiController
    {
        private OuistigoProjectContext db = new OuistigoProjectContext();

        // GET: api/Learners
        public IQueryable<Learner> GetLearners()
        {
            return db.Learners;
        }

        // GET: api/Learners/5
        [ResponseType(typeof(Learner))]
        public async Task<IHttpActionResult> GetLearner(int id)
        {
            Learner learner = await db.Learners.FindAsync(id);
            if (learner == null)
            {
                return NotFound();
            }

            return Ok(learner);
        }

        // PUT: api/Learners/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLearner(int id, Learner learner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != learner.IdLearner)
            {
                return BadRequest();
            }

            db.Entry(learner).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearnerExists(id))
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

        // POST: api/Learners
        [ResponseType(typeof(Learner))]
        public async Task<IHttpActionResult> PostLearner(Learner learner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Learners.Add(learner);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = learner.IdLearner }, learner);
        }

        // DELETE: api/Learners/5
        [ResponseType(typeof(Learner))]
        public async Task<IHttpActionResult> DeleteLearner(int id)
        {
            Learner learner = await db.Learners.FindAsync(id);
            if (learner == null)
            {
                return NotFound();
            }

            db.Learners.Remove(learner);
            await db.SaveChangesAsync();

            return Ok(learner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LearnerExists(int id)
        {
            return db.Learners.Count(e => e.IdLearner == id) > 0;
        }
    }
}