using SAE_G2_Upway_API.Models.EntityFramework;
using System.Collections;
using System.Collections.Generic;

namespace SAE_G2_Upway_API.Controllers.DTO.DtoGet;

public class AccessoireDtoGet
{
    public int IdAccessoire { get; set; }
    public string Nom { get; set; }
    public double Prix { get; set; }
    public string Url { get; set; }
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
    public AccessoireDtoGet(Accessoire accessoire)
    {
        Nom = accessoire.Produit.NomProduit;
        Prix = accessoire.Produit.PrixProduit;
        Url = accessoire.Produit.Photo.Url;
        Marque = accessoire.Produit.Marque.NomMarque;
        Categorie = accessoire.CategorieAccessoire.NomCatA;
        DateAccessoire = accessoire.DateAccessoire;
    } 

    public AccessoireDtoGet(){}

    protected bool Equals(AccessoireDtoGet other)
    {
        return Nom == other.Nom && Prix.Equals(other.Prix) && Url == other.Url && Marque == other.Marque && Categorie == other.Categorie && DateAccessoire.Equals(other.DateAccessoire);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((AccessoireDtoGet)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Nom, Prix, Url, Marque, Categorie, DateAccessoire);
    }

    public AccessoireDtoGet(int idAccessoire, string nom, double prix, string url, string marque, string categorie, DateTime dateAccessoire)
    {
        IdAccessoire = idAccessoire;
        Nom = nom;
        Prix = prix;
        Url = url;
        Marque = marque;
        Categorie = categorie;
        DateAccessoire = dateAccessoire;
    }
}  