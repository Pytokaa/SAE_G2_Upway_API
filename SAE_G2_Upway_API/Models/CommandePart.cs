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

        public override bool Equals(object? obj)
        {
            return obj is Commande commande &&
                   IdCommande == commande.IdCommande &&
                   DateCommande == commande.DateCommande &&
                   IdCode == commande.IdCode &&
                   IdStatut == commande.IdStatut &&
                   IdModeExp == commande.IdModeExp &&
                   IdAdresse == commande.IdAdresse &&
                   IdBoutique == commande.IdBoutique &&
                   IdAdresseFactu == commande.IdAdresseFactu &&
                   IdModePayement == commande.IdModePayement &&
                   IdClient == commande.IdClient;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(IdCommande);
            hash.Add(DateCommande);
            hash.Add(IdCode);
            hash.Add(IdStatut);
            hash.Add(IdModeExp);
            hash.Add(IdAdresse);
            hash.Add(IdBoutique);
            hash.Add(IdAdresseFactu);
            hash.Add(IdModePayement);
            hash.Add(IdClient);
            hash.Add(Code);
            hash.Add(Statut);
            hash.Add(ModeExpedition);
            hash.Add(Adresse);
            hash.Add(Boutique);
            hash.Add(AdresseFactu);
            hash.Add(ModePayement);
            hash.Add(Client);
            hash.Add(AssurancesPropose);
            hash.Add(LesSimilaires);
            hash.Add(LesAccessoires);
            hash.Add(PanierVelo);
            return hash.ToHashCode();
        }
    }
}
