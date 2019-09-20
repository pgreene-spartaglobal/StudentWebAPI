using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIExample.Controllers
{
    public class StudentAPIController : ApiController
    {
        private WebAPIwithXMLEntities db = new WebAPIwithXMLEntities();

        // GET: api/StudentAPI
        public IEnumerable<Student> Get()
        {
            return db.Students;
        }

        // GET: api/StudentAPI/5
        public IEnumerable<Student> Get(int id)
        {
            return db.Students.Where(model => model.Id == id);
        }

        // POST: api/StudentAPI
        public void Post(Student value)
        {
            db.Students.Add(value);
        }

        // PUT: api/StudentAPI/5
        public void Put(int id, [FromBody]Student value)
        {
            var entity = db.Students.FirstOrDefault(model => model.Id == id);
            entity.FirstName = value.FirstName;
            entity.LastName = value.LastName;
            entity.Age = value.Age;

        }

        // DELETE: api/StudentAPI/5
        public void Delete(int id)
        {
            var entity = db.Students.FirstOrDefault(model => model.Id == id);
            db.Students.Remove((Student)entity);
        }
    }
}
