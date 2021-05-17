using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tourax.Data.Entities
{
    public class BobineEntity
    {
        [Key]
        public int IdBobine { get; set; }

        [MaxLength(50)]
        public string Reference { get; set; }

        [MaxLength(50)]
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

        [MaxLength(150)]
        public string ImageName { get; set; }

        public int IdMatiere { get; set; }

        [ForeignKey("IdMatiere")]
        public MatiereEntity Matiere { get; set; }

    }
}
