namespace Pong.MatchSystem
{
    public class PlayerScore
    {
        public int Score { get; private set; }

        public void IncreaseScore()
        {
            Score++;
        }
    }
}