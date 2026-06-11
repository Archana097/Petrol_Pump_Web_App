using Petrol_Pump_Web_API.DomainLayer.Models;

namespace Petrol_Pump_Web_API.InfrastructureLayer.Interfaces
{
    public interface IDispensingRepository
    {
        Task AddAsync(DispensingRecord record);
        Task<List<DispensingRecord>> GetAllAsync(string? dispenserNo,
    string? paymentMode,
    DateTime? startDate,
    DateTime? endDate);
    }
}
