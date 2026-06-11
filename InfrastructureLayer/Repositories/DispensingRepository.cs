using Petrol_Pump_Web_API.DomainLayer.Data;
using Petrol_Pump_Web_API.DomainLayer.Models;
using Petrol_Pump_Web_API.InfrastructureLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Petrol_Pump_Web_API.InfrastructureLayer.Repositories
{
    public class DispensingRepository : IDispensingRepository
    {
        private readonly ApplicationDbContext _context;

        public DispensingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DispensingRecord record)
        {
            _context.DispensingRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DispensingRecord>> GetAllAsync(string? dispenserNo,
    string? paymentMode,
    DateTime? startDate,
    DateTime? endDate)
        {
            IQueryable<DispensingRecord> query = _context.DispensingRecords;

            if (!string.IsNullOrEmpty(dispenserNo))
                query = query.Where(x => x.DispenserNo == dispenserNo);

            if (!string.IsNullOrEmpty(paymentMode))
                query = query.Where(x => x.PaymentMode == paymentMode);

            if (startDate.HasValue)
                query = query.Where(x => x.CreatedAt >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(x => x.CreatedAt <= endDate.Value);

            return await query.ToListAsync();
        }

       

    }
}
