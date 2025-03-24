using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Models.DataManager;

public class MarqueManager : IDataRepository<Marque, Marque>
{
        private readonly UpwayDBContext? upwayDbContext;
        
        public MarqueManager(){}

        public MarqueManager(UpwayDBContext? context)
        {
                upwayDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Marque>>> GetAllAsync()
        {
                var marques = upwayDbContext.Marques.ToList();
                return marques;
        }

        public async Task<ActionResult<Marque>> GetByIdAsync(int id)
        {
                var marque = upwayDbContext.Marques.FirstOrDefault(u => u.IdMarque == id);
                return marque;
        }

        public async Task AddAsync(Marque entity)
        {
                await upwayDbContext.Marques.AddAsync(entity);
                await upwayDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Marque entityToUpdate, Marque entity)
        {
                upwayDbContext.Entry(entityToUpdate).State = EntityState.Modified;

                entityToUpdate.IdMarque = entity.IdMarque;
                entityToUpdate.NomMarque = entity.NomMarque;

                await upwayDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Marque marque)
        {
                upwayDbContext.Marques.Remove(marque);
                await upwayDbContext.SaveChangesAsync();
        } 
}