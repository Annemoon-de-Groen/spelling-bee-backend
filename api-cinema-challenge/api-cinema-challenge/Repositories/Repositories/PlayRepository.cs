using api_cinema_challenge.Data;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Repositories.Repositories
{
    public class PlayRepository : IPlayRepository
    {
        DataContext _db;

        public PlayRepository(DataContext database)
        {
            _db = database;
        }
        public async Task<Play> CreatePlay(DateTime date, int capacity, string location)
        {
            Play play = new Play();
            play.Capacity = capacity;
            play.Date = date;
            play.Location = location;
            play.Tickets = new List<Tickets>();
            await _db.Plays.AddAsync(play);
            _db.SaveChanges();
            return play;
        }

        public Play DeletePlay(Play play)
        {
            _db.Plays.Remove(play);
            _db.SaveChanges();
            return play;
        }

        public async Task<Play> EditPlay(Play play, DateTime? date, int? capacity, string? location)
        {
            if (!(date is null)) play.Date = (DateTime)date;
            if (!(capacity is null)) play.Capacity = (int)capacity;
            if (!(location is null)) play.Location = location;
            await _db.SaveChangesAsync();
            return play;
        }

        public async Task<Play?> GetPlayById(int id)
        {
            return await _db.Plays.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Play>> GetPlays()
        {
            return await _db.Plays.ToListAsync();
        }
    }
}
