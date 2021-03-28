using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FormulaOneWebServices
{
    [Route("api/driver")]
    [ApiController]
    public class driverController : ControllerBase
    {
        // GET: api/driver
        [HttpGet]
        public IEnumerable<Driver> Get()
        {
            DBTools db = new DBTools();
            return db.GetDriversObj();
        }

        // GET: api/driver/1
        [HttpGet("id/{id}")]
        public Driver Get(int id)
        {
            DBTools db = new DBTools();
            return db.GetDriverById(id);
        }

        [HttpGet("name/{name}")]
        public Driver Get(string name)
        {
            DBTools db = new DBTools();
            return db.GetDriverByName(name);
        }

        // POST: api/driver
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/driver/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
