using api_cinema_challenge.Data;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Repositories.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        DataContext _db;
        public TicketRepository(DataContext dataContext)
        {
            _db = dataContext;
        }
        public async Task<Tickets> CreateTicket(string firstName, string lastName, string email, int amount, bool paid, Play play)
        {
            Tickets ticket = new Tickets();
            ticket.FirstName = firstName;
            ticket.LastName = lastName;
            ticket.Email = email;
            ticket.Amount = amount;
            ticket.Paid = paid;
            ticket.Play = play;
            ticket.PlayId = play.Id;
            ticket.CreatedAt = DateTime.Now.ToUniversalTime();
            ticket.UpdatedAt = DateTime.Now.ToUniversalTime();

            await _db.Tickets.AddAsync(ticket);
            _db.SaveChanges();
            return ticket;

        }

        public async Task<Tickets> DeleteTicket(Tickets ticket)
        {
            _db.Tickets.Remove(ticket);
            await _db.SaveChangesAsync();
            return ticket;
        }

        public async Task<Tickets> EditTicket(Tickets ticket, string? firstName, string? lastName, int? amount, bool? paid, int? playId)
        {
            if (firstName is not null) ticket.FirstName = firstName;
            if (lastName is not null) ticket.LastName = lastName;
            if (amount is not null) ticket.Amount = (int)amount;
            if (paid is not null) ticket.Paid = (bool)paid;
            if (playId is not null) ticket.PlayId = (int)playId;
            ticket.UpdatedAt = DateTime.Now.ToUniversalTime();
            await _db.SaveChangesAsync();
            return ticket;
        }

        public async Task<IEnumerable<Tickets>> GetAllTickets()
        {
            return await _db.Tickets.Include(x => x.Play).ToListAsync();
        }

        public async Task<Tickets?> GetTicketById(int id)
        {
            return await _db.Tickets.Include(x => x.Play).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Tickets>> GetTicketsByPlay(int playId)
        {
            return await _db.Tickets.Include(x => x.Play).Where(x => x.PlayId == playId).ToListAsync();
        }

        public async Task<Tickets> PayTicket(Tickets ticket)
        {
            ticket.Paid = true;
            await _db.SaveChangesAsync();
            return ticket;
        }
    }
}
