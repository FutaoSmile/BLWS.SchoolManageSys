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
    public class News_newsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/News_news
        public IQueryable<News_news> GetNews_news()
        {
            return db.News_news.OrderByDescending(u=>u.UploadTime);
        }

        // GET: api/News_news/5
        [ResponseType(typeof(News_news))]
        public IHttpActionResult GetNews_news(Guid id)
        {
            News_news news_news = db.News_news.Find(id);
            if (news_news == null)
            {
                return NotFound();
            }

            return Ok(news_news);
        }

        // PUT: api/News_news/5
        /// <summary>
        /// 自动判断新增或者修改并且存入数据库
        /// </summary>
        /// <param name="id">新闻ID</param>
        /// <param name="news_news">新闻实体</param>
        /// <returns>保存结果</returns>
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PutNews_news(Guid id, News_news news_news)
        {
            News_news Nn = db.Set<News_news>().AsNoTracking().FirstOrDefault(u => u.NewsID == id);
            //如果该ID在数据库没有数据的话则进行新增操作
            if (Nn == null)
            {
                db.News_news.Add(news_news);
                db.SaveChanges();
                return Ok();
            }
            //如果该ID在数据库有数据的话则进行保存操作
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != news_news.NewsID)
                {
                    return BadRequest();
                }
                db.Entry(news_news).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!News_newsExists(id))
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
        }

        // POST: api/News_news
        [ResponseType(typeof(News_news))]
        public IHttpActionResult PostNews_news(News_news news_news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.News_news.Add(news_news);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (News_newsExists(news_news.NewsID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = news_news.NewsID }, news_news);
        }

        // DELETE: api/News_news/5
        [ResponseType(typeof(News_news))]
        public IHttpActionResult DeleteNews_news(Guid id)
        {
            News_news news_news = db.News_news.Find(id);
            if (news_news == null)
            {
                return NotFound();
            }

            db.News_news.Remove(news_news);
            db.SaveChanges();

            return Ok(news_news);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool News_newsExists(Guid id)
        {
            return db.News_news.Count(e => e.NewsID == id) > 0;
        }
    }
}