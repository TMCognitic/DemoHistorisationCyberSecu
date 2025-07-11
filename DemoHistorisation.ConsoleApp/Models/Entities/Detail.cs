using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHistorisation.ConsoleApp.Models.Entities
{
    public class Detail
    {
        public Detail(int produitId, int quantite, double prix)
        {
            ProduitId = produitId;
            Quantite = quantite;
            Prix = prix;
        }

        public int ProduitId { get; }
        public int Quantite { get; }
        public double Prix { get; }
    }
}
