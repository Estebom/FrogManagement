using System.ComponentModel.DataAnnotations;

namespace FrogManagement.Data.Models
{
    public class Frog
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal? JumpHeight { get; set; }
        public decimal? Weight { get; set; }
    }
}
