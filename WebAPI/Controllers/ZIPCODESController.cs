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
    public class ZIPCODESController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/ZIPCODES
        public IQueryable<ZIPCODES> GetZIPCODES()
        {
            return db.ZIPCODES;
        }

        // GET: api/ZIPCODES/5
        [ResponseType(typeof(ZIPCODES))]
        public IHttpActionResult GetZIPCODES(int id)
        {
            ZIPCODES zIPCODES = db.ZIPCODES.Find(id);
            if (zIPCODES == null)
            {
                return NotFound();
            }

            return Ok(zIPCODES);
        }

        // PUT: api/ZIPCODES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZIPCODES(int id, ZIPCODES zIPCODES)
        {

            if (id != zIPCODES.ZIPCODE_ID)
            {
                return BadRequest();
            }

            db.Entry(zIPCODES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZIPCODESExists(id))
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

        // POST: api/ZIPCODES
        [ResponseType(typeof(ZIPCODES))]
        public IHttpActionResult PostZIPCODES(ZIPCODES zIPCODES)
        {

            db.ZIPCODES.Add(zIPCODES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ZIPCODESExists(zIPCODES.ZIPCODE_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = zIPCODES.ZIPCODE_ID }, zIPCODES);
        }

        // DELETE: api/ZIPCODES/5
        [ResponseType(typeof(ZIPCODES))]
        public IHttpActionResult DeleteZIPCODES(int id)
        {
            ZIPCODES zIPCODES = db.ZIPCODES.Find(id);
            if (zIPCODES == null)
            {
                return NotFound();
            }

            db.ZIPCODES.Remove(zIPCODES);
            db.SaveChanges();

            return Ok(zIPCODES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZIPCODESExists(int id)
        {
            return db.ZIPCODES.Count(e => e.ZIPCODE_ID == id) > 0;
        }
    }
}