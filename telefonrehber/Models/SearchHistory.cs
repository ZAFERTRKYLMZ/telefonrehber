using System.ComponentModel.DataAnnotations;

namespace telefonrehber.Models
{
    public class SearchHistory
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Keyword { get; set; }

        [Required]
        public DateTime SearchDate { get; set; }
    }
}
