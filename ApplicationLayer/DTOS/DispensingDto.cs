namespace Petrol_Pump_Web_API.ApplicationLayer.DTOS
{
    public class DispensingDto
    {
        public string DispenserNo { get; set; }
        public decimal QuantityFilled { get; set; }
        public string VehicleNumber { get; set; }
        public string PaymentMode { get; set; }
        public IFormFile PaymentProofPath { get; set; }
    }
}
