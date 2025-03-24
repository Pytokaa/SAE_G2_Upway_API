namespace SAE_G2_Upway_API.Controllers.DTO;

public class AccessoireDTO
{
    public int IdProduit { get; set; }
    public int IdCatA { get; set; }
    public DateTime DateAccessoire { get; set; }

    public AccessoireDTO(int idProduit, int idCatA, DateTime dateAccessoire)
    {
        IdProduit = idProduit;
        IdCatA = idCatA;
        DateAccessoire = dateAccessoire;
    }
}