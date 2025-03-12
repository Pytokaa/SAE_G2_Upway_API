using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("possede")]
    public partial class Possede
    {
        [Key]
        [Column("idpossede", TypeName = "integer")]
        public int IdPossede { get; set; }
        [Column("idsouscat")]
        public int IdSousCat { get; set; }
        [Column("idvelo")]
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
