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
    public class ApprovalFlow_FlowTypeController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/ApprovalFlow_FlowType
        public IQueryable<ApprovalFlow_FlowType> GetApprovalFlow_FlowType()
        {
            return db.ApprovalFlow_FlowType;
        }

        // GET: api/ApprovalFlow_FlowType/5
        [ResponseType(typeof(ApprovalFlow_FlowType))]
        public IHttpActionResult GetApprovalFlow_FlowType(Guid id)
        {
            ApprovalFlow_FlowType approvalFlow_FlowType = db.ApprovalFlow_FlowType.Find(id);
            if (approvalFlow_FlowType == null)
            {
                return NotFound();
            }

            return Ok(approvalFlow_FlowType);
        }

        // PUT: api/ApprovalFlow_FlowType/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateApprovalFlow_FlowType(Guid id, ApprovalFlow_FlowType approvalFlow_FlowType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != approvalFlow_FlowType.FlowTypeID)
            {
                return BadRequest();
            }

            db.Entry(approvalFlow_FlowType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApprovalFlow_FlowTypeExists(id))
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

        // POST: api/ApprovalFlow_FlowType
        [ResponseType(typeof(ApprovalFlow_FlowType))]
        public IHttpActionResult AddApprovalFlow_FlowType(ApprovalFlow_FlowType approvalFlow_FlowType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApprovalFlow_FlowType.Add(approvalFlow_FlowType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ApprovalFlow_FlowTypeExists(approvalFlow_FlowType.FlowTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = approvalFlow_FlowType.FlowTypeID }, approvalFlow_FlowType);
        }

        // DELETE: api/ApprovalFlow_FlowType/5
        [ResponseType(typeof(ApprovalFlow_FlowType))]
        [HttpPost]
        public IHttpActionResult DeleteApprovalFlow_FlowType(Guid id)
        {
            ApprovalFlow_FlowType approvalFlow_FlowType = db.ApprovalFlow_FlowType.Find(id);
            if (approvalFlow_FlowType == null)
            {
                return NotFound();
            }

            db.ApprovalFlow_FlowType.Remove(approvalFlow_FlowType);
            db.SaveChanges();

            return Ok(approvalFlow_FlowType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApprovalFlow_FlowTypeExists(Guid id)
        {
            return db.ApprovalFlow_FlowType.Count(e => e.FlowTypeID == id) > 0;
        }
    }
}