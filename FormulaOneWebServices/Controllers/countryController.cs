using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FormulaOneWebServices
{
    [Route("api/country")]
    [ApiController]
    public class countryController : ControllerBase
    {
        // GET: api/country
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            DBTools db = new DBTools();
            return db.GetCountriesObj();
        }

        // GET: api/country/it
        [HttpGet("id/{id}")]
        public Country Get(string id)
        {
            DBTools db = new DBTools();
            return db.GetCountryById(id);
        }

        // POST: api/country
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/country/5
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
