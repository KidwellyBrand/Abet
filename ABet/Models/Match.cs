namespace ABet.Models
{
    public class Match
    {
        public Guid Id { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public double ProbA { get; set; }
        public double ProbB { get; set; }
        public double ProbDraw { get; set; }
        public DateTime StartTime { get; set; }
        public bool Finished { get; set; }
        public string? Result { get; set; } // "TeamA", "TeamB", "Draw"
    }
}
