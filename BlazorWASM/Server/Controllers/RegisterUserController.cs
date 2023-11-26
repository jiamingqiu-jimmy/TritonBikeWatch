using BlazorWASM.Server.DB;
using BlazorWASM.Server.DB.Users;
using BlazorWASM.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace BlazorWASM.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
    public class RegisterUserController
    {
        private readonly CosmosConfigurationProvider _cosmosConfigurationProvider;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        private readonly string? _endpointUri;
        private readonly string? _primaryKey;

        public RegisterUserController(
            CosmosConfigurationProvider cosmosConfigurationProvider,
                       IHttpContextAccessor contextAccessor,
                       IConfiguration configuration)
        {
            _cosmosConfigurationProvider = cosmosConfigurationProvider;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
            
        }

        [HttpPost]
        public void Post()
        {
            using (var context = new UserContext(_cosmosConfigurationProvider))
            {
                var user = new User
                {
                    Email = "Hello!"
                };
            }
            throw new NotImplementedException();
        }
    }
}
