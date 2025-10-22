using System.ComponentModel.DataAnnotations;

namespace ProgPOE.Models
{
    public class Claim
    {
        [Key]
        public int ClaimId { get; set; }              
        public string Status { get; set; }        
        public string Documentation { get; set; }  
        public double Hours { get; set; }  
        public string Lecturer { get; set; }
        public decimal Rate { get; set; }

        public string? Notes { get; set; }

        public string? FileName { get; set; }
        public string? FilePath { get; set; } 
    }
}
