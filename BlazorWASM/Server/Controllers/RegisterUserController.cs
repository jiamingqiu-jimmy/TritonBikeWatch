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
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        private readonly string? _endpointUri;
        private readonly string? _primaryKey;

        public RegisterUserController(
                       IHttpContextAccessor contextAccessor,
                       IConfiguration configuration)
        {
            _contextAccessor = contextAccessor;
            _configuration = configuration;
            
        }

        [HttpPost]
        public void Post()
        {
            throw new NotImplementedException();
        }
    }
}
