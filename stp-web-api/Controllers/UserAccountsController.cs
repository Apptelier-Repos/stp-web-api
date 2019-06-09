using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace stp_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private IConfiguration Configuration;
        private IDbConnection Connection;

        public UserAccountsController(IConfiguration configuration, IDbConnection connection)
        {
            Configuration = configuration;
            Connection = connection;
        }
    }
}