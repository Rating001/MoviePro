using MoviePro.Models.Database;
using MoviePro.Models.TMDB;
using MoviePro.Services.Interfaces;

namespace MoviePro.Services
{
    public class DataMappingService : IDataMappingService
    {
        public ActorDetail MapActorDetail(ActorDetail actor)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> MapMovieDetailAsync(MovieDetail movie)
        {
            throw new NotImplementedException();
        }
    }
}
