namespace TestingLibrary.TUI
{
    using Spectre.Console;
    using System;

    internal class Program
    {
        public static void Main()
        {
            var panelLeft = new Panel("Left");
            panelLeft.Border=BoxBorder.Rounded;
            panelLeft.Header = new PanelHeader("Rooms");
            panelLeft.Expand();

            var panelRight = new Panel("Right");            

            var tempLayout = new Layout("temp");
            tempLayout.SplitColumns(
                new Layout("left"),
                new Layout("right")
                );

            tempLayout["left"].Ratio = 3;
            tempLayout["right"].Ratio = 7;

            tempLayout["right"].Update(panelRight);
            tempLayout["left"].Update(panelLeft);

            AnsiConsole.Write(tempLayout);

            while(true)
            {

            }
            

        }
    }
}