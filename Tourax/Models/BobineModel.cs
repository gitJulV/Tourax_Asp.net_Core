using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tourax.Models
{
    public class BobineModel
    {
        public int IdBobine { get; set; }
        public string Reference { get; set; }
        public string Nom { get; set; }
        public bool Trancanage { get; set; }
        public bool Enroulement { get; set; }
        public bool Consigne { get; set; }
        public double LargeurExt { get; set; }
        public double LargeurInt { get; set; }
        public double DiametreExt { get; set; }
        public double DiametreInt { get; set; }
        public double Moyeu { get; set; }
        public double PoidsAVide { get; set; }
        public double PoidsMaxAutorise { get; set; }
        public string ImageName { get; set; }
        public int IdMatiere { get; set; }
        public string LibelleMatiere { get; set; }
    }
}
