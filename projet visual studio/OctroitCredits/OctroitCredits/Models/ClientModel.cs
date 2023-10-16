using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctroitCredits.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Noms { get; set; }
        public string Sexe { get; set; }
        public DateTime Datenaiss { get; set; }
        public string Adresse { get; set; }
        public string Etatcivil { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public string Profession { get; set; }
        public string Adressepostal { get; set; }
        public string Nationalite { get; set; }

    }
}
