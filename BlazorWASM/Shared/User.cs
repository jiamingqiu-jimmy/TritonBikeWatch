namespace BlazorWASM.Shared
{
    public class User
    {
        public string Id { get; set; }
        public string PartitionKey { get; set; }
        public string Email { get; set; }
        public int Permissions { get; set; }
        public string LocationId { get; set; }
        public Location Location { get; internal set; }
        public List<Alert> Alerts { get; internal set; }
    }
}
