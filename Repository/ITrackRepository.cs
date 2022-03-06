using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MusicTracksApp.Models;

namespace MusicTracksApp.Repository
{
    public interface ITrackRepository
    {
         IEnumerable<Models.TrackViewModel> GetMusicTracks(string genre,  IEnumerable<TrackViewModel> tracks = null); 
    }
}