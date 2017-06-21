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
    public class RolesController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Roles
        public IQueryable<Role> GetRole()
        {
            return db.Role;
        }

        ///// <summary>
        ///// 通过角色ID获取角色的菜单信息
        ///// </summary>
        ///// <param name="id">角色ID</param>
        ///// <returns>角色string</returns>
        //public IHttpActionResult GetRoleMenu(Guid id)
        //{
        //    //获取角色对应的菜单编号
        //    Role_Menu RM = db.Role_Menu.FirstOrDefault(u => u.MenuID == id);
        //    //如果该角色没有菜单
        //    if (RM == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        //如果有菜单，先获取菜单ID
        //        Guid RMI = RM.MenuID;
        //        //通过角色ID获取菜单名称
        //        Menu R = db.Menu.FirstOrDefault(u => u.MenuID == RMI);
        //        if (R == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return Ok(R.MenuName);
        //        }
        //    }

        //}

        /// <summary>
        /// 通过角色ID获取角色的菜单信息
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <returns>角色string</returns>
        public IHttpActionResult GetRoleMenu(Guid id)
        {
            //获取角色对应的菜单编号
            Role_Menu RM = db.Role_Menu.FirstOrDefault(u => u.RoleID == id);
            //如果该角色没有菜单
            if (RM == null)
            {
                return NotFound();
            }
            else
            {
                //如果有菜单，先获取菜单ID
                Guid RMI = RM.MenuID;
                //通过角色ID获取菜单名称
                Menu R = db.Menu.FirstOrDefault(u => u.MenuID == RMI);
                if (R == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(R.MenuName);
                }
            }

        }

        public IQueryable<Menu> getMenusByRole(Guid roleID)
        {
            //用来保存查询结果
            List<Menu> Result=new List<Menu>();
            IQueryable<Role_Menu> MenuList = db.Role_Menu.Where(u => u.RoleID == roleID);
            List<Role_Menu> ML = MenuList.ToList();
            for(int i=0; i< ML.Count();i++)
            {
                Guid menuID = ML[i].MenuID;
                Menu menuResult = db.Menu.FirstOrDefault(u => u.MenuID == menuID);
                Result.Add(menuResult);
            }
            return Result.AsQueryable();
        }




        // GET: api/Roles/5
        [ResponseType(typeof(Role))]
        public IHttpActionResult GetRole(Guid id)
        {
            Role role = db.Role.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PutRole(Guid id, Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.RoleID)
            {
                return BadRequest();
            }

            db.Entry(role).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // POST: api/Roles
        [ResponseType(typeof(Role))]
        public IHttpActionResult PostRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Role.Add(role);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RoleExists(role.RoleID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = role.RoleID }, role);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(Role))]
        [HttpPost]
        public IHttpActionResult DeleteRole(Guid id)
        {
            Role role = db.Role.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            db.Role.Remove(role);
            db.SaveChanges();

            return Ok(role);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoleExists(Guid id)
        {
            return db.Role.Count(e => e.RoleID == id) > 0;
        }
    }
}