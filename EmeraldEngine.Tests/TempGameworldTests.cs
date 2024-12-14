namespace EmeraldEngine.Tests
{
    using EmeraldEngine.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TempGameworldTests
    {
        private static Gameworld? _gameworld;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _gameworld = Gameworld.Instance();
            _gameworld.ConstructWorld();
        }
    }
}