using challenge_2_factory.Domain.Interfaces;
using challenge_2_factory.Domain.Models;
using challenge_2_factory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace challenge_2_factory.Infrastructure.Repositories
{
    public class MachineActivityRepository(FactoryDbContext context) : IMachineActivityRepository
    {
        public async Task<IEnumerable<MachineActivity>> GetAllAsync()
        {
            return await context.MachineActivities.ToListAsync();
        }

        public async Task<MachineActivity> GetByIdAsync(int id)
        {
            return await context.MachineActivities.FindAsync(id) ?? throw new Exception("Machine activity not found");
        }

        public async Task<MachineActivity> AddAsync(MachineActivity activity)
        {
            context.MachineActivities.Add(activity);
            await context.SaveChangesAsync();
            return activity;
        }

        public async Task UpdateAsync(MachineActivity activity)
        {
            context.Entry(activity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var activity = await context.MachineActivities.FindAsync(id);
            if (activity != null)
            {
                context.MachineActivities.Remove(activity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MachineActivity>> SearchByMachineNameAsync(string machineName)
        {
            return await context.MachineActivities
                .Where(a => a.MachineName.Contains(machineName))
                .ToListAsync();
        }

        public async Task<IEnumerable<MachineActivity>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await context.MachineActivities
                .Where(a => a.StartTime >= startDate && a.StartTime <= endDate)
                .ToListAsync();
        }
    }
} 