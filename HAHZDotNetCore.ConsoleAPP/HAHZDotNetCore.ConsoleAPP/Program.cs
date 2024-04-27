// See https://aka.ms/new-console-template for more information
using HAHZDotNetCore.ConsoleApp;
using HAHZDotNetCore.ConsoleAPP.EFCoreExamples;

Console.WriteLine("Hello, World!");
/*AdoDotNetCRUD adoDotNetCRUD = new AdoDotNetCRUD();
//adoDotNetCRUD.Create("Title", "Author", "Content");
//adoDotNetCRUD.Read();
adoDotNetCRUD.Update(12, "Test Title", "Test Author", "Test Content");
adoDotNetCRUD.Delete(12);
adoDotNetCRUD.Edit(12);
adoDotNetCRUD.Edit(7);
*/
/*DapperExample dapperExample = new DapperExample();
dapperExample.Run();*/
EFCoreExample efcoreexample=new EFCoreExample();
efcoreexample.Run(); 
Console.ReadLine();