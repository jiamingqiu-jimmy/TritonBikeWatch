using BlazorWASM.Server.DB.Devices;
using BlazorWASM.Server.DB.Locations;
using BlazorWASM.Server.DB.Users;

namespace BlazorWASM.Server.DB.Alerts
{
    public class Alert
    {
        public int Id { get; set; }
        public string AlertType { get; set; }
        public string AlertMessage { get; set; }
        public DateTime AlertTime { get; set; }
        public User User { get; internal set; }
        public Device Device { get; internal set; }
        public Location Location { get; internal set; }
    }
}
