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
    public class ApprovalFlow_FlowSetController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/ApprovalFlow_FlowSet
        public IQueryable<ApprovalFlow_FlowSet> GetApprovalFlow_FlowSet()
        {
            return db.ApprovalFlow_FlowSet;
        }
        /// <summary>
        /// 通过流程编号获取该流程的所有节点
        /// </summary>
        /// <param name="id">流程编号</param>
        /// <returns>所有节点</returns>
        public IQueryable<ApprovalFlow_FlowSet> GetApprovalFlow_FlowSetByFlowID(Guid id)
        {
            return db.ApprovalFlow_FlowSet.Where(u=>u.FlowTypeID==id);
        }


        // GET: api/ApprovalFlow_FlowSet/5
        [ResponseType(typeof(ApprovalFlow_FlowSet))]
        public IHttpActionResult GetApprovalFlow_FlowSet(Guid id)
        {
            ApprovalFlow_FlowSet approvalFlow_FlowSet = db.ApprovalFlow_FlowSet.Find(id);
            if (approvalFlow_FlowSet == null)
            {
                return NotFound();
            }

            return Ok(approvalFlow_FlowSet);
        }

        // PUT: api/ApprovalFlow_FlowSet/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApprovalFlow_FlowSet(Guid id, ApprovalFlow_FlowSet approvalFlow_FlowSet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != approvalFlow_FlowSet.StepID)
            {
                return BadRequest();
            }

            db.Entry(approvalFlow_FlowSet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApprovalFlow_FlowSetExists(id))
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

        // POST: api/ApprovalFlow_FlowSet
        [ResponseType(typeof(ApprovalFlow_FlowSet))]
        [HttpPost]
        public IHttpActionResult PostApprovalFlow_FlowSet(ApprovalFlow_FlowSet approvalFlow_FlowSet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApprovalFlow_FlowSet.Add(approvalFlow_FlowSet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ApprovalFlow_FlowSetExists(approvalFlow_FlowSet.StepID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = approvalFlow_FlowSet.StepID }, approvalFlow_FlowSet);
        }

        // DELETE: api/ApprovalFlow_FlowSet/5
        [ResponseType(typeof(ApprovalFlow_FlowSet))]
        public IHttpActionResult DeleteApprovalFlow_FlowSet(Guid id)
        {
            ApprovalFlow_FlowSet approvalFlow_FlowSet = db.ApprovalFlow_FlowSet.Find(id);
            if (approvalFlow_FlowSet == null)
            {
                return NotFound();
            }

            db.ApprovalFlow_FlowSet.Remove(approvalFlow_FlowSet);
            db.SaveChanges();

            return Ok(approvalFlow_FlowSet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApprovalFlow_FlowSetExists(Guid id)
        {
            return db.ApprovalFlow_FlowSet.Count(e => e.StepID == id) > 0;
        }
    }
}