using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tourax.Models
{
    public class CableModel
    {
        public string TypeCable { get; set; }
        public double Diametre { get; set; }
        public double Largeur { get; set; }
        public double Epaisseur { get; set; }
        public string TechniqueEnroulement { get; set; }
        public double CoeffRemplissage { get; set; }
        public double PoidsCable { get; set; }
        public double LongueurCable { get; set; }
        public bool CaseNonSecable { get; set; }
    }
}
