using api_cinema_challenge.Models;

namespace api_cinema_challenge.Repositories.Interfaces
{
    public interface IPlayRepository
    {
        Task<IEnumerable<Play>> GetPlays();
        Task<Play?> GetPlayById(int id);
        Task<Play> CreatePlay(DateTime date, int capacity, string location);
        Play DeletePlay(Play play);
        Task<Play> EditPlay(Play play, DateTime? date, int? capacity, string? location);
    }
}
