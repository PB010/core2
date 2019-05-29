using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core2.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTimeOffset DateOfBirth { get; set; }
        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }

        public ICollection<Book> Books { get; set; }
         = new List<Book>();

        public int GetAge()
        {
            var currentDate = DateTime.UtcNow;
            var age = currentDate.Year - DateOfBirth.Year;

            if (currentDate < DateOfBirth.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
