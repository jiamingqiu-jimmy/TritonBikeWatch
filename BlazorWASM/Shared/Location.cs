using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BlazorWASM.Shared
{
    public class Location
    {
        public string Id { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public List<Alert> Alerts { get; internal set; }
        public List<Device> Devices { get; internal set; }
        public List<User> Users { get; internal set; }
    }
}
