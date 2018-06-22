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
    public class UsersController : ApiController
    {
        private OuistigoProjectContext db = new OuistigoProjectContext();

        // GET: api/Users
       // [HttpGet]
        public IQueryable<User> GetUsers()
        {

            return db.Users;
        }
        
        

        //[ResponseType(typeof(User))]
        [HttpGet, Route("/test")]
        public async Task<IHttpActionResult> GetUsers (string param)

        {
            if (param == "apprenant" || param=="tuteur" || param == "secretaire" || param == "secretariat" || param == "service formation continue")
            {
                var result = db.Users.Where(x => x.Role == param);
                return Ok(result);
            }

            User user = await db.Users.FindAsync(param);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }
        [HttpGet, Route("/connexion")]
        public async Task<IHttpActionResult> GetUsers(string login, string mdp)

        {
            var result = db.Users.Where(x => x.Id_connexion == login && x.Mdp == mdp);
            if (result == null)
            {
                return NotFound();
               
            }
            return Ok(result);
        }


        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.IdUser)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(DAO.InscriptionObject Io)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DateTime d = DateTime.Now;
            Console.WriteLine(Io.Name+"test");
            Console.WriteLine(Io.FirstName + "test2");
            User user = new User
            {
                FirstName = Io.FirstName,
                Id_connexion = Io.Id_connexion,
                Mail_adress = Io.Mail_adress,
                Name = Io.Name,
                Phone_number = Io.Phone_number,
                Role = Io.Role,
                Statut_connexion = Io.Statut_connexion,
                Date_last_connexion = d,
                Time_last_connexion = d,
                Mdp = Io.Mdp
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.IdUser }, user);
        }





        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.IdUser == id) > 0;
        }
    }
}