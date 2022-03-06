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
using MusicTracksApp.Test;

namespace MusicTracksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITrackRepository _trackRepo;

        private readonly IConfiguration _configuration;

        /**Inject the configuration and the data repository services*/
        public HomeController(ILogger<HomeController> logger, ITrackRepository trackRepo, IConfiguration configuration)
        {
            _logger = logger;
            _trackRepo = trackRepo;
            _configuration = configuration;
        }

        public IActionResult Index(string genreSearch)
        {

            //Remove comment from the immediate line below to run the test
            //TestMusicTracksApp.TestMatchingGenreAndNoZeroDuration();




            // GetMusicTracks returns a list of tracks for a given genre
            var items =  _trackRepo.GetMusicTracks(genreSearch);
            
            //store the result for view
            ViewData["Tracks"] = items;
            
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
