## Music Tracks Database App

Example code that returns tracks from a sample and dummy music library database.
	
  
## Database Design

The sqlite database named "Db_MusicTrack.db" in the root directory contains two(2) tables tbl_track and tbl_genres. A foreign key/Many-1 relationship exists on the tbl_track table through [tbl_track].id and [tbl_genres].id.


## Code Logic

> SQL
- The code connects with the sqlite database named "Db_MusicTrack.db" in the root directory of the application using ODBC.
- Query returns music tracks from the music library database.
- Selected data includes track artist, title, genre, and duration and only tracks from the last year and in the order of artist and title ascending.

> Music Library
- Has a method named GetMusicTracks that returns a list of tracks for a given genre. It also validates for zero duration tracks and prevent from being returned.

> Tests
- Test done on the GetMusicTracks method and returns tracks with matching genre. Returns no tracks with zero duration.

> Web Page
- Displays a list of music tracks using Html and Bootstrap.
    
    
## Technologies

Project is created with:
* .Net Core 3.1
* ASP .NET Core MVC
* ODBC Connection
* Sqlite
* Boostrap


## Setup

To run this project, 
* Install .NET Core 3.1 locally
* Clone/download the project and launch locally using visual studio code or visual studio
* Open terminal on the project directory and run **dotnet run**
