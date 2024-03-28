using api_cinema_challenge.DTO.Payload;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories.Interfaces;

namespace api_cinema_challenge.Controllers
{
    public static class PlayerEndpoints
    {
        public static void ConfigurePlayerEndpoints(this WebApplication app)
        {
            var PlayerGroup = app.MapGroup("player");
            PlayerGroup.MapGet("", GetPlayers);
            PlayerGroup.MapGet("/{id}", GetPlayerById);
            PlayerGroup.MapPut("/{id}", EditPlayer);
        }


        public static async Task<IResult> GetPlayers(IPlayerRepository repository)
        {
            return TypedResults.Ok(await repository.GetPlayers());
        }
        public static async Task<IResult> GetPlayerById(IPlayerRepository repository, int id)
        {
            Players? result = await repository.GetPlayerById(id);
            if (result is null) return TypedResults.NotFound($"Player {id} doesn't exist");
            return TypedResults.Ok(result);
        }
        public static async Task<IResult> EditPlayer(IPlayerRepository repository, int id, PlayerEditPayload data)
        {
            Players? result = await repository.GetPlayerById(id);
            if (result is null) return TypedResults.NotFound($"Player {id} doesn't exist");
            return TypedResults.Ok(await repository.EditPlayer(result, data.firstName, data.lastName, data.bio, data.rol, data.functie));

        }

    }
}
