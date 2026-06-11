using Petrol_Pump_Web_API.ApplicationLayer.DTOS;
using Petrol_Pump_Web_API.DomainLayer.Models;
using Petrol_Pump_Web_API.InfrastructureLayer.Interfaces;

namespace Petrol_Pump_Web_API.ApplicationLayer.Services
{
    public class DispensingService
    {
        private readonly IDispensingRepository _repo;
       

        public DispensingService(IDispensingRepository repo)
        {
            _repo = repo;
        }

        public async Task AddRecord(DispensingDto dto)
        {
            string filePath = "";

            if (dto.PaymentProofPath != null)
            {
               var folder = Path.Combine(
    Directory.GetCurrentDirectory(),
    "uploads"
);
                Directory.CreateDirectory(folder);

                filePath = Path.Combine("uploads", Guid.NewGuid() + dto.PaymentProofPath.FileName);

                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await dto.PaymentProofPath.CopyToAsync(stream);
                }
            }

            var record = new DispensingRecord
            {
                DispenserNo = dto.DispenserNo,
                QuantityFilled = dto.QuantityFilled,
                VehicleNumber = dto.VehicleNumber,
                PaymentMode = dto.PaymentMode,
                PaymentProofPath = filePath
            };

            await _repo.AddAsync(record);
        }

        public Task<List<DispensingRecord>> GetAll(string? dispenserNo,
    string? paymentMode,
    DateTime? startDate,
    DateTime? endDate)
        {
            return _repo.GetAllAsync(dispenserNo,paymentMode,startDate,endDate);
        }
    }
}
