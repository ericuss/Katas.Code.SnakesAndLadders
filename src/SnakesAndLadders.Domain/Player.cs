namespace SnakesAndLadders.Domain
{
    public class Player
    {
        public Player()
        {
            Id = Guid.NewGuid();
            Position = 1;
        }

        public Guid Id { get; set; }

        public int Position { get; set; }

        public bool Winner { get => Position == 100; }

        public override string ToString()
        {
            return $"Id: {Id}, Position: {Position}";
        }
    }
}