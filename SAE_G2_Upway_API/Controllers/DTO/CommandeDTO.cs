using SAE_G2_Upway_API.Models.EntityFramework;

namespace SAE_G2_Upway_API.Controllers.DTO;

public class CommandeDTO
{
    public DateTime DateCommande { get; set; }
    public int? IdCode { get; set; }
    public int IdStatut { get; set; }
    public int IdModeExp { get; set; }
    public int IdAdresse { get; set; }
    public int? IdBoutique { get; set; }
    public int? IdAdresseFactu { get; set; }
    public int IdModePayement { get; set; }
    public int IdClient { get; set; }

    public CommandeDTO(Commande commande)
    {
        DateCommande = commande.DateCommande;
        IdCode = commande.IdCode;
        IdStatut = commande.IdStatut;
        IdModeExp = commande.IdModeExp;
        IdAdresse = commande.IdAdresse;
        IdBoutique = commande.IdBoutique;
        IdAdresseFactu = commande.IdAdresseFactu;
        IdModePayement = commande.IdModePayement;
        IdClient = commande.IdClient;
    }
    
}