using Microsoft.Build.Framework;

namespace SAE_G2_Upway_API.Controllers.DTO;


public class ProduitDTO
{
    [Required]
    public int  IdMarque { get; set; }
    [Required]
    public int  IdPhoto { get; set; }
    [Required]
    public string NomProduit { get; set; }
    [Required]
    public double PrixProduit { get; set; }
    [Required]
    public int StockProduit { get; set; }
    public string DescriptionProduit { get; set; }

    public ProduitDTO(int idMarque, int idPhoto, string nomProduit, double prixProduit, int stockProduit, string descriptionProduit)
    {
        IdMarque = idMarque;
        IdPhoto = idPhoto;
        NomProduit = nomProduit;
        PrixProduit = prixProduit;
        StockProduit = stockProduit;
        DescriptionProduit = descriptionProduit;
    }

    public ProduitDTO()
    {
    }
}