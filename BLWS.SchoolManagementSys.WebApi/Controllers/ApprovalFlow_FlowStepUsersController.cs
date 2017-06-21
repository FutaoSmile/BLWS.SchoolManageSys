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
    public class ApprovalFlow_FlowStepUsersController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/ApprovalFlow_FlowStepUsers
        public IQueryable<ApprovalFlow_FlowStepUsers> GetApprovalFlow_FlowStepUsers()
        {
            return db.ApprovalFlow_FlowStepUsers;
        }

        // GET: api/ApprovalFlow_FlowStepUsers/5
        [ResponseType(typeof(ApprovalFlow_FlowStepUsers))]
        public IHttpActionResult GetApprovalFlow_FlowStepUsers(int id)
        {
            ApprovalFlow_FlowStepUsers approvalFlow_FlowStepUsers = db.ApprovalFlow_FlowStepUsers.Find(id);
            if (approvalFlow_FlowStepUsers == null)
            {
                return NotFound();
            }

            return Ok(approvalFlow_FlowStepUsers);
        }

        // PUT: api/ApprovalFlow_FlowStepUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApprovalFlow_FlowStepUsers(int id, ApprovalFlow_FlowStepUsers approvalFlow_FlowStepUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != approvalFlow_FlowStepUsers.ID)
            {
                return BadRequest();
            }

            db.Entry(approvalFlow_FlowStepUsers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApprovalFlow_FlowStepUsersExists(id))
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

        // POST: api/ApprovalFlow_FlowStepUsers
        [ResponseType(typeof(ApprovalFlow_FlowStepUsers))]
        public IHttpActionResult PostApprovalFlow_FlowStepUsers(ApprovalFlow_FlowStepUsers approvalFlow_FlowStepUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApprovalFlow_FlowStepUsers.Add(approvalFlow_FlowStepUsers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = approvalFlow_FlowStepUsers.ID }, approvalFlow_FlowStepUsers);
        }

        // DELETE: api/ApprovalFlow_FlowStepUsers/5
        [ResponseType(typeof(ApprovalFlow_FlowStepUsers))]
        public IHttpActionResult DeleteApprovalFlow_FlowStepUsers(int id)
        {
            ApprovalFlow_FlowStepUsers approvalFlow_FlowStepUsers = db.ApprovalFlow_FlowStepUsers.Find(id);
            if (approvalFlow_FlowStepUsers == null)
            {
                return NotFound();
            }

            db.ApprovalFlow_FlowStepUsers.Remove(approvalFlow_FlowStepUsers);
            db.SaveChanges();

            return Ok(approvalFlow_FlowStepUsers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApprovalFlow_FlowStepUsersExists(int id)
        {
            return db.ApprovalFlow_FlowStepUsers.Count(e => e.ID == id) > 0;
        }
    }
}