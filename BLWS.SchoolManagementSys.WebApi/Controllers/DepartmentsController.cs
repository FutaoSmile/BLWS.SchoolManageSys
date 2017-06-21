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
    public class DepartmentsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Departments
        public IQueryable<Department> GetDepartment()
        {
            return db.Department;
        }
        /// <summary>
        /// 根据院长ID获取学院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetDepByManager(Guid id) {
            return Ok(db.Department.FirstOrDefault(u => u.Dep_ManagerID == id));
        }
        /// <summary>
        /// 根据学院编号获取学院的教师
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetDepTeacher(Guid id) {
          List<Dep_Teacher> DT= db.Dep_Teacher.Where(u => u.Dep_ID == id).ToList();
            List<User> TeacherList = new List<EF.Entity.User>();
            for (int i = 0; i < DT.Count(); i++) {
                Guid tid= DT[i].Teacher_ID;
                User user=  db.User.FirstOrDefault(q => q.UserID == tid);
                if (user != null) {
                    TeacherList.Add(user);
                }
            }
            return Ok(TeacherList);
        }
        [HttpGet]
        public IHttpActionResult All_Dep_Manager()
        {
            List<User> YuanZhang = new List<EF.Entity.User>();
            //获取院长的角色ID
            Guid yuanzhang = db.Role.FirstOrDefault(u => u.RoleName == "院长").RoleID;
            //获取所有院长的用户ID
            List<User_Role> UR = db.User_Role.Where(u => u.RoleID == yuanzhang).ToList();
            for (int i = 0; i < UR.Count(); i++) {
                Guid Current = UR[i].UserID;
                User U= db.User.FirstOrDefault(u => u.UserID == Current);
                if (U != null) {
                    YuanZhang.Add(U);
                }
            }
            return Ok(YuanZhang);
        }

        // GET: api/Departments/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult GetDepartment(Guid id)
        {
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // PUT: api/Departments/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateDepartment(Guid id, Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.DepID)
            {
                return BadRequest();
            }

            db.Entry(department).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST: api/Departments
        [ResponseType(typeof(Department))]
        [HttpPost]
        public IHttpActionResult AddDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Department.Add(department);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DepartmentExists(department.DepID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = department.DepID }, department);
        }

        // DELETE: api/Departments/5
        [ResponseType(typeof(Department))]
        [HttpPost]
        public IHttpActionResult DeleteDepartment(Guid id)
        {
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            db.Department.Remove(department);
            db.SaveChanges();

            return Ok(department);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentExists(Guid id)
        {
            return db.Department.Count(e => e.DepID == id) > 0;
        }
    }
}