using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctroitCredits.Models
{
    public class EvenementModel
    {
        public int Id { get; set; }
        public int Client_id { get; set; }
        public int Credit_id { get; set; }
        public string Type_evenement { get; set; }
        public decimal Penalite { get; set; }
        public DateTime Date_evenement { get; set; }
    }
}
