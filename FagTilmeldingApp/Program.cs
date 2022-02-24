using FagTilmeldingApp.Codes;
// Iteration5_Dataintegration_ExceptionHandling
string beskrivelse;
ConsoleKeyInfo key;
Console.WriteLine("Hvad hedder skolen?: ");
string? skole = Console.ReadLine();
Console.WriteLine("Angiv hovedforløb: ");
string? hovedforløb = Console.ReadLine();
Console.WriteLine("Hvad er din uddannelseslinje? : ");
string? uddannelse = Console.ReadLine();
Console.WriteLine("Ønsker du at angive en kort beskrivelse af uddannelseslinje");
Console.WriteLine("1) JA");
Console.WriteLine("2) NEJ");
key = Console.ReadKey();
Forløb forløb = new(skole, hovedforløb);
if (key.Key==ConsoleKey.D1)
    Console.WriteLine(" Angiv kort beskrivelse af uddannelseslinje?: ");
    beskrivelse = Console.ReadLine();
    forløb.UddannelseslinjeBeskrivelse(beskrivelse);


forløb.ChooseUddannelseslinje(uddannelse);




Console.WriteLine("-----------------------------------------------");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Tilmeldningsapp fra {0}, til {1} i {2} ", skole, hovedforløb,uddannelse);
Console.ForegroundColor= ConsoleColor.Yellow;
Console.WriteLine("[ {0} ]",beskrivelse);
Console.WriteLine("-----------------------------------------------");
Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.White;


//Lister fra vores Database 

ADOHandler adoHandler = new();
List<TeacherModel> teachers = adoHandler.GetTeachers();
List<StudentModel> students = adoHandler.GetStudents();
List<FagModel> courses = adoHandler.GetFag();

List<Enrollment> ListEnrollment = new();
ValidateClass v = new ValidateClass();
while (true)
{
    //viser antal af elever som er tilmeld i forskellige fage 
    Console.WriteLine("-----------------------------------------------");
    List<Enrollment> ListEleverShow = ListEnrollment.Where(a => a.FagID == 1).ToList();
    Console.WriteLine($"{ListEleverShow.Count()} Elever i Grundlæggende programmering");

    ListEleverShow = ListEnrollment.Where(a => a.FagID == 2).ToList();
    Console.WriteLine($"{ListEleverShow.Count()} Elever i Database programmering");

    ListEleverShow = ListEnrollment.Where(a => a.FagID == 3).ToList();
    Console.WriteLine($"{ListEleverShow.Count()} Elever i Studieteknik");
    Console.WriteLine();
    Console.WriteLine("-----------------------------------------------");

    foreach (Enrollment showInfo in ListEnrollment)
    {//Kalder på forskellige lister og sammenligner dem med Enrollment listen
        FagModel showFag = courses.FirstOrDefault(a => a.CourseID == showInfo.ID);
        StudentModel showElev = students.FirstOrDefault(a => a.StudentID == showInfo.ID);

        if (showFag != null && showElev != null)
            Console.WriteLine($"{showElev.StudentFirstName} {showElev.StudentLastName} er tilmeldt {showFag.CourseName}");

    }



    bool ok = false;
    while (!ok)
    {
        Console.WriteLine("Indtast FagID");
        string fagID = Console.ReadLine();
        ok = v.ValidateFag(fagID, courses);
        if (ok)
        {
            Console.WriteLine("Indtast ElevID");
            string elevID = Console.ReadLine();
            Console.Clear();
            ok = v.ValidateStudent(elevID, students);
            if (ok)
            {
                ok = v.EnrollmentValidation(ListEnrollment);
                if (!ok)
                {
                    Console.WriteLine("Brugeren eksisterer allerede.");
                    break;
                }
                else
                {
                    //tilføjer i enrollment listen 
                    ListEnrollment.Add(new Enrollment() { ID = ListEnrollment.Count() + 1, FagID = v.FagetsID, ElevID = v.ElevensID });


                }
            }
            else
            {
                Console.WriteLine("Fejl");
                break;
            }
        }
        else
        {
            Console.WriteLine("Fejl");
            break;
        }
    }
}





