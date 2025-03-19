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
    public DateTime Annee { get; set; }
    public bool BestSeller { get; set; }
    public int NbVente { get; set; }
    public string QualiteVelo { get; set; }
}