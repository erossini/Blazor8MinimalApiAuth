namespace MinimalAPIAuth.Shared.Models
{
    public class Client
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
    }
}