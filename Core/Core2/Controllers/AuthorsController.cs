using AutoMapper;
using Core2.Entities;
using Core2.Helpers;
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
        public IActionResult GetAuthors(AuthorsResourceParameters authorsResourceParameters)
        {
            return Ok(_libraryRepository
                .GetAuthors(authorsResourceParameters)
                .Select(Mapper.Map<Author, AuthorDto>));
        }

        [HttpGet("{authorId}", Name = "GetNewAuthor")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var author = _libraryRepository.GetAuthor(authorId);
            if (author == null)
                return NotFound();

            return Ok(Mapper.Map<AuthorDto>(author));
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorForCreationDto authorForCreation)
        {
            if (authorForCreation == null)
                return BadRequest();

            var authorInDb = Mapper.Map<Author>(authorForCreation);
            _libraryRepository.AddAuthor(authorInDb);

            if (!_libraryRepository.Save())
                throw new Exception("Something went wrong.");

            return CreatedAtRoute("GetNewAuthor",
                new {authorId = authorInDb.Id},
                Mapper.Map<AuthorDto>(authorInDb));
        }

        [HttpPost("{id}")]
        public IActionResult BlockAuthorCreation(Guid id)
        {
            if (_libraryRepository.AuthorExists(id))
                return Conflict();

            return NotFound();
        }

        [HttpDelete("{authorId}")]
        public IActionResult DeleteAuthor(Guid authorId)
        {
            var author = _libraryRepository.GetAuthor(authorId);

            if (author == null)
                return NotFound();

            _libraryRepository.DeleteAuthor(author);

            if(!_libraryRepository.Save())
                throw new Exception();

            return NoContent();
        }
    }
}
