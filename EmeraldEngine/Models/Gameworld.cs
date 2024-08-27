namespace EmeraldEngine.Models
{
    /// <summary>
    /// Gameworld singleton.
    /// </summary>
    public class Gameworld
    {
        private Player _player;
        private Room _currentRoom;
        private List<Item> _gameItem;
        private static Gameworld? _instance = null;

        private Gameworld()
        { 
        }

        public static Gameworld Instance()
        {
            if (_instance == null)
            {
                _instance = new Gameworld();
            }

            return _instance;
        }
    }
}