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
    public class Live_MeetingController : ApiController
    {
        private OuistigoProjectContext db = new OuistigoProjectContext();

        // GET: api/Live_Meeting
        public IQueryable<Live_Meeting> GetLive_Meeting()
        {
            return db.Live_Meeting;
        }

        // GET: api/Live_Meeting/5
        [ResponseType(typeof(Live_Meeting))]
        public async Task<IHttpActionResult> GetLive_Meeting(int id)
        {
            Live_Meeting live_Meeting = await db.Live_Meeting.FindAsync(id);
            if (live_Meeting == null)
            {
                return NotFound();
            }

            return Ok(live_Meeting);
        }

        // PUT: api/Live_Meeting/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLive_Meeting(int id, Live_Meeting live_Meeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != live_Meeting.IdLive_Meeting)
            {
                return BadRequest();
            }

            db.Entry(live_Meeting).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Live_MeetingExists(id))
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

        // POST: api/Live_Meeting
        [ResponseType(typeof(Live_Meeting))]
        public async Task<IHttpActionResult> PostLive_Meeting(Live_Meeting live_Meeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Live_Meeting.Add(live_Meeting);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = live_Meeting.IdLive_Meeting }, live_Meeting);
        }

        // DELETE: api/Live_Meeting/5
        [ResponseType(typeof(Live_Meeting))]
        public async Task<IHttpActionResult> DeleteLive_Meeting(int id)
        {
            Live_Meeting live_Meeting = await db.Live_Meeting.FindAsync(id);
            if (live_Meeting == null)
            {
                return NotFound();
            }

            db.Live_Meeting.Remove(live_Meeting);
            await db.SaveChangesAsync();

            return Ok(live_Meeting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Live_MeetingExists(int id)
        {
            return db.Live_Meeting.Count(e => e.IdLive_Meeting == id) > 0;
        }
    }
}