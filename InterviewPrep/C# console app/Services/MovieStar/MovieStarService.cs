using Backend.Helpers.Constants;
using Backend.Helpers.Services.Interfaces;
using Backend.Models;
using Backend.Services.MovieStar.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Backend.Services.MovieStar
{
    public class MovieStarService : IMovieStarService
    {
        private readonly IDateTimeService dateTimeService;

        public MovieStarService(IDateTimeService dateTimeService)
        {
            this.dateTimeService = dateTimeService;
        }

        public MovieStarInput[] GetAllMovieStarsFromFileByPath(string filePath)
        {
            var movieStarsAsString = File.ReadAllText(FileConstants.MOVIE_STARS_FILE_PATH);

            var movieStars = JsonConvert.DeserializeObject<MovieStarInput[]>(movieStarsAsString);

            return movieStars;
        }

        public string CreateMovieStarsOutputModel(MovieStarInput[] movieStars)
        {
            var sb = new StringBuilder();

            foreach (var movieStar in movieStars)
            {
                var date = DateTime.Parse(movieStar.DateOfBirth).ToUniversalTime();

                var dateDifference = this.dateTimeService.CalculateYearDifferenceBetweenTwoDates(date, DateTime.UtcNow);
                var starYearsOld = $"{dateDifference} years old";

                var fullName = $"{movieStar.Name} {movieStar.Surname}";

                sb.AppendLine(fullName);
                sb.AppendLine(movieStar.Sex);
                sb.AppendLine(movieStar.Nationality);
                sb.AppendLine(starYearsOld);
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

        public string GetMovieStarsResult()
        {
            var movieStart = this.GetAllMovieStarsFromFileByPath(FileConstants.MOVIE_STARS_FILE_PATH);
            var result = this.CreateMovieStarsOutputModel(movieStart);

            return result;
        }
    }
}
