using Microsoft.EntityFrameworkCore.Metadata;
using SAE_G2_Upway_API.Controllers.DTO;
using System;

namespace SAE_G2_Upway_API.Models.EntityFramework;

public partial class Velo
{
    public override bool Equals(object? obj)
    {
        return obj is Velo velo &&
                IdVelo == velo.IdVelo &&
                IdProduit == velo.IdProduit &&
                IdTailleMin == velo.IdTailleMin &&
                IdTailleMax == velo.IdTailleMax &&
                IdModele == velo.IdModele &&
                IdCat == velo.IdCat &&
                IdEtat == velo.IdEtat &&
                Nbkms == velo.Nbkms &&
                Prixneuf == velo.Prixneuf &&
                Poids == velo.Poids &&
                Typecadre == velo.Typecadre &&
                Annee == velo.Annee &&
                BestSeller == velo.BestSeller &&
                NbVente == velo.NbVente &&
                QualiteVelo == velo.QualiteVelo;
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(IdVelo);
        hash.Add(IdProduit);
        hash.Add(IdTailleMin);
        hash.Add(IdTailleMax);
        hash.Add(IdModele);
        hash.Add(IdCat);
        hash.Add(IdEtat);
        hash.Add(Nbkms);
        hash.Add(Prixneuf);
        hash.Add(Poids);
        hash.Add(Typecadre);
        hash.Add(Annee);
        hash.Add(BestSeller);
        hash.Add(NbVente);
        hash.Add(QualiteVelo);
        return hash.ToHashCode();
    }

    public Velo(int idVelo, int idProduit, int idTailleMin, int idTailleMax, int idModele, int idCat, int idEtat,
                double nbkms, double prixneuf, double poids, string typecadre, int annee, bool bestSeller, int nbVente, string qualiteVelo)
    {
        IdVelo = idVelo;
        IdProduit = idProduit;
        IdTailleMin = idTailleMin;
        IdTailleMax = idTailleMax;
        IdModele = idModele;
        IdCat = idCat;
        IdEtat = idEtat;
        Nbkms = nbkms;
        Prixneuf = prixneuf;
        Poids = poids;
        Typecadre = typecadre;
        Annee = annee;
        BestSeller = bestSeller;
        NbVente = nbVente;
        QualiteVelo = qualiteVelo;
    }
    public Velo(int num)
    {
        IdVelo = num;
        IdProduit = num;
        IdTailleMin = num;
        IdTailleMax = num;
        IdModele = num;
        IdCat = num;
        IdEtat = num;
        Nbkms = num;
        Prixneuf = num;
        Poids = num;
        Typecadre = "Droit";
        Annee = 2018;
        BestSeller = true;
        NbVente = num;
        QualiteVelo = "Fiable";
    }

    public Velo(VeloDTO veloDTO)
    {
        IdProduit = veloDTO.IdProduit;
        IdTailleMin = veloDTO.IdTailleMin;
        IdTailleMax = veloDTO.IdTailleMax;
        IdModele = veloDTO.IdModele;
        IdCat = veloDTO.IdCat;
        IdEtat = veloDTO.IdEtat;
        Nbkms = veloDTO.Nbkms;
        Prixneuf = veloDTO.PrixNeuf;
        Poids = veloDTO.Poids;
        Typecadre = veloDTO.TypeCadre;
        Annee = veloDTO.Annee;
        BestSeller = veloDTO.BestSeller;
        NbVente = veloDTO.NbVente;
        QualiteVelo = veloDTO.QualiteVelo;
    }
    public Velo() { }
}