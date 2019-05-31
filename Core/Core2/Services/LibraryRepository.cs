using Core2.Entities;
using Core2.Helpers;
using Core2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2.Services
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryContext _context;
        private readonly IPropertyMappingService _propertyMappingService;

        public LibraryRepository(LibraryContext context, 
            IPropertyMappingService propertyMappingService)
        {
            _context = context;
            _propertyMappingService = propertyMappingService;
        }

        public PagedList<Author> GetAuthors(
            AuthorsResourceParameters authorsResourceParameters)
        {
            var collectionBeforePaging = _context.Authors
                .ApplySort(authorsResourceParameters.OrderBy,
                    _propertyMappingService.GetPropertyMapping<AuthorDto, Author>());

            if (!string.IsNullOrEmpty(authorsResourceParameters.Genre))
            {
                var genreForWhereClause = authorsResourceParameters.Genre.Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging.Where(a =>
                    a.Genre.ToLowerInvariant() == genreForWhereClause);
            }

            if (!string.IsNullOrEmpty(authorsResourceParameters.SearchQuery))
            {
                var searchQueryForWhereClause = authorsResourceParameters.SearchQuery.Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging
                    .Where(a => a.Genre.ToLowerInvariant().Contains(searchQueryForWhereClause)
                                || a.FirstName.ToLowerInvariant().Contains(searchQueryForWhereClause)
                                || a.LastName.ToLowerInvariant().Contains(searchQueryForWhereClause));
            }

            return PagedList<Author>.Create(collectionBeforePaging,
                    authorsResourceParameters.PageNumber,
                    authorsResourceParameters.PageSize);
        }

        public IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds)
        {
            return _context.Authors.Where(a => authorIds.Contains(a.Id))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToList();
        }

        public Author GetAuthor(Guid authorId)
        {
            return _context.Authors.SingleOrDefault(a => a.Id == authorId);
        }

        public void AddAuthor(Author author)
        {
            author.Id = Guid.NewGuid();
            _context.Authors.Add(author);

            if (author.Books.Any())
            {
                foreach (var book in author.Books)
                {
                    book.Id = Guid.NewGuid();
                }
            }
            
        }

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
        }

        public void UpdateAuthor(Author author)
        {

        }

        public bool AuthorExists(Guid authorId)
        {
            return _context.Authors.Any(a => a.Id == authorId);
        }

        public IEnumerable<Book> GetBooksForAuthor(Guid authorId)
        {
            return _context.Books
                .Where(b => b.AuthorId == authorId).OrderBy(b => b.Title).ToList();
        }

        public IEnumerable<Book> GetBooksForAuthor(Guid authorId, IEnumerable<Guid> bookIds)
        {
            return _context.Books.Where(b => bookIds.Contains(b.Id) && b.AuthorId == authorId)
                .OrderBy(b => b.Title)
                .ToList();
        }

        public Book GetBookForAuthor(Guid authorId, Guid bookId)
        {
            return _context.Books.SingleOrDefault(b => b.AuthorId == authorId && b.Id == bookId);
        }

        public void AddBookForAuthor(Guid authorId, Book book)
        {
            var author = GetAuthor(authorId);

            if (author != null)
            {
                // if there isn't an id filled out (ie: we're not upserting),
                // we should generate one
                if (book.Id == Guid.Empty)
                {
                    book.Id = Guid.NewGuid();
                }
                author.Books.Add(book);
            }
            
        }

        public void UpdateBookForAuthor(Book book)
        {

        }

        public void DeleteBookForAuthor(Book book)
        {
            _context.Books.Remove(book);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
