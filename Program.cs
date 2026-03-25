using RConstantine;
using System.IO;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();

void Main()
{
    Console.WriteLine("======================================================");
    Console.WriteLine("Welcome to the RConstantine, you file transfer manager");
    Console.WriteLine("======================================================");

    bool fileExist = false;
    do
    {
        Console.Write("Type were is your origin file: ");
        string path = Console.ReadLine()!;

        if (ValidationOfFile(path))
        {
            fileExist = true;
        }
        else
        {
            fileExist = false;
            Console.WriteLine("O arquivo não existe ou o caminho está incorreto...");
        }

    } while (fileExist == false);
    


}

bool ValidationOfFile(string path)
{
    string file = path;
    if (File.Exists(file) == true)
    {
        return true;
    }
    else
    {
        return false;
    }
}

string GetFile(string sourcePath, string destPath, bool overwrite)
{
    File.Create(destPath);

}