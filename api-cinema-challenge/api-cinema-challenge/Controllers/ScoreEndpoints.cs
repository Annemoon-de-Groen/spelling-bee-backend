using api_cinema_challenge.DTO.Payload;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories.Interfaces;

namespace api_cinema_challenge.Controllers
{
    public static class ScoreEndpoints
    {
        public static void ConfigureScoreEndpoints(this WebApplication app)
        {
            var ScoreGroup = app.MapGroup("score");
            ScoreGroup.MapGet("", GetScores);
            ScoreGroup.MapGet("/{id}", GetScoreById);
            ScoreGroup.MapGet("/today", GetTodayScores);
            ScoreGroup.MapGet("/week", GetWeekScores);
            ScoreGroup.MapPost("", AddScore);
            ScoreGroup.MapDelete("/all", ClearScores);
        }

        public static async Task<IResult> GetScores(IScoreRepository repository)
        {
            return TypedResults.Ok(await repository.GetScores());
        }
        public static async Task<IResult> GetScoreById(IScoreRepository repository, int id)
        {
            Score? score = await repository.GetScoreById(id);
            if (score is null) return TypedResults.NotFound($"Score with id {id} doesn't exist");
            return TypedResults.Ok(score);
        }
        public static async Task<IResult> GetTodayScores(IScoreRepository repository)
        {
            return TypedResults.Ok(await repository.GetTodayScores());
        }
        public static async Task<IResult> GetWeekScores(IScoreRepository repository)
        {
            return TypedResults.Ok(await repository.GetWeekScores());
        }
        public static async Task<IResult> AddScore(IScoreRepository repository, ScorePayload data)
        {
            return TypedResults.Created("", await repository.AddScore(data.name, data.points));
        }
        public static async Task<IResult> ClearScores(IScoreRepository repository)
        {
            return TypedResults.Ok(await repository.ClearScores());
        }

    }
}
