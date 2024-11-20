namespace EmeraldEngine.Models
{
    /// <summary>
    /// Gameworld singleton which contains:
    /// <list type="bullet">
    ///     <item>gameworld instance,</item>
    ///     <item>Player type of... well <typeparamref name="Player"/>,</item>
    ///     <item>list of all Rooms in gameworld,</item>
    ///     <item>list of all items in gameworld,</item>
    ///     <item>current room where player is property (Room type for now).</item>
    /// </list>
    /// </summary>
    public class Gameworld
    {
        #region Properties

        private Player _player;
        private Room _currentRoom;
        private Dictionary<string, Item> _gameItem;
        private Dictionary<string, Room> _gameRooms;
        private static Gameworld? _instance = null;

        #endregion Properties

        #region Constructors and initiators

        private Gameworld()
        {
            _player = new Player();
            _gameItem = new Dictionary<string, Item>();
        }

        public static Gameworld Instance()
        {
            if (_instance == null)
            {
                _instance = new Gameworld();
            }

            return _instance;
        }

        //public static Gameworld MockedGameworldInstance()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new Gameworld();
        //        _instance.ConstructWorld();
        //    }

        //    return _instance;
        //}

        #endregion Constructors and initiators

        public void ConstructWorld()
        {
            #region Populate the items dictionary/list

            var id = "ITEM." + Guid.NewGuid();
            _gameItem[id] = new Item()
            {
                Name = "Golden key",
                ObjectId = id,
                Description = string.Empty,
                Value = 0.0f,
                Weight = 0.0f,
                Pickable = false,
            };

            id = "ITEM." + Guid.NewGuid();
            _gameItem[id] = new Item()
            {
                Name = "Wooden hammer",
                ObjectId = id,
                Description = "A hammer... a wooden one.",
                Value = 0.0f,
                Weight = 0.0f,
                Pickable = true,
            };

            id = "ITEM." + Guid.NewGuid();
            _gameItem[id] = new Item()
            {
                Name = "Tarot card [XIII]",
                ObjectId = id,
                Description = "Pirogi do nogi i syngal to wrogi. It's a prank item, bra!",
                Value = 0.0f,
                Weight = 0.0f,
                Pickable = false,
            };

            id = "ITEM." + Guid.NewGuid();
            _gameItem[id] = new Item()
            {
                Name = "Rusty knife",
                ObjectId = id,
                Description = "It's not sharp but has a lot of rust on itself.",
                Value = 0.0f,
                Weight = 0.0f,
                Pickable = true,
            };

            id = "ITEM." + Guid.NewGuid();
            _gameItem[id] = new Item()
            {
                Name = "Potato",
                ObjectId = id,
                Description = "What can I say? A potato.",
                Value = 0.0f,
                Weight = 0.0f,
                Pickable = true,
            };

            id = "ITEM." + Guid.NewGuid();
            _gameItem[id] = new Item()
            {
                Name = "Wheat stone",
                ObjectId = id,
                Description = "Massive and heavy stone perfect for getting the 'edge'.",
                Value = 0.0f,
                Weight = 0.0f,
                Pickable = false,
            };

            #endregion Populate the items dictionary/list

            #region The player is being created here

            _player.Name = "Sample player for tests";
            _player.ObjectId = "PLAYER_0";

            #endregion The player is being created here

            #region Construct some rooms

            var roomId = "ROOM." + Guid.NewGuid();
            _gameRooms[roomId] = new Room()
            {
                ObjectId = roomId,
                Name = "ROOM_A",
                Description = "",
                DirectionsToGo = {
                    ("north", "ROOM_B",false)
                }
            };

            roomId = "ROOM." + Guid.NewGuid();
            _gameRooms[roomId] = new Room()
            {
                ObjectId = roomId,
                Name = "ROOM_B",
                Description = "",
                DirectionsToGo = {
                    ("north", "ROOM_D",true),
                    ("wooden door", "ROOM_C",true),
                    ("south", "ROOM_A",true)
                }
            };

            roomId = "ROOM." + Guid.NewGuid();
            _gameRooms[roomId] = new Room()
            {
                ObjectId = roomId,
                Name = "ROOM_C",
                Description = "",
                DirectionsToGo = {
                    ("east", "ROOM_E",true),
                    ("north", "ROOM_G",true),
                    ("wooden door", "ROOM_B",true)
                }
            };

            roomId = "ROOM." + Guid.NewGuid();
            _gameRooms[roomId] = new Room()
            {
                ObjectId = roomId,
                Name = "ROOM_D",
                Description = "",
                DirectionsToGo = {
                    ("south", "ROOM_B",true),
                    ("north", "ROOM_F",true)
                }
            };

            roomId = "ROOM." + Guid.NewGuid();
            _gameRooms[roomId] = new Room()
            {
                ObjectId = roomId,
                Name = "ROOM_E",
                Description = "",
                DirectionsToGo = {
                    ("west", "ROOM_C",true)
                }
            };

            roomId = "ROOM." + Guid.NewGuid();
            _gameRooms[roomId] = new Room()
            {
                ObjectId = roomId,
                Name = "ROOM_F",
                Description = "",
                DirectionsToGo = {
                    ("south", "ROOM_D",true)
                }
            };

            roomId = "ROOM." + Guid.NewGuid();
            _gameRooms[roomId] = new Room()
            {
                ObjectId = roomId,
                Name = "ROOM_G",
                Description = "",
                DirectionsToGo = {
                    ("south", "ROOM_C",false)
                }
            };

            #endregion Construct some rooms
        }
    }
}