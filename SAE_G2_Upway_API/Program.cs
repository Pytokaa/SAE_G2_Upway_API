using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<UpwayDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UpwayDBContext")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});


builder.Services.AddScoped<IDataRepository<Velo>, VeloManager>();
builder.Services.AddScoped<IDataRepository<Accessoire>, AccessoireManager>();
builder.Services.AddScoped<IDataRepository<Client>, ClientManager>();
builder.Services.AddScoped<IDataRepository<Produit>, ProduitManager>();

var app = builder.Build();

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
