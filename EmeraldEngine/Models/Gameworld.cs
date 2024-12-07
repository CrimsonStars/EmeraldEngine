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

      private static Gameworld? _instance = null;
      public Room _currentRoom { get; private set; }
      public Player _player { get; private set; }
      public Dictionary<string, Item> _gameItem { get; private set; }
      public Dictionary<string, Room> _gameRooms { get; private set; }

      #endregion Properties

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

         // I can move those values to res file but it's
         // something to think about.
         var roomId = "ROOM." + Guid.NewGuid();
         _gameRooms[roomId] = new Room()
         {
            ObjectId = roomId,
            Name = "ROOM_A",
            Description = "",
            DirectionsToGo = {
                    ("north", "ROOM_B",false)
                },
            ItemsInTheRoom =
            {
               _gameItem.First(i => i.Value.Name.Equals("Tarot card [XIII]")).Key,
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

         // setting initial room (ROOM_A)
         var firstRoomName = "ROOM_A";
         _currentRoom = _gameRooms.First(p => p.Value.Name.Equals(firstRoomName)).Value;

         #endregion Construct some rooms
      }


      #region Sandbox

      // Actions for items:
      //    TAKE, DROP, LOOK/INSPECT, USE, USE ON

      // Mostly for debugging
      public string CurrentRoomInfoDump()
      {
         var result =
            $"CURRENT ROOM: '{_currentRoom.ObjectId}'\n" +
            $"ROOM_ID:      '{_currentRoom.Name}'\n\n";

         var dirsToGo = "AVAILIABLE DIRS:\n";
         foreach (var j in _currentRoom.DirectionsToGo)
         {
            var isActive = j.active ? "Tru" : "Fls";
            dirsToGo += $"\t'{j.id}' -> '{j.dest}' [{isActive}]\n";
         }
         dirsToGo += '\n';

         var itemsToCheck = $"ITEMS IN THE ROOM ({_currentRoom.ItemsInTheRoom.Count}):\n";
         foreach (var ajtem in _currentRoom.ItemsInTheRoom)
         {
            var item = _gameItem[ajtem];
            itemsToCheck += $"\t'{item.Name}' ({ajtem}; pickable: {item.Pickable})";
         }
         itemsToCheck += '\n';

         return $"{result}{dirsToGo}{itemsToCheck}";
      }

      #endregion
   }
}