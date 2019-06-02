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
        public DateTimeOffset? DateOfDeath { get; set; }    
        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }

        public ICollection<Book> Books { get; set; }
         = new List<Book>();

        public int GetAge()
        {
            var dateToCalculateTo = DateTime.UtcNow;

            if (DateOfDeath != null)
            {
                dateToCalculateTo = DateOfDeath.Value.UtcDateTime;
            }

            var age = dateToCalculateTo.Year - DateOfBirth.Year;

            if (dateToCalculateTo < DateOfBirth.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
