using System;
using System.Collections.Generic;

namespace FagTilmeldingApp.EntityFramework
{
    public partial class Enrollment
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
    }
}
