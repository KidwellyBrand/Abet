namespace ABet.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public double Balance { get; set; } = 1000.0; // начальный баланс
    }
}
