using api_cinema_challenge.Models;

namespace api_cinema_challenge.DTO.ResponseDTO
{
    public class PlayResponseDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public PlayResponseDTO(Play play)
        {
            Console.WriteLine("Make DTO", play);
            Date = play.Date;
            Location = play.Location;
            Capacity = play.Capacity;
            Id = play.Id;
        }

    }
}
