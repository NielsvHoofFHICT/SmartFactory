using challenge_2_factory.API.Controllers;
using challenge_2_factory.Domain.Interfaces;
using challenge_2_factory.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace challenge_2_factory.Tests.Controllers
{
    public class MetricControllerTests
    {
        private readonly Mock<IMetricRepository> _mockRepository;
        private readonly MetricController _controller;

        public MetricControllerTests()
        {
            _mockRepository = new Mock<IMetricRepository>();
            _controller = new MetricController(_mockRepository.Object);
        }

        private static Metric CreateTestMetric(int id, string name, string category, string source)
        {
            return new Metric
            {
                Id = id,
                Name = name,
                Category = category,
                Source = source,
                Value = 100.0,
                Timestamp = DateTime.Now,
                Unit = "Test Unit",
                Notes = "Test Notes"
            };
        }

        [Fact]
        public async Task GetAll_ReturnsOkResultWithMetrics()
        {
            var metrics = new List<Metric>
            {
                CreateTestMetric(1, "Metric1", "Performance", "Machine1"),
                CreateTestMetric(2, "Metric2", "Quality", "Machine2")
            };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(metrics);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedMetrics = Assert.IsType<List<Metric>>(okResult.Value);
            Assert.Equal(2, returnedMetrics.Count);
        }

        [Fact]
        public async Task GetById_ExistingId_ReturnsOkResult()
        {
            var metric = CreateTestMetric(1, "Metric1", "Performance", "Machine1");
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(metric);

            var result = await _controller.GetById(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedMetric = Assert.IsType<Metric>(okResult.Value);
            Assert.Equal(1, returnedMetric.Id);
        }

        [Fact]
        public async Task Create_ValidMetric_ReturnsCreatedAtAction()
        {
            var newMetric = CreateTestMetric(0, "NewMetric", "Performance", "Machine1");
            var createdMetric = CreateTestMetric(1, "NewMetric", "Performance", "Machine1");
            _mockRepository.Setup(repo => repo.AddAsync(newMetric)).ReturnsAsync(createdMetric);

            var result = await _controller.Create(newMetric);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedMetric = Assert.IsType<Metric>(createdAtActionResult.Value);
            Assert.Equal(1, returnedMetric.Id);
        }

        [Fact]
        public async Task Update_ValidMetric_ReturnsNoContent()
        {
            var metric = CreateTestMetric(1, "UpdatedMetric", "Performance", "Machine1");
            _mockRepository.Setup(repo => repo.UpdateAsync(metric)).Returns(Task.CompletedTask);

            var result = await _controller.Update(1, metric);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ExistingId_ReturnsNoContent()
        {
            _mockRepository.Setup(repo => repo.DeleteAsync(1)).Returns(Task.CompletedTask);

            var result = await _controller.Delete(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetByCategory_ReturnsOkResult()
        {
            var metrics = new List<Metric>
            {
                CreateTestMetric(1, "Metric1", "Performance", "Machine1")
            };
            _mockRepository.Setup(repo => repo.GetByCategoryAsync("Performance")).ReturnsAsync(metrics);

            var result = await _controller.GetByCategory("Performance");

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedMetrics = Assert.IsType<List<Metric>>(okResult.Value);
            Assert.Single(returnedMetrics);
        }

        [Fact]
        public async Task GetBySource_ReturnsOkResult()
        {
            var metrics = new List<Metric>
            {
                CreateTestMetric(1, "Metric1", "Performance", "Machine1")
            };
            _mockRepository.Setup(repo => repo.GetBySourceAsync("Machine1")).ReturnsAsync(metrics);

            var result = await _controller.GetBySource("Machine1");

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedMetrics = Assert.IsType<List<Metric>>(okResult.Value);
            Assert.Single(returnedMetrics);
        }

        [Fact]
        public async Task GetByDateRange_ReturnsOkResult()
        {
            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now;
            var metrics = new List<Metric>
            {
                CreateTestMetric(1, "Metric1", "Performance", "Machine1")
            };
            _mockRepository.Setup(repo => repo.GetByDateRangeAsync(startDate, endDate)).ReturnsAsync(metrics);

            var result = await _controller.GetByDateRange(startDate, endDate);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedMetrics = Assert.IsType<List<Metric>>(okResult.Value);
            Assert.Single(returnedMetrics);
        }

        [Fact]
        public async Task GetByName_ReturnsOkResult()
        {
            var metrics = new List<Metric>
            {
                CreateTestMetric(1, "Metric1", "Performance", "Machine1")
            };
            _mockRepository.Setup(repo => repo.GetByNameAsync("Metric1")).ReturnsAsync(metrics);

            var result = await _controller.GetByName("Metric1");

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedMetrics = Assert.IsType<List<Metric>>(okResult.Value);
            Assert.Single(returnedMetrics);
        }
    }
} 