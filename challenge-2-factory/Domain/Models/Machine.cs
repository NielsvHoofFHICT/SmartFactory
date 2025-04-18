using challenge_2_factory.Domain.Enums;

namespace challenge_2_factory.Domain.Models;

public class Machine
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required MachineType Type { get; set; }
    public required MachineStatus Status { get; set; }
    public required string Location { get; set; }
    public required string Manufacturer { get; set; }
    public required string Model { get; set; }
    public required DateTime PurchaseDate { get; set; }
    public required DateTime LastMaintenanceDate { get; set; }
    public required string Notes { get; set; }
}