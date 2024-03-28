using api_cinema_challenge.Models;

namespace api_cinema_challenge.DTO.ResponseDTO
{
    public class TicketResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Amount { get; set; }
        public bool Paid { get; set; }
        public PlayResponseDTO Play {get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public TicketResponseDTO(Tickets ticket)
        {
            Id = ticket.Id;
            FirstName = ticket.FirstName;
            LastName = ticket.LastName;
            Email = ticket.Email;
            Amount = ticket.Amount;
            Paid = ticket.Paid;
            Play = new PlayResponseDTO(ticket.Play);
            CreatedAt = ticket.CreatedAt;
            UpdatedAt = ticket.UpdatedAt;
        }
    }
}
