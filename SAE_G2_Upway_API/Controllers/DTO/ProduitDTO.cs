namespace SAE_G2_Upway_API.Controllers.DTO;


public class ProduitDTO
{
    public int  IdMarque { get; set; }
    public int  IdPhoto { get; set; }
    public string NomProduit { get; set; }
    public double PrixProduit { get; set; }
    public int StockProduit { get; set; }
    public string DescriptionProduit { get; set; }
}