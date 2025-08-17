using System.ComponentModel.DataAnnotations;

namespace Api.Src.Infrastructure.Sqlite.Models
{
    public class iBaseModal
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}