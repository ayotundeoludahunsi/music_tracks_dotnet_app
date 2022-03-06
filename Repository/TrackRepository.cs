using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using MusicTracksApp.Models;

namespace MusicTracksApp.Repository
{
    public class TrackRepository : ITrackRepository
    {

        private readonly IConfiguration _config;
        public TrackRepository(IConfiguration configuration)
        {
            _config = configuration;
        }


        /**  This Method returns track artist, title, genre, and duration from more than one tables (tbl_tracks and tbl_genres) that are linked by a relationship. 
           - Checks and returns  only tracks from the last year.
           - Also orders the results by artist and title in ascending manner. */
        private IEnumerable<TrackViewModel> LoadMusicTracksfromDb()
        {

             var tracks = new List<TrackViewModel>();

            try
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder();

                //Use DB in project directory.  If it does not exist, create it:
                var chk = _config.GetConnectionString("DefaultConnection");
                connectionStringBuilder.DataSource = _config.GetConnectionString("DefaultConnection");

                //Create a connection
                using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
                {
                    connection.Open();
                    var odbcCommand = connection.CreateCommand();

                    var sql = @$"SELECT 
                     a.id, a.title, a.description, a.artist, a.duration_mm as duration,
                     a.average_rating, a.date_released, a.year_released, a.producer, a.created_at,
                     b.genre_name as genre
                     FROM [tbl_track] a
                     INNER JOIN [tbl_genre] b on a.genre_id = b.id
                     WHERE a.year_released = @param_year
                     ORDER BY a.title, a.artist";

                    odbcCommand.CommandText = sql;
                    odbcCommand.Parameters.AddWithValue("param_year", DateTime.Now.Year - 1);

                    using (var reader = odbcCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                tracks.Add(new TrackViewModel()
                                {
                                    Id =  Convert.ToInt32(reader["id"]),
                                    Title = Convert.ToString(reader["title"]),
                                    Artist = Convert.ToString(reader["artist"]),
                                    Description = Convert.ToString(reader["description"] != DBNull.Value ? reader["description"] : ""),
                                    Duration = Convert.ToDouble(reader["duration"]),
                                    AverageRating = Convert.ToDouble(reader["average_rating"]),
                                    DateReleased = Convert.ToDateTime(reader["date_released"]),
                                    YearReleased = Convert.ToInt32(reader["year_released"]),
                                    Genre = Convert.ToString(reader["genre"]),
                                    Producer = Convert.ToString(reader["producer"] != DBNull.Value ? reader["producer"] : ""),
                                    CreatedAt = Convert.ToDateTime(reader["created_at"] != DBNull.Value ? reader["created_at"] : null)
                                });
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tracks;
        }


        /** GetMusicTracks returns a list of tracks for a given genre and 
         * validates for zero duration tracks and prevent from being returned*/
        public IEnumerable<TrackViewModel> GetMusicTracks(string genre, IEnumerable<TrackViewModel> tracks = null)
        {
            
            if(tracks == null)
            {
                //if tracks has no test data then fetch from the database
                tracks = this.LoadMusicTracksfromDb();
            }
           
            if(!string.IsNullOrEmpty(genre))
            {
                tracks = tracks.Where(s => s.Genre.ToLower().Equals(genre.ToLower()) && s.Duration > 0) ;
            }
            
            return tracks != null ?  tracks : new List<TrackViewModel>();
        }
    }
}