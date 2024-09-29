using System.Data.Common;

namespace InputTesting.ConsoleApp.Model.Additional_structures
{
    public class Vector2d
    {
        public float U { get; set; }
        public float V { get; set; }

        public Vector2d Normalise()
        {
            var result = new Vector2d();
            var maxValue = U > V ? U : V;

            if (maxValue > 0.0f)
            {
                result = new Vector2d()
                {
                    U = U / maxValue,
                    V = V / maxValue,
                };
            }

            return result;
        }

        public static Vector2d operator +(Vector2d left, Vector2d right)
        {
            return new Vector2d(left.U+right.U, left.V+right.V);
        }

        public static Vector2d operator -(Vector2d left, Vector2d right)
        {
            return left + -right;
        }

        public static Vector2d operator -(Vector2d inputVector)
        {
            return new Vector2d()
            {
                U = -inputVector.U,
                V = -inputVector.V,
            };
        }

        public override string ToString() => $"X = {U}; Y = {V};";

        #region Public constructors
        public Vector2d(float x, float y)
        {
            U = x;
            V = y;
        }

        /// <summary>
        /// Returns default 2D zero vector = [0; 0]
        /// </summary>
        public Vector2d() => new Vector2d(0.0f, 0.0f);
        #endregion
    }
}
