namespace MyCoolWebServer.GameStoreApplication.Data.Models
{
    public class UserGame
    {
        public User User { get; set; }

        public int UserId { get; set; }

        public Game Game { get; set; }

        public int GameId { get; set; }
    }
}