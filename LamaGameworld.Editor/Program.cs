using LamaGameworld.Editor;
using Terminal.Gui;

internal class Program
{
    private static void Main(string[] args)
    {
        Application.Init();

        try
        {
            Application.Run(new MyView());
        }
        finally
        {
            Application.Shutdown();
        }
    }
}