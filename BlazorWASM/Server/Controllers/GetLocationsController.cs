using BlazorWASM.Server.DB;
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
    public class GetLocationsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public GetLocationsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return _appDbContext.Locations.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] LocationDTO location)
        {
            Location testLocation = new Location()
            {
                Id = Guid.NewGuid().ToString(),
                LocationName = location.LocationName,
                LocationDescription = location.LocationDescription,
            };

            await _appDbContext.Locations.AddAsync(testLocation);
            await _appDbContext.SaveChangesAsync();
            return Ok("Location added successfully.");
        }

    }
}