using SAE_G2_Upway_API.Models.EntityFramework;

namespace SAE_G2_Upway_API.Controllers.DTO;

public class VeloDTO
{
    public int IdProduit { get; set; }
    public int IdTailleMin { get; set; }
    public int IdTailleMax { get; set; }
    public int IdModele { get; set; }
    public int IdCat  { get; set; }
    public int IdEtat { get; set; }
    public double Nbkms { get; set; }
    public double PrixNeuf { get; set; }
    public double Poids { get; set; }
    public string TypeCadre { get; set; }
    public int Annee { get; set; }
    public bool BestSeller { get; set; }
    public int NbVente { get; set; }
    public string QualiteVelo { get; set; }

    public VeloDTO(Velo velo)
    {
        IdProduit = velo.IdProduit;
        IdTailleMin = velo.IdTailleMin;
        IdTailleMax = velo.IdTailleMax;
        IdModele = velo.IdModele;
        IdCat = velo.IdCat;
        IdEtat = velo.IdEtat;
        Nbkms = velo.Nbkms;
        PrixNeuf = velo.Prixneuf;
        Poids = velo.Poids;
        TypeCadre = velo.Typecadre;
        Annee = velo.Annee;
        BestSeller = velo.BestSeller;
        NbVente = velo.NbVente;
        QualiteVelo = velo.QualiteVelo;
    }
}