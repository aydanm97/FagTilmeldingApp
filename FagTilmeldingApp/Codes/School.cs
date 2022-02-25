using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal abstract class School
    {
        string? SchoolName { get; set; }
        public int FagIAlt { get; set; }

        public School(string schoolName)
        {
            SchoolName = schoolName;
        }

        
            public virtual void SetCourseCount(List<FagModel>courses)
        {
            FagIAlt = courses.Count();
        }
    }
}
