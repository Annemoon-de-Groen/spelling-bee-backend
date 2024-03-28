using api_cinema_challenge.Data;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Repositories.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        DataContext _db;

        public QuestionRepository(DataContext dataContext)
        {
            _db = dataContext;
        }
        public async Task<Question> CreateQuestion(string word, string definition, string sentence)
        {
            Question question = new Question();
            question.Word = word;
            question.Definition = definition;
            question.Sentence = sentence;
            await _db.Questions.AddAsync(question);
            _db.SaveChanges();
            return question;
        }

        public async Task<Question> DeleteQuestion(Question question)
        {
            _db.Questions.Remove(question);
            await _db.SaveChangesAsync();
            return question;
        }

        public async Task<Question> EditQuestion(Question question, string? word, string? definition, string? sentence)
        {
            if (word is not null) question.Word = word;
            if (definition is not null) question.Definition = definition;
            if (sentence is not null) question.Sentence = sentence;
            await _db.SaveChangesAsync();
            return question;
        }

        public async Task<Question?> GetQuestionById(int id)
        {
            return await _db.Questions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _db.Questions.ToListAsync();
        }
    }
}
