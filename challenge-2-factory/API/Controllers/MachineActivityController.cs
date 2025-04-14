using challenge_2_factory.Domain.Interfaces;
using challenge_2_factory.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace challenge_2_factory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachineActivityController(IMachineActivityRepository repository) : ControllerBase
    {
        private readonly IMachineActivityRepository _repository = repository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineActivity>>> GetAll()
        {
            var activities = await _repository.GetAllAsync();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MachineActivity>> GetById(int id)
        {
            var activity = await _repository.GetByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }

        [HttpPost]
        public async Task<ActionResult<MachineActivity>> Create(MachineActivity activity)
        {
            var createdActivity = await _repository.AddAsync(activity);
            return CreatedAtAction(nameof(GetById), new { id = createdActivity.Id }, createdActivity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MachineActivity activity)
        {
            if (id != activity.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.UpdateAsync(activity);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<MachineActivity>>> SearchByMachineName([FromQuery] string machineName)
        {
            var activities = await _repository.SearchByMachineNameAsync(machineName);
            return Ok(activities);
        }

        [HttpGet("date-range")]
        public async Task<ActionResult<IEnumerable<MachineActivity>>> GetByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            var activities = await _repository.GetByDateRangeAsync(startDate, endDate);
            return Ok(activities);
        }
    }
} 