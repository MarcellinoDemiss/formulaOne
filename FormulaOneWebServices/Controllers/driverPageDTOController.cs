using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FormulaOneWebServices
{
    [Route("api/driverPage")]
    [ApiController]
    public class driverPageDTOController : ControllerBase
    {
        // GET: api/driver
        [HttpGet]
        public IEnumerable<DriverPageDTO> Get()
        {
            DBTools db = new DBTools();
            return db.getDriversList();
        }

        // GET: api/driver
        [HttpGet("number/{number}")]
        public DriverDetailsDTO Get(int number)
        {
            DBTools db = new DBTools();
            return db.getDriversDetails(number);
        }
    }
}
