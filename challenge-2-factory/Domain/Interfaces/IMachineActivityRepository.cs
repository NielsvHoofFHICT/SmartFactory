using challenge_2_factory.Domain.Models;

namespace challenge_2_factory.Domain.Interfaces
{
    public interface IMachineActivityRepository
    {
        Task<IEnumerable<MachineActivity>> GetAllAsync();

        Task<MachineActivity> GetByIdAsync(int id);

        Task<MachineActivity> AddAsync(MachineActivity activity);

        Task UpdateAsync(MachineActivity activity);

        Task DeleteAsync(int id);

        Task<IEnumerable<MachineActivity>> SearchByMachineNameAsync(string machineName);

        Task<IEnumerable<MachineActivity>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}