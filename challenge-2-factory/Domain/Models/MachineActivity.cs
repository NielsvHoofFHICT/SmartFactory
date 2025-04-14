
namespace challenge_2_factory.Domain.Models
{
    public class MachineActivity
    {
        public int Id { get; set; }

        public required string MachineName { get; set; }

        public required string ActivityType { get; set; }

        public required DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public required string Status { get; set; }

        public required string Notes { get; set; }
    }
}