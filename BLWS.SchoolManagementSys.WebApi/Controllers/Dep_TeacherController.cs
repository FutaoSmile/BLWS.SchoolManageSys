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
    public class Dep_TeacherController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Dep_Teacher
        public IQueryable<Dep_Teacher> GetDep_Teacher()
        {
            return db.Dep_Teacher;
        }

        // GET: api/Dep_Teacher/5
        [ResponseType(typeof(Dep_Teacher))]
        public IHttpActionResult GetDep_Teacher(int id)
        {
            Dep_Teacher dep_Teacher = db.Dep_Teacher.Find(id);
            if (dep_Teacher == null)
            {
                return NotFound();
            }

            return Ok(dep_Teacher);
        }

        // PUT: api/Dep_Teacher/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDep_Teacher(int id, Dep_Teacher dep_Teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dep_Teacher.ID)
            {
                return BadRequest();
            }

            db.Entry(dep_Teacher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Dep_TeacherExists(id))
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
        /// <summary>
        /// 教师VM
        /// </summary>
        class TeacherVM {
            public Guid UserID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string NamePinYin { get; set; }
            public string Tel { get; set; }
            public string Email { get; set; }
            public DateTime CreateTime { get; set; }


            public Guid DepID { get; set; }

        }
        /// <summary>
        /// 添加学院教师
        /// </summary>
        /// <param name="user">教师信息</param>
        /// <param name="id">学院编号</param>
        /// <returns></returns>
        // POST: api/Dep_Teacher
        [HttpPost]
        [ResponseType(typeof(Dep_Teacher))]
        public IHttpActionResult PostDep_Teacher(User user,Guid id)
        {
            //1.先添加该教师到用户表
            db.User.Add(user);
            //2.添加角色信息
            Guid TeacherRoleID= db.Role.FirstOrDefault(u => u.RoleName == "教师").RoleID;
            User_Role UR = new User_Role();
            UR.RoleID = TeacherRoleID;
            UR.UserID = user.UserID;
            db.User_Role.Add(UR);

            //将这个教师添加到软件学院
            Dep_Teacher dep_Teacher = new Dep_Teacher();
            dep_Teacher.Dep_ID = id;
            dep_Teacher.Dep_Name = db.Department.FirstOrDefault(u => u.DepID == id).DepName;
            dep_Teacher.Teacher_ID = user.UserID;
            dep_Teacher.Teacher_Name = user.UserName;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dep_Teacher.Add(dep_Teacher);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dep_Teacher.ID }, dep_Teacher);
        }

        // DELETE: api/Dep_Teacher/5
        [ResponseType(typeof(Dep_Teacher))]
        public IHttpActionResult DeleteDep_Teacher(int id)
        {
            Dep_Teacher dep_Teacher = db.Dep_Teacher.Find(id);
            if (dep_Teacher == null)
            {
                return NotFound();
            }

            db.Dep_Teacher.Remove(dep_Teacher);
            db.SaveChanges();

            return Ok(dep_Teacher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Dep_TeacherExists(int id)
        {
            return db.Dep_Teacher.Count(e => e.ID == id) > 0;
        }
    }
}