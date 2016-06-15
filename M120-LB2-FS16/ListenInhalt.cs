using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_LB2_FS16
{
    class ListenInhalt
    {
        public int ID {get; set;}
        public String Mitarbeiter {get; set;}
        public String ProjektBezeichnung {get; set;}
        public DateTime ProjektStart {get; set;}
        public DateTime ProjektEnde {get; set;}
        public TimeSpan ProjektDauer {get; set;}
    }
}
