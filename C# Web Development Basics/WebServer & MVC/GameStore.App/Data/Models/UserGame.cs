namespace GameStore.App.Data.Models
{
    public class UserGame
    {
        public Game Game { get; set; }

        public int GameId { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }
}