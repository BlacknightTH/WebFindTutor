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
    public class PROVINCEsController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/PROVINCEs
        public IQueryable<PROVINCE> GetPROVINCE()
        {
            return db.PROVINCE;
        }

        // GET: api/PROVINCEs/5
        [ResponseType(typeof(PROVINCE))]
        public IHttpActionResult GetPROVINCE(int id)
        {
            PROVINCE pROVINCE = db.PROVINCE.Find(id);
            if (pROVINCE == null)
            {
                return NotFound();
            }

            return Ok(pROVINCE);
        }

        // PUT: api/PROVINCEs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPROVINCE(int id, PROVINCE pROVINCE)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != pROVINCE.PROVINCE_ID)
            {
                return BadRequest();
            }

            db.Entry(pROVINCE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PROVINCEExists(id))
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

        // POST: api/PROVINCEs
        [ResponseType(typeof(PROVINCE))]
        public IHttpActionResult PostPROVINCE(PROVINCE pROVINCE)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.PROVINCE.Add(pROVINCE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PROVINCEExists(pROVINCE.PROVINCE_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pROVINCE.PROVINCE_ID }, pROVINCE);
        }

        // DELETE: api/PROVINCEs/5
        [ResponseType(typeof(PROVINCE))]
        public IHttpActionResult DeletePROVINCE(int id)
        {
            PROVINCE pROVINCE = db.PROVINCE.Find(id);
            if (pROVINCE == null)
            {
                return NotFound();
            }

            db.PROVINCE.Remove(pROVINCE);
            db.SaveChanges();

            return Ok(pROVINCE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PROVINCEExists(int id)
        {
            return db.PROVINCE.Count(e => e.PROVINCE_ID == id) > 0;
        }
    }
}