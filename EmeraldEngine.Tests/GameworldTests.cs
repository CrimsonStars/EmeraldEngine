namespace EmeraldEngine.Tests
{
    using EmeraldEngine.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics;

    [TestClass]
    public class GameworldTests
    {
        private static Gameworld SampleGameworld;

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

        #region SANDBOX

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
            // A -> B -> C-> E -> C
            Trace.WriteLine(SampleGameworld.CurrentRoomInfoDump() + '\n');

            SampleGameworld.ChangeCurrentLocation("ROOM_B");
            SampleGameworld.ChangeCurrentLocation("ROOM_C");

            Assert.IsNotNull(SampleGameworld._currentRoom);
            Assert.AreEqual("ROOM_C", SampleGameworld._currentRoom.Name);

            SampleGameworld.ChangeCurrentLocation("ROOM_E");
            Assert.AreEqual("ROOM_E", SampleGameworld._currentRoom.Name);

            SampleGameworld.ChangeCurrentLocation("ROOM_C");

            Assert.IsNotNull(SampleGameworld._currentRoom);
            Assert.AreEqual("ROOM_C", SampleGameworld._currentRoom.Name);

            Trace.WriteLine(SampleGameworld.CurrentRoomInfoDump() + '\n');
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
            var rustyKnifeItemId = SampleGameworld._gameItem.First(item => item.Value.Name.Equals("Rusty knife")).Key;
            var tarotCardItemId = SampleGameworld._gameItem.First(item => item.Value.Name.Equals("Tarot card [XIII]")).Key;

            Assert.IsNotNull(tarotCardItemId);
            Assert.IsNotNull(rustyKnifeItemId);

            Trace.Write($"Players inventory count: {SampleGameworld._player.Inventory.Count}\n\n");

            SampleGameworld.PickItem(rustyKnifeItemId);
            Trace.Write($"Picked 'rusty knife'\n");
            Trace.Write($"Players inventory count: {SampleGameworld._player.Inventory.Count}\n\n");

            SampleGameworld.PickItem(tarotCardItemId);
            Trace.Write($"Picked 'tarot card'\n");
            Trace.Write($"Players inventory count: {SampleGameworld._player.Inventory.Count}\n\n");

            Trace.Write(SampleGameworld.CurrentRoomInfoDump());

            Assert.AreEqual(2, SampleGameworld._player.Inventory.Count);
            Assert.IsFalse(SampleGameworld._currentRoom.ItemsInTheRoom.Any());
        }

        #endregion SANDBOX
    }
}