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
    public class ApprovalFlow_ApprovalLogController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/ApprovalFlow_ApprovalLog
        public IQueryable<ApprovalFlow_ApprovalLog> GetApprovalFlow_ApprovalLog()
        {
            return db.ApprovalFlow_ApprovalLog;
        }

        // GET: api/ApprovalFlow_ApprovalLog/5
        [ResponseType(typeof(ApprovalFlow_ApprovalLog))]
        public IHttpActionResult GetApprovalFlow_ApprovalLog(int id)
        {
            ApprovalFlow_ApprovalLog approvalFlow_ApprovalLog = db.ApprovalFlow_ApprovalLog.Find(id);
            if (approvalFlow_ApprovalLog == null)
            {
                return NotFound();
            }

            return Ok(approvalFlow_ApprovalLog);
        }

        // PUT: api/ApprovalFlow_ApprovalLog/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApprovalFlow_ApprovalLog(int id, ApprovalFlow_ApprovalLog approvalFlow_ApprovalLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != approvalFlow_ApprovalLog.ID)
            {
                return BadRequest();
            }

            db.Entry(approvalFlow_ApprovalLog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApprovalFlow_ApprovalLogExists(id))
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

        // POST: api/ApprovalFlow_ApprovalLog
        [ResponseType(typeof(ApprovalFlow_ApprovalLog))]
        public IHttpActionResult PostApprovalFlow_ApprovalLog(ApprovalFlow_ApprovalLog approvalFlow_ApprovalLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApprovalFlow_ApprovalLog.Add(approvalFlow_ApprovalLog);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = approvalFlow_ApprovalLog.ID }, approvalFlow_ApprovalLog);
        }

        // DELETE: api/ApprovalFlow_ApprovalLog/5
        [ResponseType(typeof(ApprovalFlow_ApprovalLog))]
        public IHttpActionResult DeleteApprovalFlow_ApprovalLog(int id)
        {
            ApprovalFlow_ApprovalLog approvalFlow_ApprovalLog = db.ApprovalFlow_ApprovalLog.Find(id);
            if (approvalFlow_ApprovalLog == null)
            {
                return NotFound();
            }

            db.ApprovalFlow_ApprovalLog.Remove(approvalFlow_ApprovalLog);
            db.SaveChanges();

            return Ok(approvalFlow_ApprovalLog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApprovalFlow_ApprovalLogExists(int id)
        {
            return db.ApprovalFlow_ApprovalLog.Count(e => e.ID == id) > 0;
        }
    }
}