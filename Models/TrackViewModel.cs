using System;
namespace MusicTracksApp.Models
{
    public class TrackViewModel
    {
        public int Id {get; set;}

        public string Title {get; set;}

        public string Description {get; set;}

        public string Artist {get; set;}

        /** Duration in Minutes*/
        public double Duration {get; set;}

        public double AverageRating {get; set;}

        public int GenreId {get; set;}

        public string Genre {get; set;}

        public DateTime DateReleased {get; set;}

        public int YearReleased {get; set;}
        public string Producer {get; set;}

        public DateTime CreatedAt {get; set;}

        public string CreatedBy {get; set;}

        public DateTime UpdatedAt {get; set;}

        public string UpdatedBy {get; set;}

        public bool IsActive {get; set;}

    }
}