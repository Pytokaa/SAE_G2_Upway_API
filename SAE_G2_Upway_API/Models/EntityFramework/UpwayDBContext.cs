using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SAE_G2_Upway_API.Models.EntityFramework
{
    public partial class UpwayDBContext : DbContext
    {
        public UpwayDBContext() { }

        public UpwayDBContext(DbContextOptions<UpwayDBContext> options)
            : base(options) { }

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

            // Configuration des tables
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

            // Configuration des autres tables restantes
            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasKey(e => e.IdCommande).HasName("PK_Commande");
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Commande_Client");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => e.Idproduit).HasName("PK_Produit");
                entity.HasOne(d => d.Marque)
                    .WithMany(p => p.Produits)
                    .HasForeignKey(d => d.IdMarque)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Produit_Marque");
            });

            modelBuilder.Entity<Velo>(entity =>
            {
                entity.HasKey(e => e.Idvelo).HasName("PK_Velo");
                entity.HasOne(d => d.Produit)
                    .WithOne(p => p.Velos)
                    .HasForeignKey<Velo>(d => d.ProduitId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Velo_Produit");
            });

            modelBuilder.Entity<Alerte>(entity =>
            {
                entity.HasKey(e => e.IdAlerte).HasName("PK_Alerte");
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Alertes)
                    .HasForeignKey(d => d.Idclient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Alerte_Client");
                entity.HasOne(d => d.Taille)
                    .WithMany()
                    .HasForeignKey(d => d.IdTaille)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Alerte_Taille");
            });

            modelBuilder.Entity<Assurance>(entity =>
            {
                entity.HasKey(e => e.IdAssurance).HasName("PK_Assurance");
                entity.Property(e => e.NomAssurance)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Boutique>(entity =>
            {
                entity.HasKey(e => e.IdBoutique).HasName("PK_Boutique");
                entity.HasOne(d => d.Adresse)
                    .WithMany()
                    .HasForeignKey(d => d.IdAdresse)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Boutique_Adresse");
            });

            modelBuilder.Entity<Caracteristique>(entity =>
            {
                entity.HasKey(e => e.IdCaract).HasName("PK_Caracteristique");
                entity.Property(e => e.Typecaract)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CategorieAccessoire>(entity =>
            {
                entity.HasKey(e => e.IdCatA).HasName("PK_CategorieAccessoire");
                entity.Property(e => e.NomCatA)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<CategorieVelo>(entity =>
            {
                entity.HasKey(e => e.IdCat).HasName("PK_CategorieVelo");
                entity.Property(e => e.NomCategorie)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<CodeReduc>(entity =>
            {
                entity.HasKey(e => e.Idcode).HasName("PK_CodeReduc");
                entity.Property(e => e.Libellecode)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Etat>(entity =>
            {
                entity.HasKey(e => e.IdEtat).HasName("PK_Etat");
                entity.Property(e => e.NomEtat)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Fonction>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Fonction");
                entity.Property(e => e.NomFonction)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Marque>(entity =>
            {
                entity.HasKey(e => e.IdMarque).HasName("PK_Marque");
                entity.Property(e => e.NomMarque)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<ModeExpedition>(entity =>
            {
                entity.HasKey(e => e.IdModeExp).HasName("PK_ModeExpedition");
                entity.Property(e => e.LibellemodeExp)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<ModePayement>(entity =>
            {
                entity.HasKey(e => e.Idmodepayement).HasName("PK_ModePayement");
                entity.Property(e => e.NomModepayement)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Moteur>(entity =>
            {
                entity.HasKey(e => e.IdMoteur).HasName("PK_Moteur");
                entity.Property(e => e.Positionmoteur)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Pays>(entity =>
            {
                entity.HasKey(e => e.IdPays).HasName("PK_Pays");
                entity.Property(e => e.NomPays)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasKey(e => e.IdPhoto).HasName("PK_Photo");
                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(300);
                entity.Property(e => e.Description)
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Statut>(entity =>
            {
                entity.HasKey(e => e.IdStatut).HasName("PK_Statut");
                entity.Property(e => e.NomStatut)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Taille>(entity =>
            {
                entity.HasKey(e => e.Idtaille).HasName("PK_Taille");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.Idtype).HasName("PK_Type");
                entity.Property(e => e.NomType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
