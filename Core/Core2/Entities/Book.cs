using System;
using System.ComponentModel.DataAnnotations;

namespace Core2.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
    }
}
