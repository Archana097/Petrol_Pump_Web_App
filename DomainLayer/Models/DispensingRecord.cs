namespace Petrol_Pump_Web_API.DomainLayer.Models
{
    public class DispensingRecord
    {
        public int Id { get; set; }
        public string DispenserNo { get; set; }
        public decimal QuantityFilled { get; set; }
        public string VehicleNumber { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentProofPath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
