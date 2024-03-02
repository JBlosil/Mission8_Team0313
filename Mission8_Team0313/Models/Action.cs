using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission8_Team0313.Models
{
    public class Action
    {
        [Key]
        public int TaskID { get; set; }

        [Required(ErrorMessage = "Task is required.")]
        public string Task { get; set; }

        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Quadrant is required.")]
        public int Quadrant { get; set; }

		[ForeignKey("CategoryID")]
		public int? CategoryID { get; set; }
		public Category? Category { get; set; }

		public int? Completed { get; set; }
    }
}
