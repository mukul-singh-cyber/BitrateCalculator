using Newtonsoft.Json;

namespace Bitrate
{
    /// <summary>
    /// Contains information about a Network Interface Card (NIC).
    /// </summary>
    public class NIC
    {
        [JsonRequired]
        public required string Description { get; set; }

        [JsonRequired]
        public required string MAC { get; set; }

        [JsonRequired]
        public DateTime Timestamp { get; set; }

        [JsonRequired]
        public required string Rx { get; set; }

        [JsonRequired]
        public required string Tx { get; set; }
    }
}
