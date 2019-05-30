using AutoMapper;
using Core2.Entities;
using Core2.Helpers;
using Core2.Models;
using Core2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2.Controllers
{
    [Route("/api/authors/{authorId}/bookCollections/")]
    public class BookCollectionController : Controller
    {
        private readonly ILibraryRepository _libraryRepository;

        public BookCollectionController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        [HttpPost]
        public IActionResult CreateBookCollection(Guid authorId,
            [FromBody] IEnumerable<BookForCreationDto> bookCollection)
        {
            if (!_libraryRepository.AuthorExists(authorId))
                return NotFound();

            if (bookCollection == null)
                return BadRequest();

            var booksForDb = Mapper.Map<IEnumerable<Book>>(bookCollection);

            foreach (var book in booksForDb)
            {
                _libraryRepository.AddBookForAuthor(authorId, book);
            }

            if(!_libraryRepository.Save())
                throw new Exception();

            var bookCollectionToReturn = Mapper.Map<IEnumerable<BookDto>>(booksForDb);
            var routeIds = string.Join(',', bookCollectionToReturn.Select(a => a.Id));

            return CreatedAtRoute("GetBooksForAuthorCollection",
                new {bookIds = routeIds},
                bookCollectionToReturn);
        }

        [HttpGet("({bookIds})", Name = "GetBooksForAuthorCollection")]
        public IActionResult GetBookCollectionForAuthor(Guid authorId,
            [ModelBinder(BinderType = typeof(BookArrayModelBinder))] IEnumerable<Guid> bookIds)
        {
            if (!_libraryRepository.AuthorExists(authorId))
                return NotFound();

            if (bookIds == null)
                return BadRequest();

            var bookToReturn = Mapper.Map<IEnumerable<BookDto>>
                (_libraryRepository.GetBooksForAuthor(authorId, bookIds));

            if (bookIds.Count() != bookToReturn.Count())
                return NotFound();

            return Ok(bookToReturn);
        }
    }
}
