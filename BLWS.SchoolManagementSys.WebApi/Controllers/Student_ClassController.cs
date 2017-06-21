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
    public class Student_ClassController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Student_Class
        public IQueryable<Student_Class> GetStudent_Class()
        {
            return db.Student_Class;
        }

        // GET: api/Student_Class/5
        [ResponseType(typeof(Student_Class))]
        public IHttpActionResult GetStudent_Class(int id)
        {
            Student_Class student_Class = db.Student_Class.Find(id);
            if (student_Class == null)
            {
                return NotFound();
            }

            return Ok(student_Class);
        }

        // PUT: api/Student_Class/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent_Class(int id, Student_Class student_Class)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student_Class.ID)
            {
                return BadRequest();
            }

            db.Entry(student_Class).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Student_ClassExists(id))
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

        // POST: api/Student_Class
        [ResponseType(typeof(Student_Class))]
        public IHttpActionResult PostStudent_Class(Student_Class student_Class)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Student_Class.Add(student_Class);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student_Class.ID }, student_Class);
        }

        // DELETE: api/Student_Class/5
        [ResponseType(typeof(Student_Class))]
        public IHttpActionResult DeleteStudent_Class(int id)
        {
            Student_Class student_Class = db.Student_Class.Find(id);
            if (student_Class == null)
            {
                return NotFound();
            }

            db.Student_Class.Remove(student_Class);
            db.SaveChanges();

            return Ok(student_Class);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Student_ClassExists(int id)
        {
            return db.Student_Class.Count(e => e.ID == id) > 0;
        }
    }
}