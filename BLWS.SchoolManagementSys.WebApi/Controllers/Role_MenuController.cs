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
    public class Role_MenuController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Role_Menu
        public IQueryable<Role_Menu> GetRole_Menu()
        {
            return db.Role_Menu;
        }

        // GET: api/Role_Menu/5
        [ResponseType(typeof(Role_Menu))]
        public IHttpActionResult GetRole_Menu(int id)
        {
            Role_Menu role_Menu = db.Role_Menu.Find(id);
            if (role_Menu == null)
            {
                return NotFound();
            }

            return Ok(role_Menu);
        }

        //根据角色获取菜单
        [HttpGet]
        public IQueryable<Role_Menu> GetRole_MenuByRole(Guid id)
        {
           return db.Role_Menu.Where(u => u.RoleID == id);
           //return db.Role_Menu.SqlQuery("select * from Role_Menu where RoleID=@Roleid",id).AsQueryable();
           
        }

        // PUT: api/Role_Menu/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRole_Menu(int id, Role_Menu role_Menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role_Menu.Role_Menu_ID)
            {
                return BadRequest();
            }

            db.Entry(role_Menu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Role_MenuExists(id))
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

        [HttpGet]
        public IHttpActionResult EditRoleMenu(Guid RoleID, Guid MenuID)
        {
            //如果该用户已经拥有该菜单
            if (db.Role_Menu.Where(u => u.RoleID == RoleID && u.MenuID== MenuID).Count()>0)
            {
                return NotFound();
            }
            //如果该用户没有菜单就进行添加
            else
            {
                Role_Menu RM = new Role_Menu();
                RM.RoleID = RoleID;
                RM.MenuID = MenuID;
                db.Role_Menu.Add(RM);
                db.SaveChanges();
                return Ok();
            }
        }

        /// <summary>
        /// 删除角色的某个菜单
        /// </summary>
        /// <param name="RoleID">角色编号</param>
        /// <param name="MenuID">菜单编号</param>
        /// <returns>删除结果</returns>
        [HttpGet]
        public IHttpActionResult DeleteRoleMenu(Guid RoleID ,Guid MenuID)
        {
            Role_Menu role_Menu = db.Role_Menu.FirstOrDefault(u=>u.RoleID==RoleID && u.MenuID==MenuID);
            if (role_Menu == null)
            {
                return NotFound();
            }

            db.Role_Menu.Remove(role_Menu);
            db.SaveChanges();

            return Ok(role_Menu);
        }

        // POST: api/Role_Menu
        [ResponseType(typeof(Role_Menu))]
        public IHttpActionResult PostRole_Menu(Role_Menu role_Menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Role_Menu.Add(role_Menu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = role_Menu.Role_Menu_ID }, role_Menu);
        }

        // DELETE: api/Role_Menu/5
        [ResponseType(typeof(Role_Menu))]
        public IHttpActionResult DeleteRole_Menu(int id)
        {
            Role_Menu role_Menu = db.Role_Menu.Find(id);
            if (role_Menu == null)
            {
                return NotFound();
            }

            db.Role_Menu.Remove(role_Menu);
            db.SaveChanges();

            return Ok(role_Menu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Role_MenuExists(int id)
        {
            return db.Role_Menu.Count(e => e.Role_Menu_ID == id) > 0;
        }
    }
}