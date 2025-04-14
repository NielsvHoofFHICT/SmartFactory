
namespace challenge_2_factory.Domain.Models
{
    public class Metric
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Value { get; set; }
        public required string Unit { get; set; }
        public DateTime Timestamp { get; set; }
        public required string Source { get; set; }

        public required string Category { get; set; }
        public required string Notes { get; set; }
    }
}
