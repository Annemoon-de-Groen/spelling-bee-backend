using api_cinema_challenge.DTO.Payload;
using api_cinema_challenge.DTO.ResponseDTO;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories.Interfaces;
using api_cinema_challenge.Repositories.Repositories;

namespace api_cinema_challenge.Controllers
{
    public static class TicketEndpoints
    {
        public static void ConfigureTicketEndpoints(this WebApplication app)
        {
            var TicketGroup = app.MapGroup("ticket");
            TicketGroup.MapGet("/", GetAllTickets);
            TicketGroup.MapGet("/{playId}", GetTicketsByPlay);
            TicketGroup.MapPost("/{playId}", CreateTicket);
            TicketGroup.MapDelete("/{id}", DeleteTicket);
            TicketGroup.MapPut("/{id}", EditTicket);
            TicketGroup.MapPut("/pay/{id}", PayTicket);
        }

        //Should be exclusive for Admins
        public static async Task<IResult> GetAllTickets(ITicketRepository repository)
        {
            var tickets = await repository.GetAllTickets();
            var result = new List<TicketResponseDTO>();
            foreach (Tickets ticket in tickets)
            {
                result.Add(new TicketResponseDTO(ticket));
            }
            return TypedResults.Ok(result);

        }

        //Only for admins
        public static async Task<IResult> GetTicketsByPlay(ITicketRepository repository, int playId)
        {
            var tickets = await repository.GetTicketsByPlay(playId);
            var result = new List<TicketResponseDTO>();
            foreach (Tickets ticket in tickets)
            {
                result.Add(new TicketResponseDTO(ticket));
            }
            return TypedResults.Ok(result);
        }
        public static async Task<IResult> CreateTicket(ITicketRepository repository, TicketPayload data, int playId, IPlayRepository playRepository)
        {
            Play? play = await playRepository.GetPlayById(playId);
            if (play is null) return TypedResults.NotFound($"Play {playId} doesn't exist");

            IEnumerable<Tickets> ticketList = await repository.GetTicketsByPlay(playId);
            int total = 0;
            foreach (var item in ticketList)
            {
                total += item.Amount;
            }
            if (play.Capacity < (total + data.amount))
            {
                return TypedResults.Problem($"No tickets left {total + data.amount}");
            }

            Tickets ticket = await repository.CreateTicket(data.firstName, data.lastName, data.email, data.amount, data.paid, play);
            return TypedResults.Ok(new TicketResponseDTO(ticket));
        }

        //Only for admins
        public static async Task<IResult> DeleteTicket(ITicketRepository repository, int id)
        {
            Tickets? ticket = await repository.GetTicketById(id);
            if (ticket is null) return TypedResults.NotFound();
            await repository.DeleteTicket(ticket);
            return TypedResults.Ok(new TicketResponseDTO(ticket));
        }
        public static async Task<IResult> EditTicket(ITicketRepository repository, int id, TicketEditPayload data)
        {
            Tickets? ticket = await repository.GetTicketById(id);
            if (ticket is null) return TypedResults.NotFound();
            Tickets result = await repository.EditTicket(ticket, data.firstName, data.lastName, data.amount, data.paid, data.playId);
            return TypedResults.Ok(new TicketResponseDTO(result));
        }
        public static async Task<IResult> PayTicket(ITicketRepository repository, int id)
        {
            Tickets? ticket = await repository.GetTicketById(id);
            if (ticket is null) return TypedResults.NotFound();
            Tickets result = await repository.PayTicket(ticket);
            return TypedResults.Ok(new TicketResponseDTO(result));
        }
    }
}
