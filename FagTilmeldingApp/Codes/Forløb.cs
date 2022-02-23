using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FagTilmeldingApp;

namespace FagTilmeldingApp.Codes
{
    internal sealed class Forløb : Skole
    {
        string ForløbNavn { get; set; }
        string? Uddannelse { get; set; }
        string? Beskrivelse { get; set; }

        public Forløb(string forløbNavn, string skoleNavn) : base(skoleNavn) 
        {
            ForløbNavn = forløbNavn;
        }

      

        public override void ChooseUddannelseslinje(string? uddannelse)
        {
            Uddannelse = uddannelse;
        }
        public override void UddannelseslinjeBeskrivelse(string? beskrivelse)
        {
            Beskrivelse = beskrivelse;
        }
    }
}
