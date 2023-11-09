using BlazorWASM.Server.DB.Alerts;
using BlazorWASM.Server.DB.Devices;
using BlazorWASM.Server.DB.Users;

namespace BlazorWASM.Server.DB.Locations
{
    public class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public List<Alert> Alerts { get; internal set; }
        public List<Device> Devices { get; internal set; }
        public List<User> Users { get; internal set; }
    }
}
