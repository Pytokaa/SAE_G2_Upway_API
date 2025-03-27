using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;
using SAE_G2_Upway_API.Controllers.DTO.DtoGet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<UpwayDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ServerDBContext")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});


builder.Services.AddScoped<IDataRepository<Velo, VeloDtoGet>, VeloManager>();
builder.Services.AddScoped<IDataRepository<CategorieVelo, CategorieVelo>, CategorieVeloManager>();
builder.Services.AddScoped<IDataRepository<CategorieAccessoire, CategorieAccessoire>, CategorieAccessoireManager>();
builder.Services.AddScoped<IDataRepository<Accessoire, AccessoireDtoGet>, AccessoireManager>();
builder.Services.AddScoped<IDataRepository<Client, Client>, ClientManager>();
builder.Services.AddScoped<IDataRepository<Marque, Marque>, MarqueManager>();
builder.Services.AddScoped<IDataRepository<Produit, Produit>, ProduitManager>();
builder.Services.AddScoped<ICommandeRepository, CommandeManager>();
builder.Services.AddScoped<IDataRepository<RapportInspection, RapportInspection>, RapportInspectionManager>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.WithOrigins("*")    
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
/*builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://51.83.36.122:5181",
                "saeupwayapi-egdpataudtctggay.francecentral-01.azurewebsites.net")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});*/

var app = builder.Build();

app.UseCors(policy =>
    policy.WithOrigins("https://saeupwayapi-egdpataudtctggay.francecentral-01.azurewebsites.net")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
);
//app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
