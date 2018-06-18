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
    public class MarksController : ApiController
    {
        private OuistigoProjectContext db = new OuistigoProjectContext();

        // GET: api/Marks
        public IQueryable<Mark> GetMarks()
        {
            return db.Marks;
        }

        // GET: api/Marks/5
        [ResponseType(typeof(Mark))]
        public async Task<IHttpActionResult> GetMark(int id)
        {
            Mark mark = await db.Marks.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }

            return Ok(mark);
        }

        // PUT: api/Marks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMark(int id, Mark mark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mark.IdMark)
            {
                return BadRequest();
            }

            db.Entry(mark).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkExists(id))
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

        // POST: api/Marks
        [ResponseType(typeof(Mark))]
        public async Task<IHttpActionResult> PostMark(Mark mark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Marks.Add(mark);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mark.IdMark }, mark);
        }

        // DELETE: api/Marks/5
        [ResponseType(typeof(Mark))]
        public async Task<IHttpActionResult> DeleteMark(int id)
        {
            Mark mark = await db.Marks.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }

            db.Marks.Remove(mark);
            await db.SaveChangesAsync();

            return Ok(mark);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarkExists(int id)
        {
            return db.Marks.Count(e => e.IdMark == id) > 0;
        }
    }
}