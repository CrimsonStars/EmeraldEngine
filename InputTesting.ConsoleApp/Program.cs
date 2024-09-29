using InputTesting.ConsoleApp.Model.Additional_structures;
using System.Numerics;

namespace InputTesting.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vec = new Vector2d();
            Console.WriteLine($"X = {vec.U}; Y = {vec.V};\n");

            vec = new Vector2d(10.01f, 4.77f);
            Console.WriteLine($"X = {vec.U}; Y = {vec.V};\n");

            vec = vec.Normalise();
            Console.WriteLine($"X = {vec.U}; Y = {vec.V};\n");
        }
    }
}