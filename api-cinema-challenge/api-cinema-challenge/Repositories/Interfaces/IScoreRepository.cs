using api_cinema_challenge.Models;

namespace api_cinema_challenge.Repositories.Interfaces
{
    public interface IScoreRepository
    {
        public Task<IEnumerable<Score>> GetScores();
        public Task<IEnumerable<Score>> GetTodayScores();
        public Task<IEnumerable<Score>> GetWeekScores();
        public Task<Score?> GetScoreById(int id);
        public Task<Score> AddScore(string name, int points);
        public Task<IEnumerable<Score>> ClearScores();
    }
}
