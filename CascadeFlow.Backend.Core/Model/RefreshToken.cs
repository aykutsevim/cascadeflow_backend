namespace CascadeFlow.Backend.Core.Model
{
    public class RefreshToken
    {
        public Guid UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ExpiresAt { get; set; }
    }
}
