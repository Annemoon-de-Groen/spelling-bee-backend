using api_cinema_challenge.Models;

namespace api_cinema_challenge.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        public Task<IEnumerable<Players>> GetPlayers();
        public Task<Players?> GetPlayerById(int id);
        public Task<Players> EditPlayer(Players player, string? firstName, string? lastName, string? bio, string? rol, string? functie);

    }
}
