namespace EmeraldEngine.Tests
{
    using EmeraldEngine.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameworldTests
    {
        //private static Gameworld? _gameworldEntity; 

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
        public void TestMethod1()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Given_GameworldExample_When_ReadingProperties_Then_CheckCount()
        {
            //Assert.IsTrue(Gameworld.Instance());

            var numOfRooms = 0;
            var numOfItems = 0;

            Assert.IsTrue(numOfItems > 0);
            Assert.IsTrue(numOfRooms > 0);
        }

        [TestMethod]
        public void Given_GameworldExample_When_ReadProperties_CheckIfGameworldAndCurrentroomAndPlayerIsNotNull()
        {
            Assert.IsNotNull(Gameworld.Instance());
            Assert.IsNotNull(Gameworld.Instance());
        }
    }
}