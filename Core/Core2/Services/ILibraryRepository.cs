using Core2.Entities;
using System;
using System.Collections.Generic;

namespace Core2.Services
{
    public interface ILibraryRepository
    {
        IEnumerable<Author> GetAuthors();
        Author GetAuthor(Guid id);
        void AddAuthor(Author author);
        void DeleteAuthor(Guid id);
        void UpdateAuthor(Guid id, Author author);
        bool AuthorExists(Guid id);
        IEnumerable<Book> Books();
        Book GetBookForAuthor(Guid authorId, Guid bookId);
        void AddBookForAuthor(Guid authorId, Book book);
        void UpdateBookForAuthor(Guid bookId, Book book);
        void DeleteBookForAuthor(Guid bookId);
        bool Save();
    }
}
