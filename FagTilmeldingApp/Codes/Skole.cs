using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal abstract class Skole
    {
        string SkoleNavn { get; set; }

        public Skole (string skoleNavn)
        {
            SkoleNavn = skoleNavn;
        }
        public abstract void ChooseUddannelseslinje(string? uddannelse);
        public abstract void UddannelseslinjeBeskrivelse (string?beskrivelse);
    }
}
