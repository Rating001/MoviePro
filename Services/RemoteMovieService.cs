using MoviePro.Enums;
using MoviePro.Models.TMDB;
using MoviePro.Services.Interfaces;

namespace MoviePro.Services
{
    public class RemoteMovieService : IRemoteMovieService
    {
        public Task<ActorDetail> ActorDetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDetail> MovieDetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieSearch> MovieSearchAsync(MovieCategory category, int count)
        {
            throw new NotImplementedException();
        }
    }
}
