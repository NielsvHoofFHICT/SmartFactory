using challenge_2_factory.Domain.Models;

namespace challenge_2_factory.Domain.Interfaces
{

    public interface IMetricRepository
    {
        Task<IEnumerable<Metric>> GetAllAsync();
        Task<Metric> GetByIdAsync(int id);
        Task<Metric> AddAsync(Metric metric);
        Task UpdateAsync(Metric metric);
        Task DeleteAsync(int id);
        Task<IEnumerable<Metric>> GetByCategoryAsync(string category);
        Task<IEnumerable<Metric>> GetBySourceAsync(string source);
        Task<IEnumerable<Metric>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Metric>> GetByNameAsync(string name);
    }
}