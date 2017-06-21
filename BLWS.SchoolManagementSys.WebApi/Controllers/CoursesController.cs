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
    public class CoursesController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Courses
        public IQueryable<Course> GetCourse()
        {
            return db.Course;
        }
        /// <summary>
        /// 根据院长的ID得到学院的课程
        /// </summary>
        /// <param name="id">院长id</param>
        /// <returns>课程列表</returns>
        [HttpGet]
        public IHttpActionResult GetCourseByDepManagerID(Guid id)
        {
           Guid DepID= db.Department.FirstOrDefault(u => u.Dep_ManagerID == id).DepID;
            return Ok( db.Course.Where(q => q.DepID == DepID));
        }

        // GET: api/Courses/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult GetCourse(Guid? id)
        {
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }
        /// <summary>
        /// 根据院长ID获取该学院的教师
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetTeacherByDepManagerID(Guid id) {
            List<User> TeacherList = new List<EF.Entity.User>();
            Guid DepID=  db.Department.FirstOrDefault(u => u.Dep_ManagerID == id).DepID;
          List<Dep_Teacher> DT= db.Dep_Teacher.Where(q => q.Dep_ID == DepID).ToList();
            for (int i = 0; i < DT.Count(); i++) {
                Guid UserID = DT[i].Teacher_ID;
                User user = db.User.FirstOrDefault(w => w.UserID == UserID);
                if (user != null) {
                    TeacherList.Add(user);
                }
            }
            return Ok(TeacherList);
        }

        // PUT: api/Courses/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PutCourse(Guid id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.CourseID)
            {
                return BadRequest();
            }

            db.Entry(course).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        [ResponseType(typeof(Course))]
        public IHttpActionResult PostCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Course.Add(course);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CourseExists(course.CourseID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = course.CourseID }, course);
        }

        // DELETE: api/Courses/5
        [ResponseType(typeof(Course))]
        [HttpPost]
        public IHttpActionResult DeleteCourse(Guid id)
        {
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            db.Course.Remove(course);
            db.SaveChanges();

            return Ok(course);
        }
        [HttpGet]
        public IHttpActionResult EditCourse(Guid DepID )
        {
            //如果该用户已经有学院ID就进行更改
            if (db.Course.Count(u => u.DepID == DepID) > 0)
            {
                Course course = db.Course.FirstOrDefault(u => u.DepID == DepID);
                course.DepID = DepID;
                db.SaveChanges();
                return Ok();
            }
            //如果该用户没有角色就进行添加
            else {
                Course course = new Course();
                course.DepID = DepID;

                db.Course.Add(course);
                db.SaveChanges();
                return Ok();
            }

        }
        [HttpGet]
        public IHttpActionResult EditTeacher(string TeacherName)
        {
            //如果该用户已经有学院ID就进行更改
            if (db.Course.Count(u => u.TeacherName == TeacherName) > 0)
            {
                Course course = db.Course.FirstOrDefault(u => u.TeacherName == TeacherName);
                course.TeacherName = TeacherName;
                db.SaveChanges();
                return Ok();
            }
            //如果该用户没有角色就进行添加
            else {
                Course course = new Course();
                course.TeacherName = TeacherName;

                db.Course.Add(course);
                db.SaveChanges();
                return Ok();
            }

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseExists(Guid id)
        {
            return db.Course.Count(e => e.CourseID == id) > 0;
        }
    }
}