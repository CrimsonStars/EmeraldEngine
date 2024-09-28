using System.Data.Common;

namespace InputTesting.ConsoleApp.Model.Additional_structures
{
    public class Vector2d
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2d Normalise()
        {
            var result = new Vector2d();
            var maxValue = X > Y ? X : Y;

            if (maxValue > 0.0f)
            {
                result = new Vector2d()
                {
                    X = X / maxValue,
                    Y = Y / maxValue,
                };
            }

            return result;
        }

        public static Vector2d operator +(Vector2d left, Vector2d right)
        {
            return new Vector2d(left.X+right.X, left.Y+right.Y);
        }

        // TO DO
        //public static Vector2d operator - {Vector2d a, Vector2d b)
        //{
            
        //}

        public override string ToString() => $"X = {X}; Y = {Y};";

        #region Public constructors
        public Vector2d(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns default 2D vector = [0; 0]
        /// </summary>
        public Vector2d() => new Vector2d(0.0f, 0.0f);
        #endregion
    }
}
