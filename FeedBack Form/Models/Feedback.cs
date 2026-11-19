
using System.ComponentModel.DataAnnotations;

namespace FeedbackManagement.Models
{
    public class Feedback
    {
        [Required(ErrorMessage = "Enrollment No is required")]
        public string EnrollmentNo { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }

        [Range(1, 5, ErrorMessage = "Please select a rating")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; }
    }
}
