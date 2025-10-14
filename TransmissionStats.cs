using Newtonsoft.Json;

namespace Bitrate
{
    /// <summary>
    /// Contains transmission statistics for a device, including its NICs.
    /// </summary>
    public class TransmissionStats
    {
        [JsonRequired]
        public required string Device { get; set; }

        [JsonRequired]
        public required string Model { get; set; }

        [JsonRequired]
        public required List<NIC> NIC { get; set; }
    }
}
