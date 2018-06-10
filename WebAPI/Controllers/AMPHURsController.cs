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
    public class AMPHURsController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/AMPHURs
        public IQueryable<AMPHUR> GetAMPHUR()
        {
            return db.AMPHUR;
        }

        // GET: api/AMPHURs/5
        [ResponseType(typeof(AMPHUR))]
        public IHttpActionResult GetAMPHUR(int id)
        {
            AMPHUR aMPHUR = db.AMPHUR.Find(id);
            if (aMPHUR == null)
            {
                return NotFound();
            }

            return Ok(aMPHUR);
        }

        // PUT: api/AMPHURs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAMPHUR(int id, AMPHUR aMPHUR)
        {

            if (id != aMPHUR.AMPHUR_ID)
            {
                return BadRequest();
            }

            db.Entry(aMPHUR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AMPHURExists(id))
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

        // POST: api/AMPHURs
        [ResponseType(typeof(AMPHUR))]
        public IHttpActionResult PostAMPHUR(AMPHUR aMPHUR)
        {

            db.AMPHUR.Add(aMPHUR);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AMPHURExists(aMPHUR.AMPHUR_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aMPHUR.AMPHUR_ID }, aMPHUR);
        }

        // DELETE: api/AMPHURs/5
        [ResponseType(typeof(AMPHUR))]
        public IHttpActionResult DeleteAMPHUR(int id)
        {
            AMPHUR aMPHUR = db.AMPHUR.Find(id);
            if (aMPHUR == null)
            {
                return NotFound();
            }

            db.AMPHUR.Remove(aMPHUR);
            db.SaveChanges();

            return Ok(aMPHUR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AMPHURExists(int id)
        {
            return db.AMPHUR.Count(e => e.AMPHUR_ID == id) > 0;
        }
    }
}