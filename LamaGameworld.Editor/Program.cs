using LamaGameworld.Editor;
using LamaGameworld.Editor.Views;
using Terminal.Gui;

internal class Program
{
    private static Window ViewA;
    private static Window ViewB;


    private static void Main(string[] args)
    {
        Application.Init();
        var top = Application.Top;
        var window = new ComplexWindow("Placeholder text");

        try
        {
            top.Add(window);
            window = new ComplexWindow("Dupa");
            top.Add(window);
            Application.Run();

        }
        finally
        {
            Application.Shutdown();
        }
    }
}