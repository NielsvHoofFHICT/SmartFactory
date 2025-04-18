using challenge_2_factory.Domain.Enums;
using challenge_2_factory.Domain.Models;

namespace challenge_2_factory.Domain.Interfaces;

public interface IMachineRepository
{
    public Task<IEnumerable<Machine>> GetAllMachinesAsync();
    public Task<Machine?> GetMachineByIdAsync(int id);
    public Task<Machine?> GetMachineByNameAsync(string name);
    public Task<Machine?> GetMachineByTypeAsync(MachineType type);
    public Task<Machine?> GetMachineByStatusAsync(MachineStatus status);
    public Task<Machine?> GetMachineByLocationAsync(string location);
    public Task<Machine?> GetMachineByManufacturerAsync(string manufacturer);
    public Task<Machine?> GetMachineByModelAsync(string model);

    public Task<Machine> AddAsync(Machine machine);

    public Task UpdateAsync(Machine machine);

    public Task DeleteAsync(int id);
}