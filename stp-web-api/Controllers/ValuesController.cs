using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using stp_web_api.Pocos;

namespace stp_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IConfiguration configuration;
        IDbConnection connection;

        #region Ctor

        public ValuesController(IConfiguration conf, IDbConnection conn)
        {
            configuration = conf;
            connection = conn;
        }

        #endregion

        #region Get


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<UserAccount>> Get()
        {
            var query = new StringBuilder();

            query.AppendLine("SELECT [Id]");
            query.AppendLine("      ,[CreationDate]");
            query.AppendLine("      ,[Username]");
            query.AppendLine("      ,[Password]");
            query.AppendLine("  FROM [dbo].[UsersAcount]");

            var userAccounts = connection.Query<UserAccount>(query.ToString());
            return userAccounts.ToArray();
        }

        #endregion



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
