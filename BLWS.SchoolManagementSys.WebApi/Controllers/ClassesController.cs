using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLWS.SchoolManagementSys.EF.Context;
using BLWS.SchoolManagementSys.EF.Entity;

namespace BLWS.SchoolManagementSys.WebApi.Controllers
{
    public class ClassesController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Classes
        public IQueryable<Classes> GetClasses()
        {
            return db.Classes;
        }

        // GET: api/Classes/5
        [ResponseType(typeof(Classes))]
        public IHttpActionResult GetClasses(Guid id)
        {
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return NotFound();
            }

            return Ok(classes);
        }

        // PUT: api/Classes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClasses(Guid id, Classes classes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classes.ClassID)
            {
                return BadRequest();
            }

            db.Entry(classes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassesExists(id))
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

        // POST: api/Classes
        [ResponseType(typeof(Classes))]
        public IHttpActionResult PostClasses(Classes classes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Classes.Add(classes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClassesExists(classes.ClassID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = classes.ClassID }, classes);
        }

        // DELETE: api/Classes/5
        [ResponseType(typeof(Classes))]
        public IHttpActionResult DeleteClasses(Guid id)
        {
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return NotFound();
            }

            db.Classes.Remove(classes);
            db.SaveChanges();

            return Ok(classes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassesExists(Guid id)
        {
            return db.Classes.Count(e => e.ClassID == id) > 0;
        }
    }
}