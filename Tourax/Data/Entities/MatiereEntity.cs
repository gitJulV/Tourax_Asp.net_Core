using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tourax.Data.Entities
{
    public class MatiereEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdMatiere { get; set; }

        [MaxLength(50)]
        public string LibelleMatiere { get; set; }
        public ICollection<BobineEntity> Bobines { get; set; }
    }
}