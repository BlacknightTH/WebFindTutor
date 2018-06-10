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
    public class GEOGRAPHiesController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/GEOGRAPHies
        public IQueryable<GEOGRAPHY> GetGEOGRAPHY()
        {
            return db.GEOGRAPHY;
        }

        // GET: api/GEOGRAPHies/5
        [ResponseType(typeof(GEOGRAPHY))]
        public IHttpActionResult GetGEOGRAPHY(int id)
        {
            GEOGRAPHY gEOGRAPHY = db.GEOGRAPHY.Find(id);
            if (gEOGRAPHY == null)
            {
                return NotFound();
            }

            return Ok(gEOGRAPHY);
        }

        // PUT: api/GEOGRAPHies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGEOGRAPHY(int id, GEOGRAPHY gEOGRAPHY)
        {

            if (id != gEOGRAPHY.GEO_ID)
            {
                return BadRequest();
            }

            db.Entry(gEOGRAPHY).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GEOGRAPHYExists(id))
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

        // POST: api/GEOGRAPHies
        [ResponseType(typeof(GEOGRAPHY))]
        public IHttpActionResult PostGEOGRAPHY(GEOGRAPHY gEOGRAPHY)
        {

            db.GEOGRAPHY.Add(gEOGRAPHY);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GEOGRAPHYExists(gEOGRAPHY.GEO_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gEOGRAPHY.GEO_ID }, gEOGRAPHY);
        }

        // DELETE: api/GEOGRAPHies/5
        [ResponseType(typeof(GEOGRAPHY))]
        public IHttpActionResult DeleteGEOGRAPHY(int id)
        {
            GEOGRAPHY gEOGRAPHY = db.GEOGRAPHY.Find(id);
            if (gEOGRAPHY == null)
            {
                return NotFound();
            }

            db.GEOGRAPHY.Remove(gEOGRAPHY);
            db.SaveChanges();

            return Ok(gEOGRAPHY);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GEOGRAPHYExists(int id)
        {
            return db.GEOGRAPHY.Count(e => e.GEO_ID == id) > 0;
        }
    }
}