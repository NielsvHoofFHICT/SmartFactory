using challenge_2_factory.API.Controllers;
using challenge_2_factory.Domain.Interfaces;
using challenge_2_factory.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;


namespace challenge_2_factory.Tests.Controllers
{
    public class MachineActivityControllerTests
    {
        private readonly Mock<IMachineActivityRepository> _mockRepository;
        private readonly MachineActivityController _controller;

        public MachineActivityControllerTests()
        {
            _mockRepository = new Mock<IMachineActivityRepository>();
            _controller = new MachineActivityController(_mockRepository.Object);
        }

        private static MachineActivity CreateTestActivity(int id, string machineName, string activityType)
        {
            return new MachineActivity
            {
                Id = id,
                MachineName = machineName,
                ActivityType = activityType,
                StartTime = DateTime.Now,
                Status = "Active",
                Notes = "Test activity"
            };
        }

        [Fact]
        public async Task GetAll_ReturnsOkResultWithActivities()
        {
            var activities = new List<MachineActivity>
            {
                CreateTestActivity(1, "Machine1", "Production"),
                CreateTestActivity(2, "Machine2", "Maintenance")
            };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(activities);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedActivities = Assert.IsType<List<MachineActivity>>(okResult.Value);
            Assert.Equal(2, returnedActivities.Count);
        }

        [Fact]
        public async Task GetById_ExistingId_ReturnsOkResult()
        {
            var activity = CreateTestActivity(1, "Machine1", "Production");
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(activity);

            var result = await _controller.GetById(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedActivity = Assert.IsType<MachineActivity>(okResult.Value);
            Assert.Equal(1, returnedActivity.Id);
        }

        [Fact]
        public async Task GetById_NonExistingId_ReturnsNotFound()
        {
            var result = await _controller.GetById(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Create_ValidActivity_ReturnsCreatedAtAction()
        {
            var newActivity = CreateTestActivity(0, "NewMachine", "Production");
            var createdActivity = CreateTestActivity(1, "NewMachine", "Production");
            _mockRepository.Setup(repo => repo.AddAsync(newActivity)).ReturnsAsync(createdActivity);

            var result = await _controller.Create(newActivity);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedActivity = Assert.IsType<MachineActivity>(createdAtActionResult.Value);
            Assert.Equal(1, returnedActivity.Id);
        }

        [Fact]
        public async Task Update_ValidActivity_ReturnsNoContent()
        {
            var activity = CreateTestActivity(1, "UpdatedMachine", "Production");
            _mockRepository.Setup(repo => repo.UpdateAsync(activity)).Returns(Task.CompletedTask);

            var result = await _controller.Update(1, activity);

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
        public async Task SearchByMachineName_ReturnsOkResultWithActivities()
        {
            var activities = new List<MachineActivity>
            {
                CreateTestActivity(1, "Machine1", "Production")
            };
            _mockRepository.Setup(repo => repo.SearchByMachineNameAsync("Machine1")).ReturnsAsync(activities);

            var result = await _controller.SearchByMachineName("Machine1");

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedActivities = Assert.IsType<List<MachineActivity>>(okResult.Value);
            Assert.Single(returnedActivities);
        }

        [Fact]
        public async Task GetByDateRange_ReturnsOkResultWithActivities()
        {
            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now;
            var activities = new List<MachineActivity>
            {
                CreateTestActivity(1, "Machine1", "Production")
            };
            _mockRepository.Setup(repo => repo.GetByDateRangeAsync(startDate, endDate)).ReturnsAsync(activities);

            var result = await _controller.GetByDateRange(startDate, endDate);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedActivities = Assert.IsType<List<MachineActivity>>(okResult.Value);
            Assert.Single(returnedActivities);
        }
    }
} 