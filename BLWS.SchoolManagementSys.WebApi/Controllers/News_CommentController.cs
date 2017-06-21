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
    public class News_CommentController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/News_Comment
        public IQueryable<News_Comment> GetNews_Comment()
        {
            return db.News_Comment;
        }

        // GET: api/News_Comment/5
        [ResponseType(typeof(News_Comment))]
        public IHttpActionResult GetNews_Comment(int id)
        {
            News_Comment news_Comment = db.News_Comment.Find(id);
            if (news_Comment == null)
            {
                return NotFound();
            }

            return Ok(news_Comment);
        }

        // PUT: api/News_Comment/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNews_Comment(int id, News_Comment news_Comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != news_Comment.CommentID)
            {
                return BadRequest();
            }

            db.Entry(news_Comment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!News_CommentExists(id))
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

        // POST: api/News_Comment
        [ResponseType(typeof(News_Comment))]
        public IHttpActionResult PostNews_Comment(News_Comment news_Comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.News_Comment.Add(news_Comment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = news_Comment.CommentID }, news_Comment);
        }

        // DELETE: api/News_Comment/5
        [ResponseType(typeof(News_Comment))]
        public IHttpActionResult DeleteNews_Comment(int id)
        {
            News_Comment news_Comment = db.News_Comment.Find(id);
            if (news_Comment == null)
            {
                return NotFound();
            }

            db.News_Comment.Remove(news_Comment);
            db.SaveChanges();

            return Ok(news_Comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool News_CommentExists(int id)
        {
            return db.News_Comment.Count(e => e.CommentID == id) > 0;
        }
    }
}