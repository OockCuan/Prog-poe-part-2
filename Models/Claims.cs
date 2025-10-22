using System.ComponentModel.DataAnnotations;

namespace ProgPOE.Models
{
    public class Claims
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ClaimNumber { get; set; } = "";
        [Required]
        public string Status { get; set; } = "";
        [Required]
        public double TotalOvertime { get; set; }
    }
}
