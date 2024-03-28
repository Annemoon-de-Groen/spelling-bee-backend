namespace api_cinema_challenge.DTO.Payload
{
    public record TicketPayload(string firstName, string lastName, string email, int amount, bool paid);

    public record TicketEditPayload(string? firstName, string? lastName, int? amount, int? playId, bool? paid);
}
