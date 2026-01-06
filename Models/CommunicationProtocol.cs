using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class CommunicationProtocol(int CommunicationProtocolID, string Protocol, string? description = null)
    {
        // Properties  
        [Key]
        public int CommunicationProtocolID { get; set; } = CommunicationProtocolID;
        public string Protocol { get; set; } = Protocol;
        public string? Description { get; set; } = description;
    }

    // add seed data for CommunicationProtocol as a list
    public static class CommunicationProtocolSeedData
    {
        public static List<CommunicationProtocol> GetCommunicationProtocols()
        {
            return new List<CommunicationProtocol>
            {
                new CommunicationProtocol(1, "Zigbee", "Low-power, low-data-rate wireless mesh network"),
                new CommunicationProtocol(2, "WiFi", "Wireless networking technology"),
                new CommunicationProtocol(3, "LoRa", "Long-range, low-power wireless technology"),
                new CommunicationProtocol(4, "NB-IoT", "Narrowband IoT for low-power wide-area networks"),
                new CommunicationProtocol(5, "Bluetooth", "Short-range wireless technology")
            };
        }

    }
}

