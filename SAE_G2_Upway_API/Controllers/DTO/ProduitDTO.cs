namespace SAE_G2_Upway_API.Controllers.DTO;


public class ProduitDTO
{
    public int  IdProduit { get; set; }
    public int  IdMarque { get; set; }
    public int  IdPhoto { get; set; }
    public string NomProduit { get; set; }
    public double PrixProduit { get; set; }
    public string DescriptionProduit { get; set; }
}