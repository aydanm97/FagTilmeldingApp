using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal class FagModel: IComparable<FagModel>
    {
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public int CompareTo(FagModel next)
        {
            return this.CourseName.CompareTo(next.CourseName);
        }
        //Sort by numbers

        //public int CompareTo(FagModel next)
        //{
        //    return this.CourseID.CompareTo(next.CourseID);
        //}
    }
}
