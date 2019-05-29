using AutoMapper;
using Core2.Entities;
using Core2.Models;
using Core2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Core2.Controllers
{
    [Route("/api/authors/")]
    public class AuthorsController : Controller
    {
        private readonly ILibraryRepository _libraryRepository;

        public AuthorsController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            return Ok(_libraryRepository.GetAuthors().Select(Mapper.Map<Author, GetAuthorsWithoutBooksDto>));
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var author = _libraryRepository.GetAuthor(authorId);
            if (author == null)
                return NotFound();

            return Ok(Mapper.Map<GetAuthorsWithoutBooksDto>(author));
        }
    }
}
