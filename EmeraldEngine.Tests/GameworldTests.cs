namespace EmeraldEngine.Tests
{
   using EmeraldEngine.Models;
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   [TestClass]
   public class GameworldTests
   {
      [ClassInitialize]
      public static void ClassInit(TestContext context)
      {
         if (Gameworld.Instance() is null)
         {
            throw new Exception("Gameworld instance has encountered some difficulties (null value).");
         }

         Gameworld.Instance().ConstructWorld();
      }

      [TestMethod]
      public void Given_GameworldExample_When_ReadingGameworldItems_Then_CheckIfValid()
      {
         var gameRooms = Gameworld.Instance()._gameRooms;

         Assert.IsNotNull(gameRooms);
         Assert.IsTrue(gameRooms.Any());
         Assert.AreEqual(7, gameRooms.Count);
      }

      [TestMethod]
      public void Given_GameworldExample_When_ReadingGameworldRooms_Then_CheckIfValid()
      {
         var gameItems = Gameworld.Instance()._gameItem;

         Assert.IsNotNull(gameItems);
         Assert.IsTrue(gameItems.Any());
         Assert.AreEqual(6, gameItems.Count);
      }

      [TestMethod]
      public void Given_GameworldExample_When_ReadProperties_CheckIfGameworldAndCurrentroomAndPlayerIsNotNull()
      {
         var gameInstance = Gameworld.Instance();

         Assert.IsNotNull(gameInstance);
         Assert.IsNotNull(gameInstance._player);
         Assert.IsNotNull(gameInstance._currentRoom);
      }
   }
}