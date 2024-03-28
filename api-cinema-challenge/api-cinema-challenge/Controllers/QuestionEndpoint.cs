using api_cinema_challenge.DTO.Payload;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories.Interfaces;

namespace api_cinema_challenge.Controllers
{
    public static class QuestionEndpoint
    {
        public static void ConfigureQuestionEndpoint(this WebApplication app)
        {
            var QuestionGroup = app.MapGroup("question");
            QuestionGroup.MapGet("", GetAllQuestions);
            QuestionGroup.MapGet("/{id}", GetQuestionById);
            QuestionGroup.MapPost("", CreateQuestion);
            QuestionGroup.MapPut("/{id}", EditQuestion);
            QuestionGroup.MapDelete("/{id}", DeleteQuestion);
        }
        public static async Task<IResult> GetAllQuestions(IQuestionRepository repository)
        {
            return TypedResults.Ok(await repository.GetQuestions());
        }
        public static async Task<IResult> GetQuestionById(IQuestionRepository repository, int id)
        {
            Question? question = await repository.GetQuestionById(id);
            if (question is null) return TypedResults.NotFound($"Question {id} doesn't exist");
            return TypedResults.Ok(question);
        }
        public static async Task<IResult> CreateQuestion(IQuestionRepository repository, QuestionPayload data)
        {
            return TypedResults.Created("",  await repository.CreateQuestion(data.word, data.definition, data.sentence));
        }
        public static async Task<IResult> EditQuestion(IQuestionRepository repository, int id, QuestionEditPayload data)
        {
            Question? question = await repository.GetQuestionById(id);
            if (question is null) return TypedResults.NotFound($"Question {id} doesn't exist");
            var result = await repository.EditQuestion(question, data.word, data.definition, data.sentence);
            return TypedResults.Ok(result);
        }
        public static async Task<IResult> DeleteQuestion(IQuestionRepository repository, int id)
        {
            Question? question = await repository.GetQuestionById(id);
            if (question is null) return TypedResults.NotFound($"Question {id} doesn't exist");
            var result = await repository.DeleteQuestion(question);
            return TypedResults.Ok(result);
        }


    }
}
