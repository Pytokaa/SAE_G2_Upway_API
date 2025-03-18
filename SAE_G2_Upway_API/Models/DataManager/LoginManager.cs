using Microsoft.AspNetCore.Mvc;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Models.DataManager
{
    public class LoginManager : IDataRepository<Client>
    {
        private readonly UpwayDBContext? upwayDbContext;

        public LoginManager() { }

        public LoginManager(UpwayDBContext? context) 
        {
            upwayDbContext = context;
        }

        public ActionResult<IEnumerable<Client>> GetAll()
        {
            return upwayDbContext.Clients.ToList();
        }

        public async Task<ActionResult<Client>> GetByIdAsync(int id)
        {
            
        }
    }
}
