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
using Leandro.Models;

namespace Leandro.Controllers
{
    public class MotivoDeCitasController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/MotivoDeCitas
        public IQueryable<MotivoDeCita> GetMotivoDeCita()
        {
            return db.MotivoDeCita;
        }

        // GET: api/MotivoDeCitas/5
        [ResponseType(typeof(MotivoDeCita))]
        public IHttpActionResult GetMotivoDeCita(int id)
        {
            MotivoDeCita motivoDeCita = db.MotivoDeCita.Find(id);
            if (motivoDeCita == null)
            {
                return NotFound();
            }

            return Ok(motivoDeCita);
        }

        // PUT: api/MotivoDeCitas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMotivoDeCita(int id, MotivoDeCita motivoDeCita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motivoDeCita.ID)
            {
                return BadRequest();
            }

            db.Entry(motivoDeCita).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotivoDeCitaExists(id))
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

        // POST: api/MotivoDeCitas
        [ResponseType(typeof(MotivoDeCita))]
        public IHttpActionResult PostMotivoDeCita(MotivoDeCita motivoDeCita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MotivoDeCita.Add(motivoDeCita);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = motivoDeCita.ID }, motivoDeCita);
        }

        // DELETE: api/MotivoDeCitas/5
        [ResponseType(typeof(MotivoDeCita))]
        public IHttpActionResult DeleteMotivoDeCita(int id)
        {
            MotivoDeCita motivoDeCita = db.MotivoDeCita.Find(id);
            if (motivoDeCita == null)
            {
                return NotFound();
            }

            db.MotivoDeCita.Remove(motivoDeCita);
            db.SaveChanges();

            return Ok(motivoDeCita);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MotivoDeCitaExists(int id)
        {
            return db.MotivoDeCita.Count(e => e.ID == id) > 0;
        }
    }
}