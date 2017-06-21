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
    public class MenusController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Menus
        public IQueryable<Menu> GetMenu()
        {
            return db.Menu.OrderBy(u => u.OrderNum);

        }

        /// <summary>
        /// 根据用户信息从数据库动态生成菜单
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pid">一级菜单父节点ID</param>
        /// <returns>菜单拼接成的字符串</returns>
        [HttpGet]
        public IHttpActionResult Menu(Guid id, string pid)
        {
            //得到用户角色
            User_Role user_Role = db.User_Role.First(u => u.UserID == id);
            Guid str1 = user_Role.RoleID;
            //获取角色菜单
            List<Role_Menu> role_Menu = db.Role_Menu.Where(u => u.RoleID == str1).ToList();

            var FirstMenu = "";
            //获取所有菜单
            List<Menu> Menu_One = db.Menu.OrderBy(u => u.OrderNum).ToList();
            //遍历菜单
            for (int i = 0; i < Menu_One.Count; i++)
            {
                //如果是一级菜单
                if (Menu_One[i].ParentMenuID.ToString() == pid)
                {
                    //遍历用户拥有的菜单
                    for (int j = 0; j < role_Menu.Count; j++)
                    {
                        if (Menu_One[i].MenuID == role_Menu[j].MenuID)
                        {
                            //生成一级菜单
                            FirstMenu += "<li id='Menu_" + i + "'" +
                            "><a";
                            //如果当前一级菜单有子菜单
                            Guid str2 = Menu_One[i].MenuID;
                            if (db.Menu.Where(u => u.ParentMenuID == str2).OrderByDescending(u => u.OrderNum).Count() != 0)
                            {
                                FirstMenu += "><i class='fa fa-home'></i>" + Menu_One[i].MenuName +
                                                   "<span class='fa fa-chevron-down'></span></a><ul class='nav child_menu'>";
                                //遍历所有菜单
                                for (int item = 0; item < Menu_One.Count; item++)
                                {
                                    if (Menu_One[item].ParentMenuID == Menu_One[i].MenuID)
                                    {
                                        //遍历用户拥有的菜单
                                        for (int item1 = 0; item1 < role_Menu.Count; item1++)
                                        {
                                            //如果用户拥有权限
                                            if (role_Menu[item1].MenuID == Menu_One[item].MenuID)
                                            {
                                                FirstMenu += "<li><a href='" + Menu_One[item].PagePath + "'>" + Menu_One[item].MenuName + "</a></li>";
                                            }
                                        }
                                    }
                                }
                                FirstMenu += "</ul></li>";
                            }
                            //如果没有子菜单
                            else
                            {
                                FirstMenu += " href='" + Menu_One[i].PagePath +
                            "'id='dropDown_" + i + "'" +
                            "><i class='" + Menu_One[i].Icon
                            + "'></i>" + Menu_One[i].MenuName + "</a></li>";
                            }
                        }
                    }


                }
            }
            return Ok(FirstMenu);
        }

        // GET: api/Menus/5
        [ResponseType(typeof(Menu))]
        public IHttpActionResult GetMenu(Guid id)
        {
            Menu menu = db.Menu.Find(id);
            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }


        // GET: api/Menus/5
        [HttpGet]
        public int GetMenuByPM(Guid pid)
        {
            return db.Menu.Where(u => u.ParentMenuID == pid).OrderByDescending(u => u.OrderNum).Count();


        }

        // PUT: api/Menus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateMenu(Guid id, Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menu.MenuID)
            {
                return BadRequest();
            }

            db.Entry(menu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
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

        // POST: api/Menus
        [ResponseType(typeof(Menu))]
        public IHttpActionResult AddMenu(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Menu.Add(menu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MenuExists(menu.MenuID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = menu.MenuID }, menu);
        }

        // DELETE: api/Menus/5
        [ResponseType(typeof(Menu))]
        [HttpPost]
        public IHttpActionResult DeleteMenu(Guid id)
        {
            Menu menu = db.Menu.Find(id);
            if (menu == null)
            {
                return NotFound();
            }

            db.Menu.Remove(menu);
            db.SaveChanges();

            return Ok(menu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuExists(Guid id)
        {
            return db.Menu.Count(e => e.MenuID == id) > 0;
        }
    }
}