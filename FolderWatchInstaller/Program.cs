using System.Diagnostics;

// See https://aka.ms/new-console-template for more information
string command = Environment.GetCommandLineArgs()[1];

if (command == "-install")
{
    Console.WriteLine("Installing the stuff");

    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
    cmdsi.ArgumentList.Add($"C:\\Windows\\SysWow64\\sc.exe create \"FolderWatch\" binpath=\"{System.IO.Directory.GetCurrentDirectory()}\\MalwarebytesService.exe\"");
    cmdsi.ArgumentList.Add($"C:\\Windows\\SysWow64\\sc.exe start \"FolderWatch\"");

    Process cmd = Process.Start(cmdsi);

    cmd.WaitForExit(); //wait indefinitely for the associated process to exit.

    Console.WriteLine("Finished Installing the stuff");
}
if (command == "-uninstall")
{

}




