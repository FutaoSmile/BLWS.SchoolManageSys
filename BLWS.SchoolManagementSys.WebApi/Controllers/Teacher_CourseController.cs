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
    public class Teacher_CourseController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Teacher_Course
        public IQueryable<Teacher_Course> GetTeacher_Course()
        {
            return db.Teacher_Course;
        }

        // GET: api/Teacher_Course/5
        [ResponseType(typeof(Teacher_Course))]
        public IHttpActionResult GetTeacher_Course(int id)
        {
            Teacher_Course teacher_Course = db.Teacher_Course.Find(id);
            if (teacher_Course == null)
            {
                return NotFound();
            }

            return Ok(teacher_Course);
        }

        // PUT: api/Teacher_Course/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeacher_Course(int id, Teacher_Course teacher_Course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teacher_Course.Teacher_Course_ID)
            {
                return BadRequest();
            }

            db.Entry(teacher_Course).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Teacher_CourseExists(id))
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

        // POST: api/Teacher_Course
        [ResponseType(typeof(Teacher_Course))]
        public IHttpActionResult PostTeacher_Course(Teacher_Course teacher_Course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teacher_Course.Add(teacher_Course);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teacher_Course.Teacher_Course_ID }, teacher_Course);
        }

        // DELETE: api/Teacher_Course/5
        [ResponseType(typeof(Teacher_Course))]
        public IHttpActionResult DeleteTeacher_Course(int id)
        {
            Teacher_Course teacher_Course = db.Teacher_Course.Find(id);
            if (teacher_Course == null)
            {
                return NotFound();
            }

            db.Teacher_Course.Remove(teacher_Course);
            db.SaveChanges();

            return Ok(teacher_Course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Teacher_CourseExists(int id)
        {
            return db.Teacher_Course.Count(e => e.Teacher_Course_ID == id) > 0;
        }
    }
}