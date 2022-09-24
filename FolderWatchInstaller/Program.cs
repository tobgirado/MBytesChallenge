using System.Diagnostics;

// See https://aka.ms/new-console-template for more information
try
{


    string command = Environment.GetCommandLineArgs()[1];

    var p = new Process();

    p.StartInfo.UseShellExecute = false;
    p.StartInfo.RedirectStandardOutput = true;
    p.StartInfo.RedirectStandardError = true;
    p.StartInfo.RedirectStandardInput = true;

    if (command == "-install")
    {
        p.StartInfo.FileName = "C:\\Windows\\SysWow64\\sc.exe";
        p.StartInfo.Arguments = $"create \"FolderWatch\" binpath=\"{System.IO.Directory.GetCurrentDirectory()}\\MalwarebytesService.exe\" start=auto";

        Console.WriteLine(":: Installing FOlderWatch Service::");

        p.Start();
        string output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();

        Console.WriteLine(output);

        Console.WriteLine("Attempting to start service");

        p.StartInfo.Arguments = $"start \"FolderWatch\"";
        p.Start();

        output = p.StandardOutput.ReadToEnd();

        p.WaitForExit();
        Console.WriteLine(output);

        Console.WriteLine(":: Press any key to finish ::");
        Console.ReadKey();
    }
    else if (command == "-uninstall")
    {

        p.StartInfo.FileName = "C:\\Windows\\SysWow64\\sc.exe";

        Console.WriteLine("Attempting to stop service if it is running");
        p.StartInfo.Arguments = $"stop \"FolderWatch\"";
        p.Start();

        string output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();


        Console.WriteLine("Deleting service:");
        p.StartInfo.Arguments = $"delete \"FolderWatch\"";
        p.Start();

        output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();
        Console.WriteLine(output);
    }
    else
    {
        throw new ArgumentException($"Argument {command} is not valid.");
    }

}
catch (Exception ex)
{
    Console.WriteLine($"Something happened while installing the service: {ex.Message}");
}