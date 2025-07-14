namespace EmeraldEngine.Tests
{
    using EmeraldEngine.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Reflection;

    [TestClass]
    public class RoomInterfaceTests
    {
        #region Private test properties

        private static Gameworld SampleGameworld;
        private const string informationText = "ERROR: Test method '{0}()' was not implemented, yet.";
        private static Room? testRoom;

        private static readonly string testRoomId = "TEST_ROOM_ID";
        private static readonly string testRoomDesc = string.Empty;
        private static readonly string testRoomName = "TEST_ROOM_NAME";

        #endregion Private test properties

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            testRoom = new Room(testRoomId, testRoomName, testRoomDesc);
            SampleGameworld = Gameworld.Instance();
            //SampleGameworld.ConstructWorldForIRoomTests();
        }

        [Ignore]
        [TestMethod]
        public void CreateSampleGameworld()
        {
            Assert.Fail(string.Format(informationText, MethodBase.GetCurrentMethod().Name));
        }

        [TestMethod]
        public void Given_TesRoom_When_CheckPropertyName_Then_CheckIfValid()
        {
            Assert.IsNotNull(testRoom);
            Assert.IsNotNull(testRoom.Name);
            Assert.AreEqual(testRoomName, testRoom.Name);
        }

        [TestMethod]
        public void Given_TesRoom_When_CheckPropertyId_Then_CheckIfValid()
        {
            Assert.IsNotNull(testRoom);
            Assert.IsNotNull(testRoom.ObjectId);
            Assert.AreEqual(testRoomId, testRoom.ObjectId);
        }

        [TestMethod]
        public void Given_TesRoom_When_CheckPropertyDescription_Then_CheckIfValid()
        {
            Assert.IsNotNull(testRoom);
            Assert.IsNotNull(testRoom.Description);
            Assert.AreEqual(testRoomDesc, testRoom.Description);
        }
    }
}