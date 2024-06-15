namespace CascadeFlow.Backend.Core.Model
{
    public class User : BaseAuditedEntity
    {
        public string Username { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string RefreshToken { get; set; } 
        public DateTime RefreshTokenCreatedAt { get; set; }
        public DateTime RefreshTokenExpiresAt { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Guid TenantRef { get; set; }
        public Guid AvatarHashable { get; set; }

    }
}
