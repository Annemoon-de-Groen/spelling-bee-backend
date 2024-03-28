using api_cinema_challenge.Models;

namespace api_cinema_challenge.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestions();
        Task<Question?> GetQuestionById(int id);
        Task<Question> CreateQuestion(string word, string definition, string sentence);
        Task<Question> DeleteQuestion(Question question);
        Task<Question> EditQuestion(Question question, string? word, string? definition, string? sentence);
    }
}
