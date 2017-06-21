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
    public class News_InfoController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/News_Info
        public IQueryable<News_Info> GetNews_Info()
        {
            return db.News_Info;
        }

        // GET: api/News_Info/5
        [ResponseType(typeof(News_Info))]
        public IHttpActionResult GetNews_Info(Guid id)
        {
            News_Info news_Info = db.News_Info.Find(id);
            if (news_Info == null)
            {
                return NotFound();
            }

            return Ok(news_Info);
        }

        // PUT: api/News_Info/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNews_Info(Guid id, News_Info news_Info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != news_Info.InfoID)
            {
                return BadRequest();
            }

            db.Entry(news_Info).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!News_InfoExists(id))
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

        // POST: api/News_Info
        [ResponseType(typeof(News_Info))]
        public IHttpActionResult PostNews_Info(News_Info news_Info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.News_Info.Add(news_Info);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (News_InfoExists(news_Info.InfoID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = news_Info.InfoID }, news_Info);
        }

        // DELETE: api/News_Info/5
        [ResponseType(typeof(News_Info))]
        public IHttpActionResult DeleteNews_Info(Guid id)
        {
            News_Info news_Info = db.News_Info.Find(id);
            if (news_Info == null)
            {
                return NotFound();
            }

            db.News_Info.Remove(news_Info);
            db.SaveChanges();

            return Ok(news_Info);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool News_InfoExists(Guid id)
        {
            return db.News_Info.Count(e => e.InfoID == id) > 0;
        }
    }
}