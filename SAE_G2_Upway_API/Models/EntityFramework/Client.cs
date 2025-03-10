using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("client")]
public partial class Client
{
    [Key]
    [Column("idclient")]
    public int Idclient { get; set; }
    
    [Column("nomclient")]
    [StringLength(30)]
    public string Nomclient { get; set; }
    
    [Column("prenomclient")]
    [StringLength(30)]
    public string Prenomclient { get; set; }
    
    [Column("mailclient")]
    [StringLength(50)]
    public string Mailclient { get; set; }
    
    [Column("telephone")]
    [StringLength(12)]
    public string Telephone { get; set; }
    
    [Column("password")]
    [StringLength(100)]
    public string Password { get; set; }
    
    
    //relation avec la table alerte
    public ICollection<Alerte> Alertes { get; set; } = new List<Alerte>();
    
    
}