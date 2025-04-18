using challenge_2_factory.Domain.Enums;
using challenge_2_factory.Domain.Interfaces;
using challenge_2_factory.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace challenge_2_factory.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MachineController(IMachineRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Machine>>> GetAll()
    {
        var machines = await repository.GetAllMachinesAsync();

        return Ok(machines);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Machine>> GetById(int id)
    {
        var machine = await repository.GetMachineByIdAsync(id);

        return Ok(machine);
    }

    [HttpGet("name/{name}")]
    public async Task<ActionResult<Machine>> GetByName(string name)
    {
        var machine = await repository.GetMachineByNameAsync(name);

        return Ok(machine);
    }

    [HttpGet("type/{type}")]
    public async Task<ActionResult<Machine>> GetByType(string type)
    {
        var machine = await repository.GetMachineByTypeAsync(Enum.Parse<MachineType>(type));

        return Ok(machine);
    }

    [HttpGet("status/{status}")]
    public async Task<ActionResult<Machine>> GetByStatus(string status)
    {
        var machine = await repository.GetMachineByStatusAsync(Enum.Parse<MachineStatus>(status));

        return Ok(machine);
    }

    [HttpGet("location/{location}")]
    public async Task<ActionResult<Machine>> GetByLocation(string location)
    {
        var machine = await repository.GetMachineByLocationAsync(location);

        return Ok(machine);
    }

    [HttpGet("manufacturer/{manufacturer}")]
    public async Task<ActionResult<Machine>> GetByManufacturer(string manufacturer)
    {
        var machine = await repository.GetMachineByManufacturerAsync(manufacturer);

        return Ok(machine);
    }

    [HttpGet("model/{model}")]
    public async Task<ActionResult<Machine>> GetByModel(string model)
    {
        var machine = await repository.GetMachineByModelAsync(model);

        return Ok(machine);
    }

    [HttpPost]
    public async Task<ActionResult<Machine>> Create(Machine machine)
    {
        var createdMachine = await repository.AddAsync(machine);

        return CreatedAtAction(nameof(GetById), new { id = createdMachine.Id }, createdMachine);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Machine machine)
    {
        if (id != machine.Id)
        {
            return BadRequest();
        }

        try
        {
            await repository.UpdateAsync(machine);
        }
        catch
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await repository.DeleteAsync(id);

        return NoContent();
    }
}