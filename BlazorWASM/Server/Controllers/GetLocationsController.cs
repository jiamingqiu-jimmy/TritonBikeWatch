using BlazorWASM.Server.DB;
using BlazorWASM.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.Diagnostics;

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
            Debug.WriteLine(_appDbContext.Locations.ToList());
            return _appDbContext.Locations.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] LocationDTO location)
        {
            Location testLocation = new Location()
            {
                Id = "1",
                LocationName = "TestLocation!",
                LocationDescription = "This is a test location.",
            };
            testLocation.PartitionKey = testLocation.Id;

            await _appDbContext.Locations.AddAsync(testLocation);
            await _appDbContext.SaveChangesAsync();
            return Ok("Location added successfully.");
        }

    }
}