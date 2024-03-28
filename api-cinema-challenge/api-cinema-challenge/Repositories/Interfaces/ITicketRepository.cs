using api_cinema_challenge.Models;

namespace api_cinema_challenge.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        public Task<IEnumerable<Tickets>> GetAllTickets();
        public Task<IEnumerable<Tickets>> GetTicketsByPlay(int playId);
        public Task<Tickets> CreateTicket(string firstName, string lastName, string email, int amount, bool paid, Play play);
        public Task<Tickets> DeleteTicket(Tickets ticket);
        public Task<Tickets?> GetTicketById(int id);
        public Task<Tickets> EditTicket(Tickets ticket, string? firstName, string? lastName, int? amount, bool? paid, int? playId);
        public Task<Tickets> PayTicket(Tickets ticket);
    }
}
