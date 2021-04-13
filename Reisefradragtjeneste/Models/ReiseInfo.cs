using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reisefradragtjeneste.Models
{
    public class ReiseInfo
    {
        public int Id { get; set; }
        public Reise[] Arbeidsreise { get; set; }
        public Reise[] Besoksreise { get; set; }
        public double UtgifterBomFergeEtc { get; set; }
    }
}
