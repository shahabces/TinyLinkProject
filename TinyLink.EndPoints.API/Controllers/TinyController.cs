using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyLink.Core.Contracts;
using TinyLink.Core.Contracts.Dtos;

namespace TinyLink.EndPoints.API.Controllers
{
    [ApiController]
    public class TinyController : Controller
    {
        private readonly ITinyLinkApplicationService _tinyLinkApplicationService;

        public TinyController(ITinyLinkApplicationService tinyLinkApplicationService)
        {
            _tinyLinkApplicationService = tinyLinkApplicationService;
        }
        [Route("Tiny")]
        [HttpPost]
        public string AddLink(TinyLinkDto tinyLinkDto)
        {
            return _tinyLinkApplicationService.AddLink(tinyLinkDto);
        }

        [Route("Tiny/{hash}")]
        [HttpGet]
        public IActionResult VisitLink(string hash)
        {
            var link = _tinyLinkApplicationService.VisitLink(hash);
            if (link==string.Empty)
            {
                throw new Exception("Not Found");
            }

            return Redirect(link);
        }
    }
}
