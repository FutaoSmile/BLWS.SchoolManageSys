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
    public class ApprovalFlow_ApplicationFromController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/ApprovalFlow_ApplicationFrom
        public IQueryable<ApprovalFlow_ApplicationFrom> GetApprovalFlow_ApplicationFrom()
        {
            return db.ApprovalFlow_ApplicationFrom;
        }

        // GET: api/ApprovalFlow_ApplicationFrom/5
        [ResponseType(typeof(ApprovalFlow_ApplicationFrom))]
        public IHttpActionResult GetApprovalFlow_ApplicationFrom(Guid id)
        {
            ApprovalFlow_ApplicationFrom approvalFlow_ApplicationFrom = db.ApprovalFlow_ApplicationFrom.Find(id);
            if (approvalFlow_ApplicationFrom == null)
            {
                return NotFound();
            }

            return Ok(approvalFlow_ApplicationFrom);
        }

        // PUT: api/ApprovalFlow_ApplicationFrom/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApprovalFlow_ApplicationFrom(Guid id, ApprovalFlow_ApplicationFrom approvalFlow_ApplicationFrom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != approvalFlow_ApplicationFrom.AFID)
            {
                return BadRequest();
            }

            db.Entry(approvalFlow_ApplicationFrom).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApprovalFlow_ApplicationFromExists(id))
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

        // POST: api/ApprovalFlow_ApplicationFrom
        [ResponseType(typeof(ApprovalFlow_ApplicationFrom))]
        public IHttpActionResult PostApprovalFlow_ApplicationFrom(ApprovalFlow_ApplicationFrom approvalFlow_ApplicationFrom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApprovalFlow_ApplicationFrom.Add(approvalFlow_ApplicationFrom);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ApprovalFlow_ApplicationFromExists(approvalFlow_ApplicationFrom.AFID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = approvalFlow_ApplicationFrom.AFID }, approvalFlow_ApplicationFrom);
        }

        // DELETE: api/ApprovalFlow_ApplicationFrom/5
        [ResponseType(typeof(ApprovalFlow_ApplicationFrom))]
        public IHttpActionResult DeleteApprovalFlow_ApplicationFrom(Guid id)
        {
            ApprovalFlow_ApplicationFrom approvalFlow_ApplicationFrom = db.ApprovalFlow_ApplicationFrom.Find(id);
            if (approvalFlow_ApplicationFrom == null)
            {
                return NotFound();
            }

            db.ApprovalFlow_ApplicationFrom.Remove(approvalFlow_ApplicationFrom);
            db.SaveChanges();

            return Ok(approvalFlow_ApplicationFrom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApprovalFlow_ApplicationFromExists(Guid id)
        {
            return db.ApprovalFlow_ApplicationFrom.Count(e => e.AFID == id) > 0;
        }
    }
}