using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FormulaOneWebServices
{
    [Route("api/team")]
    [ApiController]
    public class teamController : ControllerBase
    {
        // GET: api/team
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            DBTools db = new DBTools();
            return db.GetTeamsObj();
        }

        // GET: api/team/1
        [HttpGet("id/{id}")]
        public Team Get(int id)
        {
            DBTools db = new DBTools();
            return db.GetTeamById(id);
        }

        [HttpGet("name/{name}")]
        public Team Get(string name)
        {
            DBTools db = new DBTools();
            return db.GetTeamByName(name);
        }

        // POST: api/team
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/team/5
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
