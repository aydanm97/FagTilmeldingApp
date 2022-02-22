using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal class ValidateClass
    {
        public int FagetsID { get; set; }
        public int ElevensID { get; set; }
        

        public bool EnrollmentValidation(List<Enrollment> listEnrollment)
        {
            bool ok = true;
            Enrollment? enrollmentID = listEnrollment.FirstOrDefault(a => a.FagID == FagetsID && a.ElevID == ElevensID);

            if (enrollmentID != null)
            {
                ok = false;
            }
            return ok;
        }
        public bool ValidateStudent(string elevID, List<StudentModel> ListStudent)
        {
            bool ok = int.TryParse(elevID, out int resultat);
            if (ok!)
                return ok;
            else
            {
                StudentModel? studentID = ListStudent.FirstOrDefault(a => a.StudentID == resultat);
                if (studentID == null)
                {
                    ok = false;
                    Console.WriteLine("Det elevID eksisterer ikke");
                }
                else
                {
                    ElevensID = resultat;
                }
                
            }
            return ok;
        }
        public bool ValidateFag(string fagID, List<FagModel> ListCourse)
        {
            bool ok = int.TryParse(fagID, out int resultat);
            if (!ok)
                Console.WriteLine("Faget er i forkert format");
            else
            {
                FagModel? fagId = ListCourse.FirstOrDefault(a => a.CourseID == resultat);
                if (fagId == null)
                {
                    ok = false;
                    Console.WriteLine("Det FagID som du indtastede eksisterer ikke");
                }
                else
                {
                    FagetsID = resultat;
                }
            }
            return ok;
        }

    }
}
