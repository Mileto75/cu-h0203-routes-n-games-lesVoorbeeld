namespace Wba.Oefening.Games.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Developer Developer { get; set; }
        public int? Rating { get; set; }
    }
}
