namespace CleanArch.Domain.Models
{
    public abstract class BaseModel
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
