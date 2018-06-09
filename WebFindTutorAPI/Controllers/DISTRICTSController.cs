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
using WebFindTutorAPI.Models;

namespace WebFindTutorAPI.Controllers
{
    public class DISTRICTSController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/DISTRICTS
        public IQueryable<DISTRICTS> GetDISTRICTS()
        {
            return db.DISTRICTS;
        }

        // GET: api/DISTRICTS/5
        [ResponseType(typeof(DISTRICTS))]
        public IHttpActionResult GetDISTRICTS(int id)
        {
            DISTRICTS dISTRICTS = db.DISTRICTS.Find(id);
            if (dISTRICTS == null)
            {
                return NotFound();
            }

            return Ok(dISTRICTS);
        }

        // PUT: api/DISTRICTS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDISTRICTS(int id, DISTRICTS dISTRICTS)
        {

            if (id != dISTRICTS.DISTRICT_ID)
            {
                return BadRequest();
            }

            db.Entry(dISTRICTS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DISTRICTSExists(id))
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

        // POST: api/DISTRICTS
        [ResponseType(typeof(DISTRICTS))]
        public IHttpActionResult PostDISTRICTS(DISTRICTS dISTRICTS)
        {

            db.DISTRICTS.Add(dISTRICTS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DISTRICTSExists(dISTRICTS.DISTRICT_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dISTRICTS.DISTRICT_ID }, dISTRICTS);
        }

        // DELETE: api/DISTRICTS/5
        [ResponseType(typeof(DISTRICTS))]
        public IHttpActionResult DeleteDISTRICTS(int id)
        {
            DISTRICTS dISTRICTS = db.DISTRICTS.Find(id);
            if (dISTRICTS == null)
            {
                return NotFound();
            }

            db.DISTRICTS.Remove(dISTRICTS);
            db.SaveChanges();

            return Ok(dISTRICTS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DISTRICTSExists(int id)
        {
            return db.DISTRICTS.Count(e => e.DISTRICT_ID == id) > 0;
        }
    }
}