﻿using System;
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
    public class PacientesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Pacientes
        public IQueryable<Pacientes> GetPacientes()
        {
            return db.Pacientes;
        }

        // GET: api/Pacientes/5
        [ResponseType(typeof(Pacientes))]
        public IHttpActionResult GetPacientes(int id)
        {
            Pacientes pacientes = db.Pacientes.Find(id);
            if (pacientes == null)
            {
                return NotFound();
            }

            return Ok(pacientes);
        }

        // PUT: api/Pacientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPacientes(int id, Pacientes pacientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pacientes.ID)
            {
                return BadRequest();
            }

            db.Entry(pacientes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacientesExists(id))
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

        // POST: api/Pacientes
        [ResponseType(typeof(Pacientes))]
        public IHttpActionResult PostPacientes(Pacientes pacientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pacientes.Add(pacientes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pacientes.ID }, pacientes);
        }

        // DELETE: api/Pacientes/5
        [ResponseType(typeof(Pacientes))]
        public IHttpActionResult DeletePacientes(int id)
        {
            Pacientes pacientes = db.Pacientes.Find(id);
            if (pacientes == null)
            {
                return NotFound();
            }

            db.Pacientes.Remove(pacientes);
            db.SaveChanges();

            return Ok(pacientes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PacientesExists(int id)
        {
            return db.Pacientes.Count(e => e.ID == id) > 0;
        }
    }
}