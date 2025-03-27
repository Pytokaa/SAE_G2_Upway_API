using Microsoft.EntityFrameworkCore;
using Moq;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_APITests.Controllers;

[TestClass]
public class ProduitsControllerDbTests
{

     private UpwayDBContext dbContext;
        private ProduitsController produitController;
        private IDataRepository<Produit, Produit> dataRepository;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=localhost;port=5432;Database=SAE_G2_Upway; uid=postgres; password=postgres;");
            dbContext = new UpwayDBContext(builder.Options);
            dataRepository = new ProduitManager(dbContext);
            produitController = new ProduitsController(dataRepository);
            
        }

        [TestMethod()]
        public void ProduitsControllerTest()
        {
            var produitsMock = new List<Produit>
            {
                new Produit(1, 1, 1, "Produit A", 100, 10, "Description A"),
                new Produit(2, 2, 2, "Produit B", 200, 20, "Description B")
            };

            // 2. Création du mock du repository
            var mockRepository = new Mock<IDataRepository<Produit, Produit>>();
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(produitsMock);

            // 3. Création du contrôleur avec le mock
            var produitController = new ProduitsController(mockRepository.Object);

            // 4. Exécution de la méthode
            var result = produitController.GetProduits().Result;

            // 5. Vérifications
            Assert.IsNotNull(result.Value, "La liste des produits ne doit pas être null");
            Assert.AreEqual(2, result.Value.Count(), "Le nombre de produits est incorrect");
            CollectionAssert.AreEquivalent(produitsMock, result.Value.ToList(), "Les produits ne correspondent pas.");
        }

        [TestMethod]
        public void GetProduits_ReturnsAllProduits()
        {
            var result = produitController.GetProduits().Result;
 
            List<Produit> resultList = new List<Produit>();
 
            foreach (var item in result.Value)
            {
                Produit produit = new Produit(
                    item.Idproduit,
                    item.IdPhoto,
                    item.IdMarque,
                    item.NomProduit,
                    item.PrixProduit,
                    item.StockProduit,
                    item.DescriptionProduit
                );
                resultList.Add(produit);
            }
 
            List<Produit> produitsBase = dbContext.Produits.ToList();
 
            CollectionAssert.AreEqual(produitsBase, resultList, "Get all produits ne fonctionne pas correctement");
         }
        [TestCleanup]
        public void Cleanup()
        {
            dbContext = null;
            dataRepository = null;
            produitController = null;
        }
}