using System.ComponentModel.DataAnnotations;

namespace Core2.Models
{
    public abstract class BookForManipulationDto
    {
        [Required(ErrorMessage = "You should fill out a title.")]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(400, ErrorMessage = "Description must be at most 400 characters long.")]
        public virtual string Description { get; set; }
    }
}
