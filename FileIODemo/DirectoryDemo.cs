using System.IO;
public class DirectoryDemo
{
    public void DirectoryDemoFunc(string directoryName)
    {
       if(Directory.Exists(directoryName))
       {
            System.Console.WriteLine("Floder already exists.");
        }
        else
        {
            Directory.CreateDirectory(directoryName);
            System.Console.WriteLine("Floder created successfully.");
        }
    }
}