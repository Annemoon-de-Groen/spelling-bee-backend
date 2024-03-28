using api_cinema_challenge.DTO.Payload;
using api_cinema_challenge.DTO.ResponseDTO;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories.Interfaces;

namespace api_cinema_challenge.Controllers
{
    public static class PlayEndpoints
    {
        public static void ConfigurePlayEndpoints(this WebApplication app)
        {
            var PlayGroup = app.MapGroup("play");
            PlayGroup.MapGet("/", GetPlays);
            PlayGroup.MapGet("/{id}", GetPlayById);
            PlayGroup.MapPost("/", CreatePlay);
            PlayGroup.MapPut("/{id}", EditPlay);
            PlayGroup.MapDelete("/{id}", DeletePlay);
        }

        public static async Task<IResult> GetPlays( IPlayRepository repository)
        {
            
            IEnumerable<Play> plays = await repository.GetPlays();
            
            Console.WriteLine("Plays", plays);
            var results = new List<PlayResponseDTO>();
            foreach (var play in plays)
            {
                results.Add(new PlayResponseDTO(play));

            }
            
            return TypedResults.Ok(results);
        }
        public static async Task<IResult> GetPlayById(IPlayRepository repository, int id)
        {
            var result = await repository.GetPlayById(id);
            if (result is null) return TypedResults.NoContent();
            return TypedResults.Ok(new PlayResponseDTO(result));
        }

        //ONLY FOR ADMIN
        public static async Task<IResult> CreatePlay(IPlayRepository repository, PlayPayload data)
        {
            var result = await repository.CreatePlay(data.date, data.capacity, data.location);
            return TypedResults.Created("", new PlayResponseDTO(result));
        }

        //ONLY FOR ADMIN
        public static async Task<IResult> EditPlay(IPlayRepository repository,int id, PlayEditPayload data)
        {
            var play = await repository.GetPlayById(id);
            if (play is null) return TypedResults.NotFound();
            var result = await repository.EditPlay(play, data.date, data.capacity, data.location);
            return TypedResults.Created("", new PlayResponseDTO(result));

        }

        //ONLY FOR ADMIN
        public static async Task<IResult> DeletePlay(IPlayRepository repository, int id)
        {
            var play = await repository.GetPlayById(id);
            if (play is null) return TypedResults.NotFound();
            repository.DeletePlay(play);
            return TypedResults.Ok( new PlayResponseDTO(play));
        }

    }
}
