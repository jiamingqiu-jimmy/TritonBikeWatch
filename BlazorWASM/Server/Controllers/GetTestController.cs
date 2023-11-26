using BlazorWASM.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWASM.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetTestController
    {
        public IEnumerable<Location> Get()
        {
            var x = new List<Location>()
            {
                new Location()
                {
                    Id = "1",
                    LocationName = "TestLocation!",
                    LocationDescription = "This is a test location.",
                }
            };
            return x;
        }
    }
}
