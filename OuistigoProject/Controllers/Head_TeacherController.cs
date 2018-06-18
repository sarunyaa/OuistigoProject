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
    public class Head_TeacherController : ApiController
    {
        private OuistigoProjectContext db = new OuistigoProjectContext();

        // GET: api/Head_Teacher
        public IQueryable<Head_Teacher> GetHead_Teacher()
        {
            return db.Head_Teacher;
        }

        // GET: api/Head_Teacher/5
        [ResponseType(typeof(Head_Teacher))]
        public async Task<IHttpActionResult> GetHead_Teacher(int id)
        {
            Head_Teacher head_Teacher = await db.Head_Teacher.FindAsync(id);
            if (head_Teacher == null)
            {
                return NotFound();
            }

            return Ok(head_Teacher);
        }

        // PUT: api/Head_Teacher/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHead_Teacher(int id, Head_Teacher head_Teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != head_Teacher.IdHead_Teacher)
            {
                return BadRequest();
            }

            db.Entry(head_Teacher).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Head_TeacherExists(id))
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

        // POST: api/Head_Teacher
        [ResponseType(typeof(Head_Teacher))]
        public async Task<IHttpActionResult> PostHead_Teacher(Head_Teacher head_Teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Head_Teacher.Add(head_Teacher);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = head_Teacher.IdHead_Teacher }, head_Teacher);
        }

        // DELETE: api/Head_Teacher/5
        [ResponseType(typeof(Head_Teacher))]
        public async Task<IHttpActionResult> DeleteHead_Teacher(int id)
        {
            Head_Teacher head_Teacher = await db.Head_Teacher.FindAsync(id);
            if (head_Teacher == null)
            {
                return NotFound();
            }

            db.Head_Teacher.Remove(head_Teacher);
            await db.SaveChangesAsync();

            return Ok(head_Teacher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Head_TeacherExists(int id)
        {
            return db.Head_Teacher.Count(e => e.IdHead_Teacher == id) > 0;
        }
    }
}