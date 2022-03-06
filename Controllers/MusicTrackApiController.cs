using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MusicTracksApp.Models;
using MusicTracksApp.Repository;

namespace MusicTracksApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicTrackController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITrackRepository _trackRepo;
        private readonly IConfiguration _configuration;

        public MusicTrackController(ILogger<HomeController> logger, ITrackRepository trackRepo, IConfiguration configuration)
        {
            _logger = logger;
            _trackRepo = trackRepo;
            _configuration = configuration;
        }

        /** Filter for the list of Music Tracks based on an option Genre*/
        [HttpGet("{genreSearch?}")]
        public IActionResult Get(string genreSearch)
        {
            var items =  _trackRepo.GetMusicTracks(genreSearch);
           
            if(items.Any())
            {
                 return new OkObjectResult(items);
            }
            else
            {
                  return NotFound();
            }
           
        }

    }
}
