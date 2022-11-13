using SMS.implementation;
using SMS.menu;
// using MySql.Data.MySqlClient;

namespace SMS
{
    class Program
    {
        static void Main(string[] args)
        {
            var adminManager = new AdminManager();
            adminManager.ReadFromFile();
            var mainMenu = new MainMenu();
            mainMenu.AllMainMenu();
        }
        // public string GenerateRandomId()
        // {
        //     string alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper();
        //     int r1 = new Random().Next(25);
        //     int r2 = new Random().Next(25);
        //     string staffId = $"A{alphabet[r1]}{alphabet[r2]}" + new Random().Next(1100000).ToString();
        //     return staffId;
        // }


        // Console.Write("Enter integer: ");
        // int a ;//= int.Parse(Console.ReadLine());

        // FileStream fileStream = File.Create( @"./Files/admin.txt");
        // fileStream.Close();

        // FileStream fileStream1 = new FileStream( @"./admin.txt", FileMode.CreateNew);

        // string dirPath = @"C:\Users\Treehays\Documents\CLH\CreatedJustNow\anotherFolder";
        // string filePath = @"C:\Users\Treehays\Documents\CLH\CreatedJustNow\anotherFolder\thisIsmyfil.txt";



        // Directory.Delete(dirPath);
        // DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
        // directoryInfo.Create();
        // FileInfo




        // File.WriteAllText(filePath,"weyigkdwwdkfnwkj");
        // FileInfo fileInfo = new FileInfo(filePath);
        // FileStream fileStream = new FileStream(filePath, FileMode.CreateNew);
        // StreamWriter streamWriter = new StreamWriter(filePath,append: true);
        // string dghs = "dhgndslkjfslkfsmf;sknf";

        // char[] f = { 'd', 'd' };
        // streamWriter.WriteLine(f);
        // streamWriter.Close();
        // StreamReader streamReader = new StreamReader(filePath);
        // Console.WriteLine(streamReader.ReadLine());
        // Console.WriteLine(streamReader.ReadLine());
        // Console.WriteLine(streamReader.ReadLine());
        // Console.WriteLine(streamReader.ReadLine());
        // Console.WriteLine(streamReader.ReadLine());
        // Console.WriteLine(streamReader.ReadLine());
        // Console.WriteLine(streamReader.ReadToEnd());
        // streamReader.ReadLine();
        // StreamWriter writer = new StreamWriter(filePath);
        // writer.WriteLine("Welcome to the Bank");
        // writer.Close();



        // System.Console.WriteLine(Directory.Exists(dirPath));

        /*
        File
        Fileinfo
        directory
        directoryinfo
        streamwriter
        streamReading
        textreader 
        textwriter
        BinaryWrit

        */

        // string a = "w";
        // string b = "a";
        // string c = a+b;
        // System.Console.WriteLine(a+b);

        // DateTime dv = DateTime.Parse("2022/11/29");
        // DateTime che = DateTime.UtcNow;
        // System.Console.WriteLine(DateTime.Now.Day);
        // System.Console.WriteLine(che);
        // // System.Console.WriteLine(che-dv.Day);
        // System.Console.WriteLine((dv-che).Days+1);
        // double cashTender1;
        // while (!double.TryParse(Console.ReadLine(), out cashTender1))
        // {
        //     System.Console.WriteLine("wrong input.. Try again.");
        // }
        // string x = "1212";
        // bool dd;
        // string wrd = x.ToString();
        // for (int i = wrd.Length-1; i >= 0; i--)
        // {

        // System.Console.Write(x.ToCharArray().Reverse());



    }
}

