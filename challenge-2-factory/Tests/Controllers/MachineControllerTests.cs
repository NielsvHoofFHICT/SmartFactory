using challenge_2_factory.API.Controllers;
using challenge_2_factory.Domain.Enums;
using challenge_2_factory.Domain.Interfaces;
using challenge_2_factory.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace challenge_2_factory.Tests.Controllers
{
    public class MachineControllerTests
    {
        private readonly Mock<IMachineRepository> _mockRepository;
        private readonly MachineController _controller;

        public MachineControllerTests()
        {
            _mockRepository = new Mock<IMachineRepository>();
            _controller = new MachineController(_mockRepository.Object);
        }

        private static Machine CreateTestMachine(int id, string name, MachineType type, MachineStatus status)
        {
            return new Machine
            {
                Id = id,
                Name = name,
                Type = type,
                Status = status,
                Location = "Test Location",
                Manufacturer = "Test Manufacturer",
                Model = "Test Model",
                PurchaseDate = DateTime.Now,
                LastMaintenanceDate = DateTime.Now,
                Notes = "Test Notes"
            };
        }

        [Fact]
        public async Task GetAll_ReturnsOkResultWithMachines()
        {
            var machines = new List<Machine>
            {
                CreateTestMachine(1, "Machine1", MachineType.DrillPress, MachineStatus.Active),
                CreateTestMachine(2, "Machine2", MachineType.Lathe, MachineStatus.Inactive)
            };
            _mockRepository.Setup(repo => repo.GetAllMachinesAsync()).ReturnsAsync(machines);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedMachines = Assert.IsType<List<Machine>>(okResult.Value);
            Assert.Equal(2, returnedMachines.Count);
        }

        [Fact]
        public async Task GetById_ExistingId_ReturnsOkResult()
        {
            var machine = CreateTestMachine(1, "Machine1", MachineType.DrillPress, MachineStatus.Active);
            _mockRepository.Setup(repo => repo.GetMachineByIdAsync(1)).ReturnsAsync(machine);

            var result = await _controller.GetById(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedMachine = Assert.IsType<Machine>(okResult.Value);
            Assert.Equal(1, returnedMachine.Id);
        }

        [Fact]
        public async Task GetByName_ExistingName_ReturnsOkResult()
        {
            var machine = CreateTestMachine(1, "Machine1", MachineType.DrillPress, MachineStatus.Active);
            _mockRepository.Setup(repo => repo.GetMachineByNameAsync("Machine1")).ReturnsAsync(machine);

            var result = await _controller.GetByName("Machine1");

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedMachine = Assert.IsType<Machine>(okResult.Value);
            Assert.Equal("Machine1", returnedMachine.Name);
        }

        [Fact]
        public async Task Create_ValidMachine_ReturnsCreatedAtAction()
        {
            var newMachine = CreateTestMachine(0, "NewMachine", MachineType.DrillPress, MachineStatus.Active);
            var createdMachine = CreateTestMachine(1, "NewMachine", MachineType.DrillPress, MachineStatus.Active);
            _mockRepository.Setup(repo => repo.AddAsync(newMachine)).ReturnsAsync(createdMachine);

            var result = await _controller.Create(newMachine);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedMachine = Assert.IsType<Machine>(createdAtActionResult.Value);
            Assert.Equal(1, returnedMachine.Id);
        }

        [Fact]
        public async Task Update_ValidMachine_ReturnsNoContent()
        {
            var machine = CreateTestMachine(1, "UpdatedMachine", MachineType.DrillPress, MachineStatus.Active);
            _mockRepository.Setup(repo => repo.UpdateAsync(machine)).Returns(Task.CompletedTask);

            var result = await _controller.Update(1, machine);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ExistingId_ReturnsNoContent()
        {
            _mockRepository.Setup(repo => repo.DeleteAsync(1)).Returns(Task.CompletedTask);

            var result = await _controller.Delete(1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}