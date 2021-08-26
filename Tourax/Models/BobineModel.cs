using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tourax.Models
{
    public class BobineModel
    {
        public int IdBobine { get; set; }

        [DisplayName("Référence")]
        [StringLength(50, ErrorMessage = "La saisie doit être comprise entre 3 et 50 caractères", MinimumLength = 3)]
        [Required(ErrorMessage = "Le champ référence est requis")]
        public string Reference { get; set; }

        [Required(ErrorMessage = "Le champ nom est requis")]
        [StringLength(50, ErrorMessage = "La saisie doit être comprise entre 3 et 50 caractères", MinimumLength = 3)]
        public string Nom { get; set; }

        [DisplayName("Largeur extérieur")]
        [Required(ErrorMessage = "Le champ largeur extérieur est requis")]
        [Range(1, Double.MaxValue , ErrorMessage = "Le nombre saisie doit être supérieur à 1")]
        public double LargeurExt { get; set; }

        [DisplayName("Largeur intérieur")]
        [Required(ErrorMessage = "Le champ largeur intérieur est requis")]
        [Range(1, Double.MaxValue, ErrorMessage = "Le nombre saisie doit être supérieur à 1")]
        public double LargeurInt { get; set; }

        [DisplayName("Diamètre extérieur")]
        [Required(ErrorMessage = "Le champ diamètre extérieur est requis")]
        [Range(1, Double.MaxValue, ErrorMessage = "Le nombre saisie doit être supérieur à 1")]
        public double DiametreExt { get; set; }

        [DisplayName("Diamètre intérieur")]
        [Required(ErrorMessage = "Le champ diamètre interieur est requis")]
        [Range(1, Double.MaxValue, ErrorMessage = "Le nombre saisie doit être supérieur à 1")]
        public double DiametreInt { get; set; }

        [Required(ErrorMessage = "Le champ moyeu est requis")]
        [Range(1, Double.MaxValue, ErrorMessage = "Le nombre saisie doit être supérieur à 1")]
        public double Moyeu { get; set; }

        [DisplayName("Poids à vide")]
        [Required(ErrorMessage = "Le champ poids à vide est requis")]
        [Range(1, Double.MaxValue, ErrorMessage = "Le nombre saisie doit être supérieur à 1")]
        public double PoidsAVide { get; set; }

        [DisplayName("Poids maximum autorisé")]
        [Required(ErrorMessage = "Le champ poids maximum autorisé est requis")]
        [Range(1, Double.MaxValue, ErrorMessage = "Le nombre saisie doit être supérieur à 1")]
        public double PoidsMaxAutorise { get; set; }
        public bool Trancanage { get; set; }
        public bool Enroulement { get; set; }
        public bool Consigne { get; set; }
        public string ImageName { get; set; }

        [DisplayName("Matière")]
        public int IdMatiere { get; set; }
        public string LibelleMatiere { get; set; }
    }
}
