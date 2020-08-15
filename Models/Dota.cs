using System.ComponentModel.DataAnnotations;

namespace DotaAPI.Models
{
    public class Dota
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Character { get; set; }
        [Required]
        public int Power { get; set; }
        [Required]
        public string Type { get; set; }
    }
}