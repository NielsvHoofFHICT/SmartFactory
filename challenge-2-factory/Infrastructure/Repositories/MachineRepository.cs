using challenge_2_factory.Domain.Enums;
using challenge_2_factory.Domain.Interfaces;
using challenge_2_factory.Domain.Models;
using challenge_2_factory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace challenge_2_factory.Infrastructure.Repositories;

public class MachineRepository(FactoryDbContext context) : IMachineRepository
{
    public async Task<IEnumerable<Machine>> GetAllMachinesAsync()
    {
        return await context.Machines.ToListAsync();
    }

    public async Task<Machine?> GetMachineByIdAsync(int id)
    {
        return await context.Machines.FindAsync(id) ?? throw new Exception("Machine activity not found");
    }

    public async Task<Machine?> GetMachineByNameAsync(string name)
    {
        return await context.Machines.FirstOrDefaultAsync(m => m.Name == name) ??
               throw new Exception("Machine not found");
    }

    public async Task<Machine?> GetMachineByTypeAsync(MachineType type)
    {
        return await context.Machines.FirstOrDefaultAsync(m => m.Type == type);
    }

    public async Task<Machine?> GetMachineByStatusAsync(MachineStatus status)
    {
        return await context.Machines.FirstOrDefaultAsync(m => m.Status == status);
    }

    public async Task<Machine?> GetMachineByLocationAsync(string location)
    {
        return await context.Machines.FirstOrDefaultAsync(m => m.Location == location);
    }

    public async Task<Machine?> GetMachineByManufacturerAsync(string manufacturer)
    {
        return await context.Machines.FirstOrDefaultAsync(m => m.Manufacturer == manufacturer);
    }

    public async Task<Machine?> GetMachineByModelAsync(string model)
    {
        return await context.Machines.FirstOrDefaultAsync(m => m.Model == model) ??
               throw new Exception("Machine not found");
    }

    public async Task<Machine> AddAsync(Machine machine)
    {
        context.Machines.Add(machine);
        await context.SaveChangesAsync();
        return machine;
    }

    public async Task UpdateAsync(Machine machine)
    {
        context.Entry(machine).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var machine = await context.Machines.FindAsync(id);
        if (machine != null)
        {
            context.Machines.Remove(machine);
            await context.SaveChangesAsync();
        }
    }
}