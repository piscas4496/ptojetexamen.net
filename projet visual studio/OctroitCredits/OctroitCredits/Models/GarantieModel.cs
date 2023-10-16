using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctroitCredits.Models
{
    public class GarantieModel
    {
        public int Id { get; set; }
        public int Client_id { get; set; }
        public int Credit_id { get; set; }
        public string Infogarantie { get; set; }
        public decimal Valeurestimee { get; set; }
    }
}
