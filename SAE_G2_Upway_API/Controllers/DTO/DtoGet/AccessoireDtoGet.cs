namespace SAE_G2_Upway_API.Controllers.DTO.DtoGet;

public class AccessoireDtoGet
{
    public string Nom { get; set; }
    public double Prix { get; set; }
    public string Url { get; set;  }
    public string Marque { get; set; }
    public string Categorie { get; set; }
    public DateTime DateAccessoire { get; set; }

    public AccessoireDtoGet(string nom, double prix, string url, string marque, string categorie, DateTime dateAccessoire)
    {
        Nom = nom;
        Prix = prix;
        Url = url;
        Marque = marque;
        Categorie = categorie;
        DateAccessoire = dateAccessoire;
    }
}