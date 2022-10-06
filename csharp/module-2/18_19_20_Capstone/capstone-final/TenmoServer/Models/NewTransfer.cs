using System.ComponentModel.DataAnnotations;

namespace TenmoServer.Models
{
    [CustomValidation(typeof(NewTransferValidator), "ValidateUsers")]
    public class NewTransfer
    {
        public int UserFrom { get; set; }
        public int UserTo { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero")]
        public decimal Amount { get; set; }
        public TransferType TransferType { get; set; }
    }
}
