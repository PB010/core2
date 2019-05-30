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
    [Route("/api/authorCollections/")]
    public class AuthorCollectionsController : Controller
    {
        private readonly ILibraryRepository _libraryRepository;

        public AuthorCollectionsController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpPost]
        public IActionResult CreateAuthorCollection([FromBody] IEnumerable<AuthorForCreationDto> authors)
        {
            if (authors == null)
                return BadRequest();

            var authorsForDb = new List<Author>(authors.Select(Mapper.Map<Author>));

            foreach (var author in authorsForDb)
            {
                _libraryRepository.AddAuthor(author);
            }
            
            if(!_libraryRepository.Save())
                throw new Exception("Failed to create collection");

            var authorCollectionToReturn = Mapper.Map<IEnumerable<AuthorDto>>(authorsForDb);
            var idsAsString = string.Join(",", authorCollectionToReturn.Select(a => a.Id));

            return CreatedAtRoute("GetAuthorCollection",
                new {ids = idsAsString},
                authorCollectionToReturn);
        }

        [HttpGet("({ids})", Name = "GetAuthorCollection")]
        public IActionResult GetAuthorCollection(
             [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
                return BadRequest();
            
            var authorEntities = _libraryRepository.GetAuthors(ids);

            if (ids.Count() != authorEntities.Count())
                return NotFound();

            var authorsToReturn = Mapper.Map<IEnumerable<AuthorDto>>(authorEntities);

            return Ok(authorsToReturn);
        }
    }
}
