using api_cinema_challenge.Data;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Repositories.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        DataContext _db;
        public ScoreRepository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public async Task<Score> AddScore(string name, int points)
        {
            Score score = new Score();
            score.Points = points;
            score.Name = name;
            score.CreatedAt = DateTime.UtcNow;
            await _db.Scores.AddAsync(score);
            return score;

        }

        public async Task<IEnumerable<Score>> ClearScores()
        {
            var save = _db.Scores;
            _db.Scores.RemoveRange(_db.Scores);
            await _db.SaveChangesAsync();
            return save;
        }

        public async Task<Score?> GetScoreById(int id)
        {
            return await _db.Scores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Score>> GetScores()
        {
            return await _db.Scores.ToListAsync();
        }

        public async Task<IEnumerable<Score>> GetTodayScores()
        {
            return await _db.Scores.Where(x => x.CreatedAt.Date == DateTime.Today).ToListAsync();
        }

        public async Task<IEnumerable<Score>> GetWeekScores()
        {
            return await _db.Scores.Where(x => Math.Floor((decimal) (x.CreatedAt.DayOfYear / 7)) == Math.Floor((decimal)DateTime.Today.DayOfYear/7)).ToListAsync();

        }
    }
}
