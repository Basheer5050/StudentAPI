using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using StudentAPI;

namespace StudentAPI.Controllers
{
    [EnableCors(headers: "*", methods: "*", origins: "*")]
    public class StudentsController : ApiController
    {
        private SchoolDBEntities db = new SchoolDBEntities();

        // GET: api/Students
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        public IQueryable<Student> GetStudents()
        {
            return db.Students;
        }
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.RollNo)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.RollNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = student.RollNo }, student);
        }
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.RollNo == id) > 0;
        }
    }
}