using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctroitCredits.Models
{
    public class EcheanceModel
    {
        public int echeanceId { get; set; }
        public int clientId { get; set; }
        public int creditId { get; set; }
        public float montantcredit { get; set; }
        public float montantpayer { get; set; }
        public DateTime dateEcheance { get; set; }

    }
}
