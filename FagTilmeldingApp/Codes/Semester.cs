using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal class Semester : School
    {
        string? SemesterNavn { get; set; } 
        public int ProgrammeringsFagIAlt { get; set; }
        public Semester(string semesterNavn, string? schoolName) : base(schoolName)
        {
            SemesterNavn = semesterNavn;
        }
        public override void SetCourseCount(List<FagModel> courses)
        {
            base.SetCourseCount(courses);
            ProgrammeringsFagIAlt=(courses.Where(a => a.CourseName.ToLower().Contains("programmering"))).Count();
        }
    }
}
