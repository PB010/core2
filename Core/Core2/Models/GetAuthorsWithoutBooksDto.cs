using System;

namespace Core2.Models
{
    public class GetAuthorsWithoutBooksDto  
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
    }
}
