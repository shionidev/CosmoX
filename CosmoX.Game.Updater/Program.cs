using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Hexium.Collections.Management;
using Hexium.Application.Diagnostics;
using CosmoX.Game;
using CosmoX.Desktop;

class Program
{
    public static void HexiumWriteLine(string message)
    {
        Console.Write("[Hexium] ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void SystemWriteLine(string message)
    {
        Console.Write("[System] ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void ErrorWriteLine(string message)
    {
        Console.Write("[Error] ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    static void Main(string[] args)
    {

        SystemWriteLine("Initializing...");
        Console.WriteLine("------------------------------");
        Thread.Sleep(5000);

        SystemWriteLine("Preparing for launch...");
        Console.WriteLine("------------------------------");
        Thread.Sleep(4500);

        Console.Clear();

        HexiumWriteLine("Searching for the game executable... (This process may take some time.)");
        Thread.Sleep(10000);

        string gameExecutablePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DevCore9", "CosmoX", "CosmoX.exe");

        if (File.Exists(gameExecutablePath))
        {
            try
            {
                Process gameProcess = Process.Start(gameExecutablePath);
                gameProcess.WaitForExit();
                Console.Clear();

                HexiumWriteLine("The game executable has been located...");
                Thread.Sleep(5000);
                SystemWriteLine("Preparing...");
                Thread.Sleep(5000);
                SystemWriteLine("Launching the game...");
                Thread.Sleep(5000);
                Console.Clear();
                SystemWriteLine("");
            }
            catch (Exception ex)
            {
                ErrorWriteLine($"Failed to launch the game: {ex.Message}");
            }
        }
        else
        {
            Console.Clear();
            HexiumWriteLine("Game executable cannot be located...");
            Thread.Sleep(1000);
            HexiumWriteLine("Please review your game folders to ensure all files are valid and try again later.");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Thread.Sleep(4500);
            Console.Clear();
            SystemWriteLine("Hexium will instantly close after 10 seconds");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Thread.Sleep(10000);
            SystemWriteLine("Stopping...");
            Thread.Sleep(2000);
            SystemWriteLine("Closing Application...");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            ErrorWriteLine("Services: Stopped");
            Thread.Sleep(1500);
            Environment.Exit(1);

        }

        Console.ReadLine();
    }
}
