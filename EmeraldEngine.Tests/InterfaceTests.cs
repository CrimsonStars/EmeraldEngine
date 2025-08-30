namespace EmeraldEngine.Tests
{
    using EmeraldEngine.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InterfaceTests
    {
        private string testRoomName = "testRoomName";
        private string testRoomId = "tempRoomId";

        [TestMethod]
        public void Given_NewRoom_When_SetNameAndObjectID_Then_CheckIfValid()
        {
            var testRoom = new Room();
            testRoom.SetName(testRoomName).SetObjectId(testRoomId);

            Assert.AreEqual(testRoomName, testRoom.Name);
            Assert.AreEqual(testRoomId, testRoom.ObjectId);
        }

        [TestMethod]
        public void Given_NewRoom_When_SetNameAndObjectIdWithConstructor_Then_CheckIfValid()
        {
            var testRoom = new Room();
            testRoom.SetName(testRoomName).SetObjectId(testRoomId);
            testRoom.SetBasicInformation(testRoomId, testRoomName);

            Assert.AreEqual(testRoomName, testRoom.Name);
            Assert.AreEqual(testRoomId, testRoom.ObjectId);
        }

        [TestMethod]
        public void Given_NewRoom_When_ConstructedWithLongChainOfMethods_Then_CheckIfValid()
        {
            var lastName = "lastRoomName";
            var lastId = "lastNewRoomId";
            var testRoom = new Room();

            testRoom.SetName("firstName").SetObjectId("firstId")
            .SetName("secondName").SetObjectId("secondId")
            .SetName("thirdName").SetObjectId("thirdId")
            .SetName("fourthName").SetObjectId("fourthId")
            .SetName(lastName).SetObjectId(lastId);

            Assert.AreEqual(lastName, testRoom.Name);
            Assert.AreEqual(lastId, testRoom.ObjectId);
        }

        [TestMethod]
        public void Given_NewRoom_When_Addingdescription_Then_CheckValues()
        {
            var testDescription = "Lorem ipsum.";
            var testRoom = new Room();

            Assert.IsNotNull(testRoom);
            Assert.IsTrue(string.IsNullOrEmpty(testRoom.Description));
            Assert.IsTrue(string.IsNullOrEmpty(testRoom.Name));
            Assert.IsTrue(!string.IsNullOrEmpty(testRoom.ObjectId));

            // Setting description for tests
            testRoom.SetDescription(testDescription);

            Assert.AreEqual(testDescription, testRoom.Description);
            Assert.IsTrue(string.IsNullOrEmpty(testRoom.Name));
            Assert.IsTrue(!string.IsNullOrEmpty(testRoom.ObjectId));
        }
    }
}