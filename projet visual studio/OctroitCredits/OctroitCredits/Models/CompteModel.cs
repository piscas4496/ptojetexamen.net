using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctroitCredits.Models
{
    public class CompteModel
    {
        public int id { set; get; }
        public int clientId { set; get; }
        public string numCompte { set; get; }
        public float montant { set; get; }
        public string libelle { set; get; }
        public DateTime dateOperation { set; get; }

        internal object GetAllCompte()
        {
            throw new NotImplementedException();
        }

        internal CompteModel GetCompteById(int id)
        {
            throw new NotImplementedException();
        }

        internal void CreateCompte(object compte)
        {
            throw new NotImplementedException();
        }

        internal void DeleteCompte(int id)
        {
            throw new NotImplementedException();
        }
    }
}
