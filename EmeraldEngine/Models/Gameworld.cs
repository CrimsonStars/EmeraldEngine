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
        #region Private and public properties

        private static Gameworld? _instance = null;
        public Room _currentRoom { get; private set; }
        public Player _player { get; private set; }
        public Dictionary<string, Item> _gameItem { get; private set; }
        public Dictionary<string, Room> _gameRooms { get; private set; }

        #endregion Private and public properties

        #region Constructors and initiators

        private Gameworld()
        {
            _player = new Player();
            _gameItem = new Dictionary<string, Item>();
            _gameRooms = new Dictionary<string, Room>();
        }

        public static Gameworld Instance()
        {
            if (_instance == null)
            {
                _instance = new Gameworld();
            }

            return _instance;
        }

        #endregion Constructors and initiators

        #region Const strings

        private const string NORTH = "north";
        private const string SOUTH = "south";
        private const string EAST = "east";
        private const string WEST = "west";

        #endregion Const strings

        #region Helper methods

        private string CreateGuid(string prefix)
        {
            return $"{prefix}.{Guid.NewGuid()}";
        }

        public bool HasItemByName(string itemName)
        {
            return _gameItem.Any(item => item.Value.Name.Equals(itemName));
        }

        public bool HasItemById(string itemId)
        {
            return _gameItem.Any(item => item.Value.ObjectId.Equals(itemId));
        }

        #endregion Helper methods

        public void ConstructWorld()
        {
            #region Populate the items dictionary/list

            var itemPrefix = "ITEM";
            var id = CreateGuid(itemPrefix);
            _gameItem[id] = new Item()
            {
                Name = "Golden key",
                ObjectId = id,
                Description = string.Empty,
                Value = 0.0f,
                Weight = 0.0f,
                Pickable = false,
            };

            id = CreateGuid(itemPrefix);
            _gameItem[id] = new Item()
            {
                Name = "Wooden hammer",
                ObjectId = id,
                Description = "A hammer... a wooden one.",
                Value = 0.0f,
                Weight = 0.0f,
                Pickable = true,
            };

            id = CreateGuid(itemPrefix);
            _gameItem[id] = new Item()
            {
                Name = "Tarot card [XIII]",
                ObjectId = id,
                Description = "Pirogi do nogi i syngal to wrogi. It's a prank item, bra!",
                Value = 0.0f,
                Weight = 0.0f,
                Pickable = true,
            };

            id = CreateGuid(itemPrefix);
            _gameItem[id] = new Item()
            {
                Name = "Rusty knife",
                ObjectId = id,
                Description = "It's not sharp but has a lot of rust on itself.",
                Value = 0.0f,
                Weight = 0.0f,
                Pickable = true,
            };

            id = CreateGuid(itemPrefix);
            _gameItem[id] = new Item()
            {
                Name = "Potato",
                ObjectId = id,
                Description = "What can I say? A potato.",
                Value = 0.0f,
                Weight = 0.0f,
                Pickable = true,
            };

            id = CreateGuid(itemPrefix);
            _gameItem[id] = new Item()
            {
                Name = "Wheat stone",
                ObjectId = id,
                Description = "Massive and heavy stone perfect for getting the 'edge'.",
                Value = 0.0f,
                Weight = 0.0f,
                Pickable = false,
            };

            // const item for testing
            var constId = "ITEM.CONST_ITEM_NAME_ID";
            _gameItem[constId] = new Item()
            {
                Name = "Sample item with hardcoded id",
                ObjectId = constId,
                Description = "Hardcoded item. Nothing special, mostly for testing...",
                Value = -1.0f,
                Weight = -1.0f,
                Pickable = false,
            };

            #endregion Populate the items dictionary/list

            #region The player is being created here

            _player.Name = "Sample player for tests";
            _player.ObjectId = "PLAYER_0";

            #endregion The player is being created here

            #region Construct game rooms for testing

            // I can move those values to res file but it's
            // something to think about.
            // TODO: Add builder for rooms for comfort!
            var prefixRoom = "ROOM";
            var roomId = CreateGuid(prefixRoom);
            _gameRooms[roomId] = new Room()
            {
                ObjectId = roomId,
                Name = "ROOM_A",
                Description = "Starting room with two items. This room is set" +
               "as first in the '_currentRoom' property of Gameworld class.",
                DirectionsToGo = {
                    (NORTH, "ROOM_B",true)
                },
                ItemsInTheRoom =
            {
               _gameItem.First(i => i.Value.Name.Equals("Tarot card [XIII]")).Key,
               _gameItem.First(i => i.Value.Name.Equals("Rusty knife")).Key,
            }
            };

            roomId = CreateGuid(prefixRoom);
            _gameRooms[roomId] = new Room()
            {
                ObjectId = roomId,
                Name = "ROOM_B",
                Description = string.Empty,
                DirectionsToGo = {
                    (NORTH, "ROOM_D", true),
                    ("wooden door", "ROOM_C", true),
                    (SOUTH, "ROOM_A", true)
                }
            };

            roomId = CreateGuid(prefixRoom);
            _gameRooms[roomId] = new Room()
            {
                ObjectId = roomId,
                Name = "ROOM_C",
                Description = string.Empty,
                DirectionsToGo = {
                    (EAST, "ROOM_E",true),
                    (NORTH, "ROOM_G",true),
                    ("wooden door", "ROOM_B",true)
                }
            };

            roomId = CreateGuid(prefixRoom);
            _gameRooms[roomId] = new Room()
            {
                ObjectId = roomId,
                Name = "ROOM_D",
                Description = string.Empty,
                DirectionsToGo = {
                    (SOUTH, "ROOM_B",true),
                    (NORTH, "ROOM_F",true)
                }
            };

            roomId = CreateGuid(prefixRoom);
            _gameRooms[roomId] = new Room()
            {
                ObjectId = roomId,
                Name = "ROOM_E",
                Description = string.Empty,
                DirectionsToGo = {
                    (WEST, "ROOM_C",true)
                }
            };

            roomId = CreateGuid(prefixRoom);
            _gameRooms[roomId] = new Room()
            {
                ObjectId = roomId,
                Name = "ROOM_F",
                Description = string.Empty,
                DirectionsToGo = {
                    (SOUTH, "ROOM_D",true)
                }
            };

            roomId = CreateGuid(prefixRoom);
            _gameRooms[roomId] = new Room()
            {
                ObjectId = roomId,
                Name = "ROOM_G",
                Description = string.Empty,
                DirectionsToGo = {
                    (SOUTH, "ROOM_C",false)
                }
            };

            // setting initial room (ROOM_A)
            var firstRoomName = "ROOM_A";
            _currentRoom = _gameRooms.First(p => p.Value.Name.Equals(firstRoomName)).Value;

            #endregion Construct game rooms for testing
        }

        public void ConstructWorldForIRoomTests()
        {
            throw new Exception("To implement!");
        }

        // Mostly for debugging
        public string CurrentRoomInfoDump()
        {
            var result =
               $"CURRENT ROOM: '{_currentRoom.ObjectId}'\n" +
               $"ROOM_ID:      '{_currentRoom.Name}'\n\n";

            var dirsToGo = "AVAILIABLE DIRS:\n";

            foreach (var direction in _currentRoom.DirectionsToGo)
            {
                var isActive = direction.active ? "Tru" : "Fls";
                dirsToGo += $"\t'{direction.id}' -> '{direction.dest}' [{isActive}]\n";
            }

            dirsToGo += '\n';

            var itemsToCheck = $"ITEMS IN THE ROOM ({_currentRoom.ItemsInTheRoom.Count}):\n";

            foreach (var itemName in _currentRoom.ItemsInTheRoom)
            {
                var selectedItem = _gameItem[itemName];
                itemsToCheck += $"\t'{selectedItem.Name}' ({itemName}; pickable: {selectedItem.Pickable})";
            }

            itemsToCheck += '\n';

            return $"{result}{dirsToGo}{itemsToCheck}";
        }

        public void ChangeCurrentLocation(string roomName)
        {
            var nxtRoom = _gameRooms.First(r => r.Value.Name.Equals(roomName));

            _gameRooms.TryGetValue(nxtRoom.Key, out var nextRoom);
            _currentRoom = nextRoom;
        }

        public void PickItem(string itemId)
        {
            if (_gameItem.ContainsKey(itemId) && _gameItem[itemId].Pickable)
            {
                _currentRoom.ItemsInTheRoom.Remove(itemId);
                _player.Inventory.Add(_gameItem[itemId]);

                //Trace.WriteLine($"Item id = '{itemId}' removed from the room.");
                //Trace.WriteLine($"Player picked item with id = '{itemId}'.");
                //Trace.WriteLine($"Player item count = {_player.Inventory.Count}");
                //Trace.WriteLine($"Current room item count = {_currentRoom.ItemsInTheRoom.Count}");
            }
            else
            {
                throw new Exception();
            }
        }
    }
}