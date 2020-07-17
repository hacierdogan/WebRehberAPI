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
using Rehber.DAL;
using Rehber.API.Security;

namespace Rehber.API.Controllers
{

    [APIAuthorizeAttribute(Roles = "Admin")]
    public class KullanicilarController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Kullanicilar
        public IQueryable<Kullanicilar> GetKullanicilar()
        {
            return db.Kullanicilar;
        }

        // GET: api/Kullanicilar/5
        [ResponseType(typeof(Kullanicilar))]
        public IHttpActionResult GetKullanicilar(int id)
        {
            Kullanicilar kullanicilar = db.Kullanicilar.Find(id);
            if (kullanicilar == null)
            {
                return NotFound();
            }

            return Ok(kullanicilar);
        }

        // PUT: api/Kullanicilar/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKullanicilar(int id, Kullanicilar kullanicilar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kullanicilar.ID)
            {
                return BadRequest();
            }

            db.Entry(kullanicilar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KullanicilarExists(id))
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

        // POST: api/Kullanicilar

        [ResponseType(typeof(Kullanicilar))]
        public IHttpActionResult PostKullanicilar(Kullanicilar kullanicilar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kullanicilar.Add(kullanicilar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kullanicilar.ID }, kullanicilar);
        }

        // DELETE: api/Kullanicilar/5
        [ResponseType(typeof(Kullanicilar))]
        public IHttpActionResult DeleteKullanicilar(int id)
        {
            Kullanicilar kullanicilar = db.Kullanicilar.Find(id);
            if (kullanicilar == null)
            {
                return NotFound();
            }

            db.Kullanicilar.Remove(kullanicilar);
            db.SaveChanges();

            return Ok(kullanicilar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KullanicilarExists(int id)
        {
            return db.Kullanicilar.Count(e => e.ID == id) > 0;
        }
    }
}