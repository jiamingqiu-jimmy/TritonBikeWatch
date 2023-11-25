using BlazorWASM.Server.DB.Alerts;
using BlazorWASM.Server.DB.Locations;

namespace BlazorWASM.Server.DB.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Permissions { get; set; }
        public Location Location { get; internal set; }
        public List<Alert> Alerts { get; internal set; }
    }
}
