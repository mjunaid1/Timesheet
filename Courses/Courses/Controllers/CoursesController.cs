using Courses.DataAccess;
using Courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Courses.Controllers
{
    public class CoursesController : ApiController
    {



        [HttpPost]
        public bool AddCourse([FromBody]CoursesModel CoursesModel)
        {
            try
            {
                CoursesRepository _searchRepository = new CoursesRepository();
                var propertySearchResult = _searchRepository.AddCourse(CoursesModel);
                return propertySearchResult;// propertySearchResult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        // GET: api/Courses2
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Courses2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Courses2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Courses2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Courses2/5
        public void Delete(int id)
        {
        }
    }
}
