namespace BlazorWASM.Shared
{
    public class Alert
    {
        public string Id { get; set; }
        public string PartitionKey { get; set; }
        public string AlertType { get; set; }
        public string AlertMessage { get; set; }
        public DateTime AlertTime { get; set; }
        public string UserId { get; set; }
        public User User { get; internal set; }
        public string DeviceId { get; set; }
        public Device Device { get; internal set; }
        public string LocationId { get; set; }
        public Location Location { get; internal set; }
    }
}
