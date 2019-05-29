using AutoMapper;
using Core2.Entities;
using Core2.Models;
using Core2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Core2.Controllers
{
    [Route("/api/authors/{authorId}/books/")]
    public class BooksController : Controller
    {
        private readonly ILibraryRepository _libraryRepository;

        public BooksController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet]
        public IActionResult GetAllBooksForAuthor(Guid authorId)
        {
            if (!_libraryRepository.AuthorExists(authorId))
                return NotFound();

            return Ok(_libraryRepository.GetBooksForAuthor(authorId).Select(Mapper.Map<Book, BookDto>));
        }

        [HttpGet("{bookId}")]
        public IActionResult GetBookForAuthor(Guid authorId, Guid bookId)
        {
            if (!_libraryRepository.AuthorExists(authorId))
                return NotFound();

            var bookFromDb = _libraryRepository.GetBookForAuthor(authorId, bookId);

            if (bookFromDb == null)
                return NotFound();

            return Ok(Mapper.Map<BookDto>(bookFromDb));
        }
    }
}
