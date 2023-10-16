using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctroitCredits.Models
{
    public class DemmandeModel
    {
        public int demandeId {get; set;}
        public int clientId { get; set; }
        public float montant { get; set; }
        public string duree { get; set; }
        public string motif { get; set; }
        public DateTime dateDemande { get; set; }
      
    }
}
