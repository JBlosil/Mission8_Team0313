using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission8_Team0313.Models
{
    public class Tasks
    {
        [Required]
        [Key]
        public int TaskID { get; set; }

        [Required]
        public string Task { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        public int Category { get; set; }

        public int Completed { get; set; }
    }
}
