﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core2.Models
{
    public class AuthorForCreationDto
    {
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
        public ICollection<BookForCreationDto> Books { get; set; }
        = new List<BookForCreationDto>();
    }
}
