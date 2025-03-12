using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("peutetreteste")]
    public partial class Peut_Etre_Teste
    {
        [Key]
        [Column("idtest")]
        public int IdTest { get; set; }
        [Column("idvelo")]
        public int IdVelo { get; set; }
        [Column("idboutique")]
        public int IdBoutique { get; set; }

        //relation avec la table boutique

        [ForeignKey(nameof(IdBoutique))]
        [InverseProperty(nameof(Boutique.LesVelos))]
        public virtual Boutique LaBoutique { get; set; } = null!;

        //relation avec la table velo
        [ForeignKey(nameof(IdVelo))]
        [InverseProperty(nameof(Velo.LesBoutiques))]
        public virtual Velo LeVelo { get; set; } = null!;
    }
}
