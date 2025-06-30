namespace ABet.Models
{
    public class Bet
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MatchId { get; set; }
        public string Prediction { get; set; } // "TeamA", "TeamB", "Draw"
        public double Amount { get; set; }
        public bool IsResolved { get; set; }
        public bool IsWin { get; set; }
    }
}
