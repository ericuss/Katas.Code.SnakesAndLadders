namespace SnakesAndLadders.Domain
{

    public class GameService
    {
        public List<Player> Players = new();

        public void Initialize(int numberOfPlayers)
        {
            Players.Clear();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Players.Add(new Player());
            }
        }
        public void Move(Guid id, int moveSpaces)
        {
            var player = Players.FirstOrDefault(x => x.Id == id);
            if (player == null)
            {
                throw new Exception("Player not found");
            }

            var movedPosition = player.Position + moveSpaces;
            if (movedPosition > 100) return;

            player.Position = movedPosition;
        }
    }
}
