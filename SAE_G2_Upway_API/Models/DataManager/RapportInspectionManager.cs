using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;


namespace SAE_G2_Upway_API.Models.DataManager;

public class RapportInspectionManager //    : IDataRepository<RapportInspection, RapportInspection>
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
        var rapport = upwayDbContext.RapportInspections.FirstOrDefault(u => u.IdRapport == id);
        return rapport;
    }

    public async Task AddAsync(RapportInspection entity)
    {
        await upwayDbContext.RapportInspections.AddAsync(entity);
        await upwayDbContext.SaveChangesAsync();
    }
}