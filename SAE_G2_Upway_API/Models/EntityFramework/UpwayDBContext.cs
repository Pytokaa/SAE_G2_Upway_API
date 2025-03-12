using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SAE_G2_Upway_API.Models.EntityFramework
{
    public partial class UpwayDBContext : DbContext
    {
        public UpwayDBContext()
        {
        }

        public UpwayDBContext(DbContextOptions<UpwayDBContext> options)
            : base(options)
        {
        }

        // Déclaration des DbSet
        public virtual DbSet<Accessoire> Accessoires { get; set; }
        public virtual DbSet<Adresse> Adresses { get; set; }
        public virtual DbSet<Alerte> Alertes { get; set; }
        public virtual DbSet<Assurance> Assurances { get; set; }
        public virtual DbSet<Boutique> Boutiques { get; set; }
        public virtual DbSet<Caracteristique> Caracteristiques { get; set; }
        public virtual DbSet<CategorieAccessoire> CategorieAccessoires { get; set; }
        public virtual DbSet<CategorieVelo> CategorieVelos { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<CodeReduc> CodeReducs { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<Etat> Etats { get; set; }
        public virtual DbSet<Fonction> Fonctions { get; set; }
        public virtual DbSet<Marque> Marques { get; set; }
        public virtual DbSet<ModeExpedition> ModeExpeditions { get; set; }
        public virtual DbSet<Modele> Modeles { get; set; }
        public virtual DbSet<ModePayement> ModePayements { get; set; }
        public virtual DbSet<Moteur> Moteurs { get; set; }
        public virtual DbSet<Pays> Pays { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<RapportInspection> RapportInspections { get; set; }
        public virtual DbSet<SousCategorie> SousCategories { get; set; }
        public virtual DbSet<SousType> SousTypes { get; set; }
        public virtual DbSet<Statut> Statuts { get; set; }
        public virtual DbSet<SurType> SurTypes { get; set; }
        public virtual DbSet<Taille> Tailles { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Velo> Velos { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                 .EnableSensitiveDataLogging()
                 .UseNpgsql("Server=localhost;port=5432;Database=SAE_G2_Upway; uid=postgres; password=postgres;SearchPath=upway");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("upway");

            // Configuration des entités et des relations
            modelBuilder.Entity<Accessoire>(entity =>
            {
                entity.HasKey(e => e.IdAccessoire).HasName("PK_Accessoire");
                entity.HasOne(d => d.Produit)
                    .WithOne(p => p.Accessoires)
                    .HasForeignKey<Accessoire>(d => d.ProduitId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Accessoire_Produit");
                entity.HasOne(d => d.CategorieAccessoire)
                    .WithMany()
                    .HasForeignKey(d => d.CategorieAccessoireId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Accessoire_CategorieAccessoire");
            });

            modelBuilder.Entity<Adresse>(entity =>
            {
                entity.HasKey(e => e.IdAdresse).HasName("PK_Adresse");
                entity.HasOne(d => d.Pays)
                    .WithMany()
                    .HasForeignKey(d => d.PaysId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Adresse_Pays");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Idclient).HasName("PK_Client");
                entity.HasOne(d => d.Fonction)
                    .WithMany()
                    .HasForeignKey(d => d.IdFonction)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Client_Fonction");
                entity.HasCheckConstraint("chk_mailclient_format", "mailclient ~* '^[A-Za-z0-9._%-+]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,3}$'");
                entity.Property(e => e.Mailclient)
                    .IsRequired()
                    .HasMaxLength(50);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
