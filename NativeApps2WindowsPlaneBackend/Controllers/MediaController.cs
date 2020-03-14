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
using NativeApps2WindowsPlaneBackend.Models;
using NativeApps2WindowsPlaneBackend.Models.Domain;

namespace NativeApps2WindowsPlaneBackend.Controllers
{
    public class MediaController : ApiController
    {
        private NativeApps2WindowsPlaneBackendContext db = new NativeApps2WindowsPlaneBackendContext();

        // GET: api/Media
        public IQueryable<Medium> GetMedia()
        {
            return db.Media;
        }

        // GET: api/Media/5
        [ResponseType(typeof(Medium))]
        public IHttpActionResult GetMedium(int id)
        {
            Medium medium = db.Media.Find(id);
            if (medium == null)
            {
                return NotFound();
            }

            return Ok(medium);
        }

        // PUT: api/Media/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedium(int id, Medium medium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medium.MediumId)
            {
                return BadRequest();
            }

            db.Entry(medium).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediumExists(id))
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

        // POST: api/Media
        [ResponseType(typeof(Medium))]
        public IHttpActionResult PostMedium(Medium medium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Media.Add(medium);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medium.MediumId }, medium);
        }

        // DELETE: api/Media/5
        [ResponseType(typeof(Medium))]
        public IHttpActionResult DeleteMedium(int id)
        {
            Medium medium = db.Media.Find(id);
            if (medium == null)
            {
                return NotFound();
            }

            db.Media.Remove(medium);
            db.SaveChanges();

            return Ok(medium);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MediumExists(int id)
        {
            return db.Media.Count(e => e.MediumId == id) > 0;
        }
    }
}