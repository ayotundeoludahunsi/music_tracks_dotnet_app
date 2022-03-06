

using System.Collections.Generic;
using System.Linq;
using MusicTracksApp.Models;
using MusicTracksApp.Repository;

namespace MusicTracksApp.Test
{
    public static class TestMusicTracksApp
    {
            /**
             *  - Test that GetMusicTracks returns at least one track or more.
             *  - Test that GetMusicTracks returns tracks with matching genre.
             *  - Test that GetMusicTracks returns no tracks with zero duration.
             */
        public static void TestMatchingGenreAndNoZeroDuration()
        {
            var tracks = new List<TrackViewModel>();

            tracks.Add(new TrackViewModel(){
                Id = 1,
                Title = "Track 1",
                Artist = "Artist 1",
                Duration = 23,
                Genre = "Hip pop",
                YearReleased = 2021,
                Description = "Description 1"
            });

            tracks.Add(new TrackViewModel(){
                Id = 1,
                Title = "Track 2",
                Artist = "Artist 2",
                Duration = 4,
                Genre = "Pop",
                YearReleased = 2021,
                Description = "Description 2"
            });

            tracks.Add(new TrackViewModel(){
                Id = 1,
                Title = "Track 3",
                Artist = "Artist 3",
                Duration = 6,
                Genre = "Instrumental",
                YearReleased = 2019,
                Description = "Description 3"
            });

            tracks.Add(new TrackViewModel(){
                Id = 1,
                Title = "Track 1",
                Artist = "Artist 1",
                Duration = 10,
                Genre = "Blue",
                YearReleased = 2022,
                Description = "Description 4"
            });

            tracks.Add(new TrackViewModel(){
                Id = 1,
                Title = "Track 1",
                Artist = "Artist 1",
                Duration = 0,
                Genre = "Pop",
                YearReleased = 2021,
                Description = "Description 5"
            });

        
            var repo = new TrackRepository(null);

            var results = repo.GetMusicTracks("Pop", tracks);
            var list = results.ToList();

            Assert.AreEqual(list.Count, 1);
        }
    }
}