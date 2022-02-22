using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal sealed class Forløb : Skole
    {
        string ForløbNavn { get; set; }

        public Forløb(string forløbNavn, string skoleNavn) : base(skoleNavn) 
        {
            ForløbNavn = forløbNavn;
        }
    }
}
