namespace EmeraldEngine.Tests
{
    using EmeraldEngine.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics;

    [TestClass]
    public class GameworldTests
    {
        #region Private test properties

        private static Gameworld SampleGameworld;

        #endregion Private test properties

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            if (Gameworld.Instance() is null)
            {
                throw new Exception("Gameworld instance has encountered some difficulties (null value).");
            }

            SampleGameworld = Gameworld.Instance();
            SampleGameworld.ConstructWorld();
        }

        [TestMethod]
        public void Given_GameworldExample_When_ReadingGameworldItems_Then_CheckIfValid()
        {
            var gameRooms = SampleGameworld._gameRooms;

            Assert.IsNotNull(gameRooms);
            Assert.IsTrue(gameRooms.Any());
            Assert.AreEqual(7, gameRooms.Count);
        }

        [TestMethod]
        public void Given_GameworldExample_When_ReadingGameworldRooms_Then_CheckIfValid()
        {
            var gameItems = SampleGameworld._gameItem;

            Assert.IsNotNull(gameItems);
            Assert.IsTrue(gameItems.Any());
            Assert.AreEqual(7, gameItems.Count);
        }

        [TestMethod]
        public void Given_GameworldExample_When_ReadProperties_CheckIfGameworldAndCurrentroomAndPlayerIsNotNull()
        {
            Assert.IsNotNull(SampleGameworld);
            Assert.IsNotNull(SampleGameworld._player);
            Assert.IsNotNull(SampleGameworld._currentRoom);
        }

        [TestMethod]
        public void Given_RoomWithSpecificName_When_GoingTo_Then_CheckIfGoneRight()
        {
            Trace.Write(SampleGameworld.CurrentRoomInfoDump());

            var nextRoom = SampleGameworld._gameRooms.First(g => g.Value.Name.Equals("ROOM_B")).Value;
            SampleGameworld.ChangeCurrentLocation(nextRoom.Name);

            Assert.IsNotNull(SampleGameworld._gameRooms[nextRoom.ObjectId]);

            Trace.Write(SampleGameworld.CurrentRoomInfoDump());
        }

        [TestMethod]
        public void Given_Gameworld_When_MovingInCertainPath_Then_CheckIfRouteIsCorrect()
        {
            // route: A -> B -> C-> E -> C
            var firstRoom = "ROOM_A";
            var secondRoom = "ROOM_B";
            var thirdRoom = "ROOM_C";
            var fourthRoom = "ROOM_E";

            Assert.IsNotNull(SampleGameworld._currentRoom);
            Assert.AreEqual(firstRoom, SampleGameworld._currentRoom.Name);
            Trace.Write(SampleGameworld.CurrentRoomInfoDump() + "\n\n");

            SampleGameworld.ChangeCurrentLocation(secondRoom);
            SampleGameworld.ChangeCurrentLocation(thirdRoom);

            Assert.IsNotNull(SampleGameworld._currentRoom);
            Assert.AreEqual(thirdRoom, SampleGameworld._currentRoom.Name);

            SampleGameworld.ChangeCurrentLocation(fourthRoom);
            Assert.AreEqual(fourthRoom, SampleGameworld._currentRoom.Name);

            SampleGameworld.ChangeCurrentLocation(thirdRoom);

            Assert.IsNotNull(SampleGameworld._currentRoom);
            Assert.AreEqual(thirdRoom, SampleGameworld._currentRoom.Name);

            Trace.Write(SampleGameworld.CurrentRoomInfoDump() + "\n\n");
        }

        [TestMethod]
        public void Given_Gameworld_When_SearchingForConstItemForTests_Then_CheckIfItemFound()
        {
            var constItemName = "ITEM.CONST_ITEM_NAME_ID";
            var gameworldItems = SampleGameworld._gameItem;
            var foundItemId = gameworldItems.First(item => item.Key.Equals(constItemName)).Key;

            Assert.AreEqual(constItemName, foundItemId);
            Assert.IsNotNull(foundItemId);
            Assert.IsNotNull(gameworldItems[constItemName]);
            Assert.IsNotNull(gameworldItems[foundItemId]);
        }

        [TestMethod]
        public void Given_SampleGameworld_When_PickingItemsInCurrentRoom_Then_CheckPlayersInventory()
        {
            var tarotCardItemName = "Rusty knife";
            var rustyKnifeItemName = "Tarot card [XIII]";
            var rustyKnifeItem = SampleGameworld._gameItem.First(item => item.Value.Name.Equals(rustyKnifeItemName));
            var tarotCardItem = SampleGameworld._gameItem.First(item => item.Value.Name.Equals(tarotCardItemName));

            Assert.IsNotNull(tarotCardItem.Value);
            Assert.IsNotNull(rustyKnifeItem.Value);
            Assert.AreEqual(rustyKnifeItemName, rustyKnifeItem.Value.Name);
            Assert.AreEqual(tarotCardItemName, tarotCardItem.Value.Name);

            Trace.Write($"Players inventory count: {SampleGameworld._player.Inventory.Count}\n\n");

            SampleGameworld.PickItem(rustyKnifeItem.Key);
            Trace.Write($"Picked '{rustyKnifeItem.Value.Name}'\n");
            Trace.Write($"Players inventory count: {SampleGameworld._player.Inventory.Count}\n\n");

            SampleGameworld.PickItem(tarotCardItem.Key);
            Trace.Write($"Picked '{tarotCardItem.Value.Name}'\n");
            Trace.Write($"Players inventory count: {SampleGameworld._player.Inventory.Count}\n\n");

            Trace.Write(SampleGameworld.CurrentRoomInfoDump());

            Assert.AreEqual(2, SampleGameworld._player.Inventory.Count);
            Assert.IsFalse(SampleGameworld._currentRoom.ItemsInTheRoom.Any());
        }

        [TestMethod]
        public void Given_ListOfItemNamesToBeFound_When_SearchingForThemInGameworld_Then_CheckIfMissing()
        {
            var itemsListInGameworld = new string[] {
                "Wooden hammer",
                "Wheat stone",
                "Rusty knife",
                "Golden key",
                "Tarot card [XIII]",
                "Potato",
                "Sample item with hardcoded id",
            };

            var itemNotPresentInCollection = false;

            foreach (var item in itemsListInGameworld)
            {
                var itemNameToBeFound = SampleGameworld.HasItemByName(item);
                Trace.WriteLine($"'{item}' found? - {itemNameToBeFound}");

                if (!itemNameToBeFound)
                {
                    itemNotPresentInCollection = true;
                    break;
                }
            }

            Assert.AreEqual(7, itemsListInGameworld.Length);
            Assert.IsFalse(itemNotPresentInCollection);
        }

        [TestMethod]
        public void Given_GameroomsCollection_When_GoingThrough_Then_CheckIfEverythingIsAsExpected()
        {
            var gameroomNamePrefix = "ROOM_";
            var availiableSuffuxes = "ABCDEFG";
            var allRoomsAvailiable = true;

            Assert.IsNotNull(SampleGameworld._currentRoom);

            foreach(var roomLetter in availiableSuffuxes)
            {
                if(!SampleGameworld._gameRooms.Any(r => r.Value.Name.Equals($"{gameroomNamePrefix}{roomLetter}")))
                {
                    allRoomsAvailiable = false;
                    break;
                }
            }

            Assert.AreEqual(7, availiableSuffuxes.Length);
            Assert.IsTrue(allRoomsAvailiable);
        }
    }
}