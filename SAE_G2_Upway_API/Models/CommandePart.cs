using SAE_G2_Upway_API.Controllers.DTO;
using System.Net.NetworkInformation;
using System.Reflection.Emit;

namespace SAE_G2_Upway_API.Models.EntityFramework
{
    public partial class Commande
    {
        public Commande() { }
        public Commande(int idCommande, DateTime dateCommande, int idCode, int idStatut, int idModeExp, int idAdresse, int idBoutique, int idAdressFactu, int idModePaiement, int idClient)
        {
            IdCommande = idCommande;
            DateCommande = dateCommande;
            IdCode = idCode;
            IdStatut = idStatut;
            IdModeExp = idModeExp;
            IdAdresse = idAdresse;
            IdBoutique = idBoutique;
            IdAdresseFactu = idAdressFactu;
            IdModePayement = idModePaiement;
            IdClient = idClient;
        }

        public Commande(int test) 
        {
            IdCommande = test;
            DateCommande = DateTime.Parse("08-11-2000");
            IdCode = test;
            IdStatut = test;
            IdModeExp = test;
            IdAdresse = test;
            IdBoutique = test;
            IdAdresseFactu = test;
            IdModePayement = test;
            IdClient = test;
        }

        public Commande(CommandeDTO commandeDto)
        {
            DateCommande = commandeDto.DateCommande;
            IdCode = commandeDto.IdCode;
            IdStatut = commandeDto.IdStatut;
            IdModeExp = commandeDto.IdModeExp;
            IdAdresse = commandeDto.IdAdresse;
            IdBoutique = commandeDto.IdBoutique;
            IdAdresseFactu = commandeDto.IdAdresseFactu;
            IdModePayement = commandeDto.IdModePayement;
            IdClient = commandeDto.IdClient;
        }

    }
}
