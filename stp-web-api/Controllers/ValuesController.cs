using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace stp_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;

        public ValuesController(IConfiguration configuration, IDbConnection connection)
        {
            _configuration = configuration;
            _connection = connection;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<stp.data.DTOs.UserAccount>> Get()
        {
            var userAccounts = new stp.data.Repository(_connection).GetAllUserAccounts().ToList();
            if (!userAccounts.Any())
                return NoContent();
            return userAccounts.ToArray();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
