using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;


namespace SAE_G2_Upway_API.Models.DataManager;

public class RapportInspectionManager     : IDataRepository<RapportInspection, RapportInspection>
{
    private readonly UpwayDBContext? upwayDbContext;
        
    public RapportInspectionManager(){}

    public RapportInspectionManager(UpwayDBContext? context)
    {
        upwayDbContext = context;
    }

    public async Task<ActionResult<IEnumerable<RapportInspection>>> GetAllAsync()
    {
        var rapports = upwayDbContext.RapportInspections.ToList();
        return rapports;
    }

    public async Task<ActionResult<RapportInspection>> GetByIdAsync(int id)
    {
        var rapport = upwayDbContext.RapportInspections
            .Include(ri => ri.LesTypes)
            .ThenInclude(v => v.LeType)
            .ThenInclude(t =>t.ASousTypes)
            .ThenInclude(c => c.ContientSousType)
            .ThenInclude(st => st.LesSurTypes)
            .ThenInclude(sr => sr.Repare)
            .FirstOrDefault(u => u.IdVelo == id);

        foreach (var valide in rapport.LesTypes)
        {
            foreach (var contient in valide.LeType.ASousTypes)
            {
                
                contient.ContientSousType.LesSurTypes = new List<SurType>{contient.ContientSousType.LesSurTypes.FirstOrDefault()};
            }
        }
        
        
        return rapport;
    }

    public async Task AddAsync(RapportInspection entity)
    {
        await upwayDbContext.RapportInspections.AddAsync(entity);
        await upwayDbContext.SaveChangesAsync();
    }

    
    public async Task UpdateAsync(RapportInspection entityToUpdate, RapportInspection entity)
    {
        upwayDbContext.Entry(entityToUpdate).State = EntityState.Modified;
        entityToUpdate.IdRapport = entity.IdRapport;
        entityToUpdate.IdVelo = entity.IdVelo;
        entityToUpdate.Date = entity.Date;
        entityToUpdate.Centre = entity.Centre;
        entityToUpdate.Historique = entity.Historique;
        entityToUpdate.Commentaire = entity.Commentaire;
        await upwayDbContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(RapportInspection rapport)
    {
        upwayDbContext.RapportInspections.Remove(rapport);
        await upwayDbContext.SaveChangesAsync();
    } 
}