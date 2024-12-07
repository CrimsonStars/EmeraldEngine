namespace EmeraldEngine.Tests
{
   using EmeraldEngine.Models;
   using Microsoft.VisualStudio.TestTools.UnitTesting;
   using System.Diagnostics;

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

      [TestMethod]
      public void SillySimpleTests()
      {
         Assert.IsNotNull(_gameworld);
      }

      [TestMethod]
      [TestCategory("Sandbox - not for final")]
      public void _SandboxTests_00()
      {
         Trace.Write(_gameworld.CurrentRoomInfoDump());

         Assert.Fail();
      }
   }
}