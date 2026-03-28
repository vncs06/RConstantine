using RConstantine;
using System.IO;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();

Main();
void Main()
{
    Console.WriteLine("======================================================");
    Console.WriteLine("Welcome to the RConstantine, you file transfer manager");
    Console.WriteLine("======================================================");

    //Get SourcePath
    string sourcePath = "";
    bool fileExist = false;
    do
    {
        //Validating if the source file is valid
        Console.Write("Type were is your origin file: ");
        string path = Console.ReadLine()!;

        if (ValidationOfFile(path))
        {
            fileExist = true;
            sourcePath = path;
        }
        else
        {
            fileExist = false;
            Console.WriteLine("The file dont exist or the path is invalid! Try Again");
            Thread.Sleep(2000);
        }

    } while (fileExist == false);

    //Get destPath
    string destPath = "";
    bool destExist = false;
    do
    {
        //Get de destination path
        Console.Write("Type your destiny directory: ");
        string path = Console.ReadLine()!;

        //Validating if the destination path is valid
        if (ValidationOfDest(path))
        {
            destExist = true;
            destPath = Path.Combine(path, Path.GetFileName(sourcePath));
        }
        else
        {
            fileExist = false;
            Console.WriteLine("The directory of destiny is invalid or dont exist! Try again");
            Thread.Sleep(2000);
        }

    } while (destExist == false);

    //Call the method responsable for copy the file
    if (GetFile(sourcePath, destPath))
    {
        Console.Clear();
        Console.WriteLine("Done! Check the destiny directory");
        Console.WriteLine("Type any key to go to Menu...");
        Console.ReadKey();
        Main();
        
    }
    else
    {
        Console.Clear();
        Console.WriteLine("The file was not transfer with sucessful...check log in the destiny path");
        Console.WriteLine("Type any key to go to Menu...");
        Console.ReadKey();
        Main();

    }

}

// Here we can validating if the source File exist or the directory of the file is correct.
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

// Similar to ValidationOfFile, here we can validate if the DIRECTORY were the user wanna transfer the file is correct or even exist
bool ValidationOfDest(string desPath)
{
    string file = desPath;
    if (Directory.Exists(desPath))
    {
        return true;
    }
    else
    {
        return false;
    }
}

// In this method, we copy the file to the destination that user wanna copy and we validate if the file was successfuly copied.
bool GetFile(string sourcePath, string destPath)
{
    File.Copy(sourcePath, destPath);

    //Primeiro Teste - tamanho do arquivo
    var source = new FileInfo(sourcePath);
    long byteSource = source.Length;

    var dest = new FileInfo(destPath);
    long byteDest = source.Length;

    if (byteSource == byteDest)
    {
        return true;
        
    }
    else
    {
        return false;

    }

    //feature: Make a method that will be responsable for create the logs

}