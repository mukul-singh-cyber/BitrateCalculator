using Bitrate;
using Newtonsoft.Json;

string input1 = @"{
""Device"": ""Arista"",
""Model"": ""X-Video"",
""NIC"": [{
""Description"": ""Linksys ABR"",
""MAC"": ""14:91:82:3C:D6:7D"",
""Timestamp"": ""2020-03-23T18:25:43.511Z"",
""Rx"": ""3698574500"",
""Tx"": ""122558800""
}]
}";

string input2 = @"{
""Device"": ""Arista"",
""Model"": ""X-Video"",
""NIC"": [{
""Description"": ""Linksys ABR"",
""MAC"": ""14:91:82:3C:D6:7D"",
""Timestamp"": ""2020-03-23T18:25:43.511Z"",
""Rx"": ""3699574500"",
""Tx"": ""122558800""
}]
}";

TransmissionStats? transmissionStats1 = JsonConvert.DeserializeObject<TransmissionStats>(value: input1);
TransmissionStats? transmissionStats2 = JsonConvert.DeserializeObject<TransmissionStats>(value: input2);

if (transmissionStats1 == null || transmissionStats2 == null)
{
    throw new ArgumentNullException("TransmissionStats object(s) cannot be null");
}

BitrateCalculator bitrateCalculator = new BitrateCalculator(2.0);

double rxBitrate = bitrateCalculator.CalculateRxBitrate(transmissionStats1.NIC[0], transmissionStats2.NIC[0]);
double txBitrate = bitrateCalculator.CalculateTxBitrate(transmissionStats1.NIC[0], transmissionStats2.NIC[0]);

Console.WriteLine($"Rx Bitrate: {rxBitrate} bps");
Console.WriteLine($"Tx Bitrate: {txBitrate} bps");
