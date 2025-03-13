using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("t_j_peutetreteste_petest")]
    public partial class Peut_Etre_Teste
    {
        [Key]
        [Column("petest_id")]
        public int IdTest { get; set; }
        [Column("vel_id")]
        public int IdVelo { get; set; }
        [Column("btq_id")]
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
