using System.Reflection.Metadata.Ecma335;

namespace InputTesting.ConsoleApp.Model.Additional_structures
{
    public class Vector2d
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2d Normalise()
        {
            var result = new Vector2d();



            return result;
        }

        #region Public constructors
        public Vector2d(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector2d() => new Vector2d(0, 0);
        #endregion
    }
}
