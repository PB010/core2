﻿using Core2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core2.Controllers
{
    [Route("/api/")]
    public class RootController : Controller
    {
        private readonly IUrlHelper _urlHelper;

        public RootController(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        [HttpGet(Name = "GetRoot")]
        public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
        {
            if (mediaType == "application/vnd.marvin.hateoas+json")
            {
                var links = new List<LinkDto>
                {
                    new LinkDto(_urlHelper.Link("GetRoot", new { }),
                        "self",
                        "GET"),
                    new LinkDto(_urlHelper.Link("GetAuthors", new { }),
                        "authors",
                        "GET"),
                    new LinkDto(_urlHelper.Link("CreateAuthor", new { }),
                        "create_author",
                        "POST")
                };
                return Ok(links);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
