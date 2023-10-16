using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctroitCredits.Models
{
    public class CreditModel
    {
        public int CreditId { get; set; }
        public int clientId { get; set; }
        public int compteId { get; set; }
        public float montant { get; set; }
        public string duree { get; set; }
        public float taux_interet { get; set; }

        public string statut { get; set; }
        public string relevespaie { get; set; }
        public DateTime datecredit { get; set; }

    }
}
