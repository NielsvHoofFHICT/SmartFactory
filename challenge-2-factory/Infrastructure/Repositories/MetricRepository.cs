using challenge_2_factory.Domain.Interfaces;
using challenge_2_factory.Domain.Models;
using challenge_2_factory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace challenge_2_factory.Infrastructure.Repositories
{
    public class MetricRepository(FactoryDbContext context) : IMetricRepository
    {
        private readonly FactoryDbContext _context = context;

        public async Task<IEnumerable<Metric>> GetAllAsync()
        {
            return await _context.Metrics.ToListAsync();
        }

        public async Task<Metric> GetByIdAsync(int id)
        {
            return await _context.Metrics.FindAsync(id) ?? throw new Exception("Metric not found");
        }

        public async Task<Metric> AddAsync(Metric metric)
        {
            _context.Metrics.Add(metric);
            await _context.SaveChangesAsync();
            return metric;
        }

        public async Task UpdateAsync(Metric metric)
        {
            _context.Entry(metric).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var metric = await _context.Metrics.FindAsync(id);
            if (metric != null)
            {
                _context.Metrics.Remove(metric);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Metric>> GetByCategoryAsync(string category)
        {
            return await _context.Metrics
                .Where(m => m.Category == category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Metric>> GetBySourceAsync(string source)
        {
            return await _context.Metrics
                .Where(m => m.Source == source)
                .ToListAsync();
        }

        public async Task<IEnumerable<Metric>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Metrics
                .Where(m => m.Timestamp >= startDate && m.Timestamp <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Metric>> GetByNameAsync(string name)
        {
            return await _context.Metrics
                .Where(m => m.Name.Contains(name))
                .ToListAsync();
        }
    }
}