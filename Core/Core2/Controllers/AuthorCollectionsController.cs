using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core2.Entities;
using Core2.Models;
using Core2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core2.Controllers
{
    [Route("/api/authorCollections")]
    public class AuthorCollectionsController : Controller
    {
        private readonly ILibraryRepository _libraryRepository;

        public AuthorCollectionsController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpPost]
        public IActionResult CreateAuthorCollections([FromBody] IEnumerable<AuthorForCreationDto> authors)
        {
            var authorsForDb = new List<Author>();

            _libraryRepository.AddAuthor(Mapper.Map<List<Author>;

            Mapper.Map(authors, authorsForDb);
        }
    }
}
