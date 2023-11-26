namespace BlazorWASM.Shared
{
    public class Device
    {
        public string Id { get; set; }
        public string PartitionKey { get; set; }
        public string DeviceType { get; set; }
        public string DeviceName { get; set; }
        public string DeviceDescription { get; set; }
        public string DeviceStatus { get; set; }
        public string LocationId { get; set; }
        public Location Location { get; internal set; }
        public List<Alert> Alerts { get; internal set; }
    }
}
