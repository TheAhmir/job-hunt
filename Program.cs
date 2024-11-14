using System;

class Program
{
    static void Main()
    {

        Console.CancelKeyPress += new ConsoleCancelEventHandler(CancelKeyPressHandler);
        string[] options = {"View Job Applications", "Add Job Application", "Word Counter", "Exit"};
        int currentIndex = 0;

        DisplayList(options, currentIndex);

        while (true)
        {

            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.UpArrow)
            {
                currentIndex = (currentIndex - 1 + options.Length) % options.Length;
                DisplayList(options, currentIndex);
            }
            else if (key == ConsoleKey.DownArrow)
            {
                currentIndex = (currentIndex + 1) % options.Length;
                DisplayList(options, currentIndex);
            }
            else if (key == ConsoleKey.Enter)
            {
                switch (currentIndex)
                {
                    case 0:
                        Console.WriteLine("Menu paused while new terminal window is open..");
                        PythonViewApplication();
                        Console.Clear();
                        DisplayList(options, currentIndex);
                        break;
                    case 1:
                        Console.WriteLine("Menu paused while new terminal window is open..");
                        JuliaAddApplication();
                        Console.Clear();
                        DisplayList(options, currentIndex);
                        break;
                    case 2:
                        wordCounter();
                        Console.WriteLine("Press any key to return to menu..");
                        Console.ReadKey();
                        Console.Clear();
                        DisplayList(options, currentIndex);
                        break;
                    default:
                        Console.WriteLine("Exiting program..");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }

    private static void PythonViewApplication()
    {
        string command = @"cmd.exe";
        string arguments = @"/k components\view-applications\run-script.bat";

        try
        {
            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = arguments;

            process.StartInfo.UseShellExecute = true;
            process.StartInfo.CreateNoWindow = false;
            
            process.Start();
            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                Console.WriteLine("Python script finished successfully.");
            }
            else
            {
                Console.WriteLine("Python script has been exited..");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error starting process: {ex.Message}");
        }
    }

    private static void CancelKeyPressHandler(object? sender, ConsoleCancelEventArgs e)
    {
        e.Cancel = true;

        Console.WriteLine("Select 'Exit' to close this program safely.");
    }

    private static void JuliaAddApplication()
{
    // The command to run the Julia script with cmd.exe
    string command = @"cmd.exe";
    
    // Full arguments: to change directory and run the Julia script
    string arguments = @"/k ""cd /d components\add-applications && julia add-application.jl""";

    try
    {
        var process = new System.Diagnostics.Process();
        process.StartInfo.FileName = command;
        process.StartInfo.Arguments = arguments;

        // Set UseShellExecute to true to create a new window
        process.StartInfo.UseShellExecute = true;
        // Ensure CreateNoWindow is set to false
        process.StartInfo.CreateNoWindow = false;

        process.Start();

        // Wait for the process to exit
        process.WaitForExit();

        // You can check the exit code (0 for success, non-zero for errors)
        if (process.ExitCode == 0)
        {
            Console.WriteLine("Julia script finished successfully.");
        }
        else
        {
            Console.WriteLine($"Julia script has been exited..");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error starting process: {ex.Message}");
    }
}


    private static void wordCounter()
    {
        Console.Clear();
        Console.WriteLine("Word Counter... \n");
        string input = Console.ReadLine();
        Console.WriteLine("\n");
        
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("word count: 0");
        }
        else
        {
            string[] words = input.Split(new char[] {' ', '\n', '\t', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"word count: {words.Length}");
        }


    }

    static void DisplayList(string[] options, int currentIndex)
    {
        Console.Clear();
        Console.WriteLine("Pick a path.. \n");
        for (int i = 0; i < options.Length; i++)
        {
            if (i == 3)
            {
                Console.WriteLine();
            }
            if (i == currentIndex)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"> {options[i]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"{options[i]  }");
            }
        }
        Console.WriteLine();
    }
}