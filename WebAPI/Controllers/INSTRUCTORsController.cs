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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class INSTRUCTORsController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/INSTRUCTORs
        public IQueryable<INSTRUCTOR> GetINSTRUCTOR()
        {
            return db.INSTRUCTOR;
        }

        // GET: api/INSTRUCTORs/5
        [ResponseType(typeof(INSTRUCTOR))]
        public IHttpActionResult GetINSTRUCTOR(int id)
        {
            INSTRUCTOR iNSTRUCTOR = db.INSTRUCTOR.Find(id);
            if (iNSTRUCTOR == null)
            {
                return NotFound();
            }

            return Ok(iNSTRUCTOR);
        }

        // PUT: api/INSTRUCTORs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutINSTRUCTOR(int id, INSTRUCTOR iNSTRUCTOR)
        {

            if (id != iNSTRUCTOR.Instructor_ID)
            {
                return BadRequest();
            }

            db.Entry(iNSTRUCTOR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!INSTRUCTORExists(id))
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

        // POST: api/INSTRUCTORs
        [ResponseType(typeof(INSTRUCTOR))]
        public IHttpActionResult PostINSTRUCTOR(INSTRUCTOR iNSTRUCTOR)
        {

            db.INSTRUCTOR.Add(iNSTRUCTOR);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = iNSTRUCTOR.Instructor_ID }, iNSTRUCTOR);
        }

        // DELETE: api/INSTRUCTORs/5
        [ResponseType(typeof(INSTRUCTOR))]
        public IHttpActionResult DeleteINSTRUCTOR(int id)
        {
            INSTRUCTOR iNSTRUCTOR = db.INSTRUCTOR.Find(id);
            if (iNSTRUCTOR == null)
            {
                return NotFound();
            }

            db.INSTRUCTOR.Remove(iNSTRUCTOR);
            db.SaveChanges();

            return Ok(iNSTRUCTOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool INSTRUCTORExists(int id)
        {
            return db.INSTRUCTOR.Count(e => e.Instructor_ID == id) > 0;
        }
    }
}