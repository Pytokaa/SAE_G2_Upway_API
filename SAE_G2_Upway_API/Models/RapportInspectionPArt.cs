namespace SAE_G2_Upway_API.Models.EntityFramework
{
    public partial class RapportInspection
    {
        public RapportInspection() { }

        public RapportInspection(int id) 
        {
            IdRapport = id;
            IdVelo = id;
            Date = DateTime.Parse("2005-06-01");
            Centre = "Angers";
            Historique = "Accidenté";
            Commentaire = "A pris un platane";

        }

        public RapportInspection(int idRapport, int idVelo, DateTime date, string centre, string historique, string commentaire) 
        {
            IdRapport = idRapport;
            IdVelo = idVelo;
            Date = date;
            Centre = centre;
            Historique = historique;
            Commentaire = commentaire;
        }
    }
}
