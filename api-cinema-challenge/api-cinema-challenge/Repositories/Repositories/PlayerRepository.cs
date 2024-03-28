using api_cinema_challenge.Data;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Repositories.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        DataContext _db;
        public PlayerRepository(DataContext dataContext)
        {
            _db = dataContext;
        }
        public async Task<Players> EditPlayer(Players player, string? firstName, string? lastName, string? bio, string? rol, string? functie)
        {
            if (firstName is not null) player.FirstName = firstName;
            if (lastName is not null) player.LastName = lastName;
            if (bio is not null) player.Bio = bio;
            if (rol is not null) player.Rol = rol;
            if (functie is not null) player.Functie = functie;
            await _db.SaveChangesAsync();
            return player;
        }

        public async Task<Players?> GetPlayerById(int id)
        {
            return await _db.Players.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Players>> GetPlayers()
        {
            return await _db.Players.ToListAsync();
        }
    }
}
