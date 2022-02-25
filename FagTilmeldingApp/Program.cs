using FagTilmeldingApp.Codes;
// Iteration 7_Icomparable


List<FagModel> ListCourse = new()
{
    new FagModel() { CourseID = 1, CourseName = "Grundlæggende programmering" },
    new FagModel() { CourseID = 2, CourseName = "Database programmering", },
    new FagModel() { CourseID = 3, CourseName = "Studieteknik" }

};
Console.WriteLine("------------------------------------------");
Console.WriteLine("Usorteret list af fag :");
Console.WriteLine("------------------------------------------");
foreach (FagModel course in ListCourse)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(course.CourseID + " "+course.CourseName);
    Console.ForegroundColor= ConsoleColor.White;
}
Console.WriteLine("------------------------------------------");

Console.WriteLine("Sorteret List af fag: ");
Console.WriteLine("------------------------------------------");
ListCourse.Sort();
foreach (FagModel course1 in ListCourse)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(course1.CourseID + " " + course1.CourseName);
    Console.ForegroundColor = ConsoleColor.White;
}
Console.WriteLine("------------------------------------------");

Console.WriteLine("Reverse listen af fag: ");
Console.WriteLine("------------------------------------------");

ListCourse.Reverse();

foreach (FagModel course2 in ListCourse)
{
    Console.ForegroundColor = ConsoleColor.Red;
   Console.WriteLine(course2.CourseID + ". " + course2.CourseName);
    Console.ForegroundColor = ConsoleColor.White;
}



Console.ReadKey();