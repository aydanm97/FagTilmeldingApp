using FagTilmeldingApp.Codes;
// Iteration6
int UelevID = 0;
int UcourseID = 0;
string beskrivelse;
string errormsg = null;


FrameworkHandler handler = new FrameworkHandler();
List<Teacher> TeacherList = handler.GetTeacher();
List<Student> StudentList = handler.GetStudent();
List<Course> CourseList = handler.GetCourses();
List<Enrollment> EnrollmentList = handler.GetEnrollment();
Enrollment enrollment = new Enrollment();

//handler.ClearEnrollment();

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
if (key.Key == ConsoleKey.D1)
    Console.WriteLine(" Angiv kort beskrivelse af uddannelseslinje?: ");
beskrivelse = Console.ReadLine();
forløb.UddannelseslinjeBeskrivelse(beskrivelse);



forløb.ChooseUddannelseslinje(uddannelse);

while (true)
{
    Console.WriteLine("-----------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Tilmeldningsapp fra {0}, til {1} i {2} ", skole, hovedforløb, uddannelse);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("[ {0} ]", beskrivelse);
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.White;
    try
    {
        EnrollmentList = handler.GetEnrollment();
        List<Enrollment> listen = EnrollmentList.Where(a => a.CourseId == 2 && a.CourseId == 3 && a.CourseId == 4).ToList();
        if (listen.Count() > 3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            throw new Exception("Der må max være 3 elever i hver fag!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }


    //Lister fra vores Database 

    //ADOHandler adoHandler = new();
    //List<TeacherModel> teachers = adoHandler.GetTeachers();
    //List<StudentModel> students = adoHandler.GetStudents();
    //List<FagModel> courses = adoHandler.GetFag();

    //handler.ClearEnrollment();



    //viser antal af elever som er tilmeld i forskellige fage 
    Console.WriteLine("-----------------------------------------------");
    List<Enrollment> ListEleverShow = EnrollmentList.Where(a => a.CourseId == 2).ToList();
    Console.WriteLine(ListEleverShow.Count() + " Elever i Grundlæggende programmering");

    ListEleverShow = EnrollmentList.Where(a => a.CourseId == 3).ToList();
    Console.WriteLine(ListEleverShow.Count() + " Elever i Database programmering");

    ListEleverShow = EnrollmentList.Where(a => a.CourseId == 4).ToList();
    Console.WriteLine(ListEleverShow.Count() + " Elever i Studieteknik");

    Console.WriteLine();
    Console.WriteLine("-----------------------------------------------");

    List<Student> students = StudentList.Where(a => a.StudentId == UelevID).ToList();
    List<Course> courses = CourseList.Where(a => a.CourseId == UcourseID).ToList();
    foreach (Student student in students)
    {
        Console.WriteLine(student.FirstName + " " + student.LastName + "  Har tilmeldt fagen: ");
    }
    foreach (Course course in courses)
    {
        Console.Write(course.Course1);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n----------------------------------------------------------------");
    }
    Console.WriteLine(errormsg);
    errormsg = null;



    while (errormsg == null)
    {
        Console.WriteLine("Indtast FagID");
        try
        {
            UcourseID = Convert.ToInt32(Console.ReadLine());

            List<Course> valid = CourseList.Where(a => a.CourseId == UcourseID).ToList();

            if (valid.Count > 0)
            {
                enrollment.CourseId = Convert.ToInt32(UcourseID);
                break;
            }
            else
            {
                errormsg = ("Faget findes ikke i databasen!!!");
            }
        }
        catch
        {
            errormsg = ("Det er ikke et tal!! Indtast venligst et tal.");
        }
    }
    while (errormsg == null)
    {
        Console.WriteLine("Indtast ElevID");
        try
        {
            UelevID = Convert.ToInt32(Console.ReadLine());
            List<Student> validstudent = StudentList.Where(a => a.StudentId == UelevID).ToList();
            if (validstudent.Count > 0)
            {
                enrollment.StudentId = Convert.ToInt32(UelevID);
                break;
            }
            else
            {
                errormsg = ("Eleven findes ikke i databasen");
            }
        }
        catch
        {
            errormsg = ("Det er ikke et tal");
        }
        if (errormsg == null)
        {
            List<Enrollment> validenrollment = EnrollmentList.Where(a => a.StudentId == UelevID && a.CourseId == UcourseID).ToList();
            if (validenrollment.Count == 0)
            {
                handler.InsertEnrollment(UelevID, UcourseID);
            }
        }
        else
        {

            Console.WriteLine("Eksisterer allerede i databasen");
            UelevID = 0;
            UcourseID = 0;
            Console.ReadKey();
        }
    }

    //if (ok)
    //{
    //    Console.WriteLine("Indtast ElevID");
    //    string elevID = Console.ReadLine();
    //    Console.Clear();
    //    ok = v.ValidateStudent(elevID, StudentList);
    //    if (ok)
    //    {
    //        ok = v.EnrollmentValidation(EnrollmentList);
    //        if (!ok)
    //        {
    //            Console.WriteLine("Brugeren eksisterer allerede.");
    //            break;
    //        }
    //        else
    //        {
    //            //tilføjer i enrollment listen 
    //            handler.InsertEnrollment(v.ElevensID,v.FagetsID);
    //            List<Enrollment> valid = EnrollmentList.Where(a => a.StudentId == UelevID && a.CourseId == UcourseID).ToList();

    //        }
    //    }
    //    else
    //    {
    //        errormsg = "Fejl";
    //        break;
    //    }
    //}
    //else
    //{
    //    Console.WriteLine("Fejl");
    //    break;
    //}
}








