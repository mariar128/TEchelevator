using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace TenmoServer.Models
{
    // Enumerations needed by transfers
    public enum TransferType
    {
        Request = 1,
        Send = 2
    }

    public enum TransferStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }

    public class Transfer
    {
        public int TransferId { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))] //optional: sends string instead of int
        public TransferType TransferType { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))] //optional: sends string instead of int
        public TransferStatus TransferStatus { get; set; }
        [Required]
        public Account AccountFrom { get; set; }
        [Required]
        public Account AccountTo { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
