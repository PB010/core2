using Core2.Entities;
using Core2.Helpers;
using System;
using System.Collections.Generic;

namespace Core2.Services
{
    public interface ILibraryRepository
    {
        PagedList<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters);
        IEnumerable<Author> GetAuthors(IEnumerable<Guid> ids);
        Author GetAuthor(Guid authorId);
        void AddAuthor(Author author);
        void DeleteAuthor(Author author);
        void UpdateAuthor(Author author);
        bool AuthorExists(Guid authorId);
        IEnumerable<Book> GetBooksForAuthor(Guid authorId);
        IEnumerable<Book> GetBooksForAuthor(Guid authorId, IEnumerable<Guid> bookIds);
        Book GetBookForAuthor(Guid authorId, Guid bookId);
        void AddBookForAuthor(Guid authorId, Book book);
        void UpdateBookForAuthor(Book book);
        void DeleteBookForAuthor(Book book);
        bool Save();
    }
}
