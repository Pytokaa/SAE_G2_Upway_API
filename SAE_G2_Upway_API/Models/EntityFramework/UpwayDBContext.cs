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
                // Définir la clé primaire
                entity.HasKey(e => e.IdAccessoire).HasName("PK_Accessoire");

                // Configuration de la relation avec la table Produit
                entity.HasOne(d => d.Produit)
                    .WithOne(p => p.Accessoires)
                    .HasForeignKey<Accessoire>(d => d.ProduitId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Accessoire_Produit");

                // Configuration de la relation avec la table CategorieAccessoire
                entity.HasOne(d => d.CategorieAccessoire)
                    .WithMany(c => c.Accessoires)
                    .HasForeignKey(d => d.CategorieAccessoireId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Accessoire_CategorieAccessoire");
            });

            modelBuilder.Entity<Adresse>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdAdresse).HasName("PK_Adresse");

                // Configuration de la relation avec la table Pays
                entity.HasOne(d => d.Pays)
                    .WithMany(p => p.Adresses)
                    .HasForeignKey(d => d.PaysId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Adresse_Pays");

                // Configuration de la relation avec la table Boutique (relation 1 à 0..1)
                entity.HasOne(d => d.Boutique)
                    .WithOne(b => b.Adresse)
                    .HasForeignKey<Boutique>(b => b.IdAdresse)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Adresse_Boutique");

                // Configuration de la relation avec la table Commande
                entity.HasMany(d => d.Commandes)
                    .WithOne(c => c.Adresse)
                    .HasForeignKey(c => c.IdAdresse)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Adresse_Commandes");

                // Configuration de la relation avec la table Commande (adresse de facturation)
                entity.HasMany(d => d.CommandesFactu)
                    .WithOne(c => c.AdresseFactu)
                    .HasForeignKey(c => c.IdAdresseFactu)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Adresse_Commandes_Facturation");

                // Configuration des colonnes
                //entity.Property(e => e.Rue)
                //    .HasColumnName("rue")
                //    .HasMaxLength(100)
                //    .IsRequired();

                //entity.Property(e => e.Cp)
                //    .HasColumnName("cp")
                //    .IsRequired();

                //entity.Property(e => e.Ville)
                //    .HasColumnName("ville")
                //    .HasMaxLength(50)
                //    .IsRequired();
            });

            modelBuilder.Entity<Client>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.Idclient).HasName("PK_Client");

                // Configuration de la relation avec la table Fonction
                entity.HasOne(d => d.Fonction)
                    .WithMany(f => f.Clients)
                    .HasForeignKey(d => d.IdFonction)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Client_Fonction");

                // Configuration de la contrainte de validation pour le format de l'email
                entity.HasCheckConstraint("chk_mailclient_format", "mailclient ~* '^[A-Za-z0-9._%-+]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,3}$'");

                // Configuration de la relation avec la table Alerte
                entity.HasMany(d => d.Alertes)
                    .WithOne(a => a.Client)
                    .HasForeignKey(a => a.Idclient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Client_Alerte");

                // Configuration de la relation avec la table Commande
                entity.HasMany(d => d.Commandes)
                    .WithOne(c => c.Client)
                    .HasForeignKey(c => c.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Client_Commande");

                // Configuration de la relation avec la table Est_En_Favoris
                entity.HasMany(d => d.LesFavoris)
                    .WithOne(f => f.ClientFavoris)
                    .HasForeignKey(f => f.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Client_Est_En_Favoris");

                // Configuration des colonnes
                //entity.Property(e => e.Mailclient)
                //    .IsRequired()
                //    .HasMaxLength(50);

                //entity.Property(e => e.Nomclient)
                //    .HasColumnName("nomclient")
                //    .HasMaxLength(30)
                //    .IsRequired();

                //entity.Property(e => e.Prenomclient)
                //    .HasColumnName("prenomclient")
                //    .HasMaxLength(30)
                //    .IsRequired();

                //entity.Property(e => e.Telephone)
                //    .HasColumnName("telephone")
                //    .HasMaxLength(12)
                //    .IsRequired();

                //entity.Property(e => e.Password)
                //    .HasColumnName("password")
                //    .HasMaxLength(100)
                //    .IsRequired();
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasKey(e => e.IdCommande).HasName("PK_Commande");
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Commande_Client");
                entity.HasOne(d => d.Code)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Commande_Code");
                entity.HasOne(d => d.Statut)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdStatut)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Commande_Statut");
                entity.HasOne(d => d.ModeExpedition)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdModeExp)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Commande_ModeExp");
                entity.HasOne(d => d.Adresse)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdAdresse)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Commande_Adresse");
                entity.HasOne(d => d.AdresseFactu)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdAdresseFactu)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Commande_AdresseFactu");
                entity.HasOne(d => d.ModePayement)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdModePayement)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Commande_ModePayement");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(p => p.Idproduit);
                entity.Property(p => p.Nomproduit).HasMaxLength(100);
                entity.Property(p => p.Descriptionproduit).HasMaxLength(200);

                // Relation avec la table Photo
                entity.HasOne(p => p.Photo)
                      .WithMany()
                      .HasForeignKey(p => p.IdPhoto)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relation avec la table Marque
                entity.HasOne(p => p.Marque)
                      .WithMany()
                      .HasForeignKey(p => p.IdMarque)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relation avec la table Est_En_Favoris
                entity.HasMany(p => p.DansLesFavoris)
                      .WithOne(f => f.LesProduits)
                      .HasForeignKey(f => f.IdProduit)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Velo>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.Idvelo).HasName("PK_Velo");

                // Configuration de la relation avec la table Produit
                entity.HasOne(d => d.Produit)
                    .WithOne(p => p.Velos)
                    .HasForeignKey<Velo>(d => d.ProduitId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Velo_Produit");

                // Configuration de la relation avec la table RapportInspection
                entity.HasOne(d => d.RapportInspection)
                    .WithOne(r => r.Velo)
                    .HasForeignKey<RapportInspection>(r => r.IdVelo)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Velo_RapportInspection");

                // Configuration de la relation avec la table Taille (TailleMin)
                entity.HasOne(d => d.TailleMin)
                    .WithMany(t => t.VelosMin)
                    .HasForeignKey(d => d.IdTailleMin)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Velo_TailleMin");

                // Configuration de la relation avec la table Taille (TailleMax)
                entity.HasOne(d => d.TailleMax)
                    .WithMany(t => t.VelosMax)
                    .HasForeignKey(d => d.IdTailleMax)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Velo_TailleMax");

                // Configuration de la relation avec la table Modele
                entity.HasOne(d => d.Modele)
                    .WithMany(m => m.Velos)
                    .HasForeignKey(d => d.IdModele)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Velo_Modele");

                // Configuration de la relation avec la table CategorieVelo
                entity.HasOne(d => d.CategorieVelo)
                    .WithMany(c => c.Velos)
                    .HasForeignKey(d => d.IdCat)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Velo_CategorieVelo");

                // Configuration de la relation avec la table Etat
                entity.HasOne(d => d.Etat)
                    .WithMany(e => e.Velos)
                    .HasForeignKey(d => d.IdEtat)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Velo_Etat");

                // Configuration des colonnes
                //entity.Property(e => e.Nbkms)
                //    .HasColumnName("nbkms")
                //    .IsRequired();

                //entity.Property(e => e.Prixneuf)
                //    .HasColumnName("prixneuf")
                //    .IsRequired();

                //entity.Property(e => e.Poids)
                //    .HasColumnName("poids")
                //    .IsRequired();

                //entity.Property(e => e.Typecadre)
                //    .HasColumnName("typecadre")
                //    .HasMaxLength(50)
                //    .IsRequired();
            });

            modelBuilder.Entity<Alerte>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdAlerte).HasName("PK_Alerte");

                // Configuration de la colonne Email
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                // Configuration de la colonne Budgetmax
                entity.Property(e => e.Budgetmax)
                    .HasColumnName("budgetmax")
                    .IsRequired();

                // Configuration de la relation avec la table Client
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Alertes)
                    .HasForeignKey(d => d.Idclient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Alerte_Client");

                // Configuration de la relation avec la table Taille
                entity.HasOne(d => d.Taille)
                    .WithMany(t => t.Alerte)
                    .HasForeignKey(d => d.IdTaille)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Alerte_Taille");
            });

            modelBuilder.Entity<Assurance>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdAssurance).HasName("PK_Assurance");

                // Configuration de la colonne NomAssurance
                entity.Property(e => e.NomAssurance)
                    .IsRequired()
                    .HasMaxLength(50);

                // Configuration de la colonne PrixAssurance
                entity.Property(e => e.PrixAssurance)
                    .HasColumnType("decimal(5,2)")
                    .IsRequired();
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
