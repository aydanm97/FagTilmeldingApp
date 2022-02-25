using System;
using System.Collections.Generic;

namespace FagTilmeldingApp.EntityFramework
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
