using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("t_j_possede_poss")]
    public partial class Possede
    {
        [Key]
        [Column("poss_id")]
        public int IdPossede { get; set; }
        [Column("scat_id")]
        public int IdSousCat { get; set; }
        [Column("vel_id")]
        public int IdVelo { get; set; }

        //Relation Sous categorie

        [ForeignKey(nameof(IdSousCat))]
        [InverseProperty(nameof(SousCategorie.LesVelos))]
        public virtual SousCategorie LaSousCategorie { get; set; } = null!;

        //Relation Velo
        [ForeignKey(nameof(IdVelo))]
        [InverseProperty(nameof(Velo.LesSousCategories))]
        public virtual Velo LeVelo { get; set; } = null!;
    }
}
