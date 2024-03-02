using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission8_Team0313.Models
{
    public class Action
    {
        [Required]
        [Key]
        public int TaskID { get; set; }

        [Required(ErrorMessage = "Task is required.")]
        public string Task { get; set; }

        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Quadrant is required.")]
        public int Quadrant { get; set; }

		[ForeignKey("CategoryId")]
		public int? CategoryId { get; set; }
		public Category? Category { get; set; }

		public int? Completed { get; set; }
    }
}
