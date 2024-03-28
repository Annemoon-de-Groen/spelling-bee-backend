namespace api_cinema_challenge.DTO.Payload
{
    public record QuestionPayload(string word, string definition, string sentence);
    public record QuestionEditPayload(string? word, string? definition, string? sentence);
}
