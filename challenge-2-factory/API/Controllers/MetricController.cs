using challenge_2_factory.Domain.Interfaces;
using challenge_2_factory.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace challenge_2_factory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetricController(IMetricRepository repository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Metric>>> GetAll()
        {
            var metrics = await repository.GetAllAsync();
            return Ok(metrics);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Metric>> GetById(int id)
        {
            var metric = await repository.GetByIdAsync(id);
            return Ok(metric);
        }

        [HttpPost]
        public async Task<ActionResult<Metric>> Create(Metric metric)
        {
            var createdMetric = await repository.AddAsync(metric);
            return CreatedAtAction(nameof(GetById), new { id = createdMetric.Id }, createdMetric);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Metric metric)
        {
            if (id != metric.Id)
            {
                return BadRequest();
            }

            try
            {
                await repository.UpdateAsync(metric);
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

        [HttpGet("category/{category}")]
        public async Task<ActionResult<IEnumerable<Metric>>> GetByCategory(string category)
        {
            var metrics = await repository.GetByCategoryAsync(category);
            return Ok(metrics);
        }

        [HttpGet("source/{source}")]
        public async Task<ActionResult<IEnumerable<Metric>>> GetBySource(string source)
        {
            var metrics = await repository.GetBySourceAsync(source);
            return Ok(metrics);
        }

        [HttpGet("date-range")]
        public async Task<ActionResult<IEnumerable<Metric>>> GetByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            var metrics = await repository.GetByDateRangeAsync(startDate, endDate);
            return Ok(metrics);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Metric>>> GetByName([FromQuery] string name)
        {
            var metrics = await repository.GetByNameAsync(name);
            return Ok(metrics);
        }
    }
} 