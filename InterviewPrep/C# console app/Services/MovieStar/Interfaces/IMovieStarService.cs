using Backend.Models;

namespace Backend.Services.MovieStar.Interfaces
{
    public interface IMovieStarService
    {
        string GetMovieStarsResult();

        MovieStarInput[] GetAllMovieStarsFromFileByPath(string filePath);

        string CreateMovieStarsOutputModel(MovieStarInput[] movieStars);
    }
}
