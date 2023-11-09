using BlazorWASM.Server.DB.Alerts;
using BlazorWASM.Server.DB.Locations;

namespace BlazorWASM.Server.DB.Devices
{
    public class Device
    {
        public int Id { get; set; }
        public string DeviceType { get; set; }
        public string DeviceName { get; set; }
        public string DeviceDescription { get; set; }
        public string DeviceStatus { get; set; }
        public Location Location { get; internal set; }
        public List<Alert> Alerts { get; internal set; }
    }
}
