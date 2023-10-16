using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctroitCredits.Models
{
    public class TauxModel
    {
        public int Id { get; set; }
        public string Categoriecredit { get; set; }
        public decimal Taux_annuel { get; set; }
        public decimal Taux_mensuel { get; set; }
    }
}
