using System;
namespace MusicTracksApp.Models
{
    public class GenreViewModel
    {
       public int Id {get; set;}

       public string Name {get; set;}

       public string Description {get; set;}

       public DateTime CreatedAt {get; set;}

       public string CreatedBy {get; set;}

       public DateTime UpdatedAt {get; set;}

       public string UpdatedBy {get; set;}

       public bool IsActive {get; set;}

    }
}