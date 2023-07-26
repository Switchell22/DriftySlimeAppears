namespace Game.Scripts
{
    [System.Serializable]
    public class GameData
    {
        public DeckInstance currentDeck = new DeckInstance();
        public int day = 1;
        public int coins = 0;
        public float timeRemaining = 15f;
        public int hp = 10;
    }
}
