using AutoMapper;
using Core2.Entities;
using Core2.Models;
using Core2.Services;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{bookId}", Name = "GetBookForAuthor")]
        public IActionResult GetBookForAuthor(Guid authorId, Guid bookId)
        {
            if (!_libraryRepository.AuthorExists(authorId))
                return NotFound();

            var bookFromDb = _libraryRepository.GetBookForAuthor(authorId, bookId);

            if (bookFromDb == null)
                return NotFound();

            return Ok(Mapper.Map<BookDto>(bookFromDb));
        }

        [HttpPost]
        public IActionResult CreateBookForAuthor(Guid authorId, [FromBody] BookForCreationDto book)
        {
            if (!_libraryRepository.AuthorExists(authorId))
                return NotFound();

            if (book == null)
                return BadRequest();

            if (book.Description == book.Title)
                ModelState.AddModelError(nameof(BookForCreationDto),
                    "Description should be different from the title.");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var bookInDb = Mapper.Map<Book>(book);
            _libraryRepository.AddBookForAuthor(authorId, bookInDb);

            if(!_libraryRepository.Save())
                throw new Exception("Something bad happened.");

            return CreatedAtRoute("GetBookForAuthor",
                new {bookId = bookInDb.Id},
                Mapper.Map<BookDto>(bookInDb));
        }

        [HttpDelete("{bookId}")]
        public IActionResult DeleteBookForAuthor(Guid authorId, Guid bookId)
        {
            if (!_libraryRepository.AuthorExists(authorId))
                return NotFound();

            var book = _libraryRepository.GetBookForAuthor(authorId, bookId);

            if (book == null)
                return NotFound();

            _libraryRepository.DeleteBookForAuthor(book);

            if(!_libraryRepository.Save())
                throw new Exception();

            return NoContent();
        }

        [HttpPut("{bookId}")]
        public IActionResult UpdateBookForAuthor(Guid authorId, Guid bookId,
            [FromBody] BookForUpdateDto bookUpdate)
        {
            if (!_libraryRepository.AuthorExists(authorId))
                return NotFound();

            if (bookUpdate == null)
                return BadRequest();

            if (bookUpdate.Description == bookUpdate.Title)
                ModelState.AddModelError(nameof(BookForUpdateDto),
                    "Description should be different from the title.");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var book = _libraryRepository.GetBookForAuthor(authorId, bookId);

            if (book == null)
            {
                var bookToAdd = Mapper.Map<Book>(bookUpdate);
                bookToAdd.Id = bookId;
                _libraryRepository.AddBookForAuthor(authorId, bookToAdd);

                if (!_libraryRepository.Save())
                    throw new Exception();

                return CreatedAtRoute("GetBookForAuthor",
                    new {authorId, bookId},
                    Mapper.Map<BookDto>(bookToAdd));
            }

            Mapper.Map(bookUpdate, book);

            _libraryRepository.UpdateBookForAuthor(book);

            if(!_libraryRepository.Save())
                throw new Exception();

            return NoContent();
        }

        [HttpPatch("{bookId}")]
        public IActionResult PartiallyUpdatedBookForAuthor(Guid authorId, Guid bookId,
            [FromBody] JsonPatchDocument<BookForUpdateDto> patchDoc)
        {
            if (!_libraryRepository.AuthorExists(authorId))
                return NotFound();

            if (patchDoc == null)
                return BadRequest();

            var book = _libraryRepository.GetBookForAuthor(authorId, bookId);

            if (book == null)
            {
                var bookDto = new BookForUpdateDto();
                patchDoc.ApplyTo(bookDto, ModelState);

                if(bookDto.Description == bookDto.Title)
                    ModelState.AddModelError(nameof(BookForUpdateDto),
                        "Description and title should be different.");

                TryValidateModel(bookDto);

                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

                var bookToAdd = Mapper.Map<Book>(bookDto);
                bookToAdd.Id = bookId;

                _libraryRepository.AddBookForAuthor(authorId, bookToAdd);

                if (!_libraryRepository.Save())
                    throw new Exception();

                return CreatedAtRoute("GetBookForAuthor",
                    new {authorId, bookId},
                    Mapper.Map<BookDto>(bookToAdd));
            };

            var bookToPatch = Mapper.Map<BookForUpdateDto>(book);
            patchDoc.ApplyTo(bookToPatch, ModelState);

            if(bookToPatch.Description == bookToPatch.Title)
                ModelState.AddModelError(nameof(BookForUpdateDto),
                    "Description and title should be different.");

            TryValidateModel(bookToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            Mapper.Map(bookToPatch, book);

            _libraryRepository.UpdateBookForAuthor(book);

            if (!_libraryRepository.Save())
                throw new Exception();

            return NoContent();
        }
    }
}
