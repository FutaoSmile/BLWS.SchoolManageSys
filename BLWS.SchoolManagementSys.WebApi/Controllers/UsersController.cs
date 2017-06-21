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
    public class UsersController : ApiController
    {
        private MyDbContext db = new MyDbContext();
        Role role = new Role();
        User_Role userrole=new User_Role();
        // GET: api/Users
        public IQueryable<User> GetUser()
        {
            return db.User;
        }
        public IHttpActionResult GetTeacher()
        {
            // User user = new User();
            // //role.RoleName = "教师";

            // role = db.Role.Find(role.RoleName == "教师");
            //userrole = db.User_Role.Find(userrole.RoleID == role.RoleID);
            //User user1 = db.User.Find(user.UserID==userrole.UserID);
            // return Ok(user1);
            //获取教师对应的角色信息（教师RoleID）


            List<User> TeacherList = new List<EF.Entity.User>();
            Role TeacherRole = db.Role.FirstOrDefault(u => u.RoleName == "教师");//获取Role表name为教师的数据
            Guid id = TeacherRole.RoleID;
            List<User_Role> TeacherRoleList = db.User_Role.Where(u => u.RoleID == id).ToList();//
            for (int i =0; i < TeacherRoleList.Count(); i++) {
                Guid UserID = TeacherRoleList[i].UserID;
               User user=db.User.Find(UserID);
                if (user != null) {
                    TeacherList.Add(user);
                }
            }
            return Ok(TeacherList.AsQueryable());
        }
        /// <summary>
        /// 通过用户ID获取用户的角色信息
        /// </summary>
        /// <param name="id">用ID</param>
        /// <returns>角色string</returns>
        public IHttpActionResult GetUserRole(Guid id)
        {
            //获取用户对应的角色编号
            User_Role UR = db.User_Role.FirstOrDefault(u => u.UserID == id);
            //如果该用户没有角色
            if (UR == null)
            {
                return NotFound();
            }
            else
            {
                //如果有角色，先获取角色ID
                Guid URI = UR.RoleID;
                //通过角色ID获取角色名称
                Role R = db.Role.FirstOrDefault(u => u.RoleID == URI);
                if (R == null)
                {
                   return NotFound();
                }
                else
                {
                    return Ok(R.RoleName);
                }
            }

        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(Guid id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public IHttpActionResult Login(string UserName, string Pwd)
        {
            User user = db.User.First(u => u.UserName == UserName && u.Password == Pwd);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateUser(Guid id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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
        [HttpPost]
        public IHttpActionResult AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User.Add(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        [HttpPost]
        public IHttpActionResult DeleteUser(Guid id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.User.Remove(user);
            db.SaveChanges();

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

        private bool UserExists(Guid id)
        {
            return db.User.Count(e => e.UserID == id) > 0;
        }
    }
}