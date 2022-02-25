using FagTilmeldingApp.Codes;
// Iteration 7_Icomparable


List<FagModel> ListCourse = new()
{
    new FagModel() { CourseID = 1, CourseName = "Grundlæggende programmering" },
    new FagModel() { CourseID = 2, CourseName = "Database programmering", },
    new FagModel() { CourseID = 3, CourseName = "Studieteknik" },
    new FagModel() { CourseID = 4, CourseName ="Clientside programmering"}

};
Semester semester = new Semester("TEC", "H1");
semester.SetCourseCount(ListCourse);

Console.WriteLine($"H1 har i alt : {semester.ProgrammeringsFagIAlt} programmeringsfag.");
Console.WriteLine();
Console.WriteLine($"Skolen har i alt: {semester.FagIAlt} fag");
Console.ReadKey();