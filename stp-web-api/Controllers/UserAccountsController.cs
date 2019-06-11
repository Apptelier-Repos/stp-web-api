using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace stp_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly IDbConnection _connection;

        public UserAccountsController(IDbConnection connection)
        {
            _connection = connection;
        }

        // POST api/useraccounts/authenticate
        [HttpPost("authenticate")]
        public ActionResult Authenticate([FromBody] DTOs.UserCredentials userCredentials)
        {
            var userAccount = new stp.data.Repository(_connection).FindUserAccountByUsernameAndPassword(userCredentials.Username, userCredentials.Password);
            if (userAccount == null)
                return BadRequest(new {message = "Incorrect username and/or password."});

            return Ok();
        }
    }
}