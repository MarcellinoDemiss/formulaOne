using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FormulaOneWebServices
{
    [Route("api/teamPage")]
    [ApiController]
    public class teamPageDTOController : ControllerBase
    {
        // GET: api/team
        [HttpGet]
        public IEnumerable<TeamPageDTO> Get()
        {
            DBTools db = new DBTools();
            return db.getTeamsList();
        }

        // GET: api/driver
        [HttpGet("id/{id}")]
        public TeamDetailsDTO Get(int id)
        {
            DBTools db = new DBTools();
            return db.getTeamsDetails(id);
        }
    }
}
