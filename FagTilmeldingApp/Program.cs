using FagTilmeldingApp.Codes;
// Iteration 2
Semester se = new Semester("");
Console.WriteLine("Angiv skole: ");
string? skole = Console.ReadLine();
Console.WriteLine("Angiv hovedforløb: ");
string? hovedforløb = Console.ReadLine();
Console.ReadKey();
Console.Clear();
Console.Title =" fag tilmeldning app";
Console.WriteLine("-----------------------------------------------");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("{1},{2} {0}", Console.Title,skole,hovedforløb);
Console.WriteLine("-----------------------------------------------");
Console.ReadKey();

