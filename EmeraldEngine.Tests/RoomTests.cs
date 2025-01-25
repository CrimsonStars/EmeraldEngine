namespace EmeraldEngine.Tests
{
    using EmeraldEngine.Models;

    [TestClass]
    public class RoomTests
    {
        private int guidLength = 36;

        //DirectionsToGo = new List<(string id, string dest, bool active)>();
        //ItemsInTheRoom = new List<string>();
        //ObjectId = $"ROOM.{Guid.NewGuid()}";

        [TestMethod]
        public void Given_NewRoom_When_Created_Then_CheckIfValuesAreNotEmptyOrNull()
        {
            var newRoom = new Room();
            var standardRoomIdLen = "ROOM.".Length + guidLength;

            Assert.IsTrue(newRoom.ObjectId.StartsWith("ROOM."));
            Assert.AreEqual(standardRoomIdLen, newRoom.ObjectId.Length);
        }

        [TestMethod]
        public void Given_NewRoom_When_GivenIdAndName_Then_CheckIfValuesAreValid()
        {
            var tempId = "tempRoomId";
            var tempName = "tempRoomName";
            var tempDesc = "tempRoomDescription";
            var newRoom = new Room(tempId, tempName, tempDesc);

            Assert.AreEqual(tempId, newRoom.ObjectId);
            Assert.AreEqual(tempName, newRoom.Name);
            Assert.AreEqual(tempDesc, newRoom.Description);
        }

        [TestMethod]
        public void Given_NewRoom_When_Created_Then_CheckIfObjectIdIsValid()
        {
            var newRoom = new Room();

            Assert.IsTrue(!string.IsNullOrEmpty(newRoom.ObjectId));
            Assert.IsTrue(string.IsNullOrEmpty(newRoom.Name));
            Assert.AreEqual(string.Empty, newRoom.Description);
        }
    }
}