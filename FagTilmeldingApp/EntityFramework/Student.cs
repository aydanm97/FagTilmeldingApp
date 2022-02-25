using System;
using System.Collections.Generic;

namespace FagTilmeldingApp.EntityFramework
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
