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
        public virtual DbSet<A_Pour_Photo> PourPhotos { get; set; }
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
        public virtual DbSet<Concerne> Concerns { get; set; }
        public virtual DbSet<Contient> Contients { get; set; }
        public virtual DbSet<Est_Caracterise> Est_Caracterises { get; set; }
        public virtual DbSet<Est_Compose>Est_Composes { get; set; }
        public virtual DbSet<Est_De_ModeleM>Est_De_ModeleMs { get; set; }
        public virtual DbSet<Est_En_Favoris>Est_En_Favoris { get; set; }
        public virtual DbSet<Est_Mis_Panier_Accessoire>Est_Mis_Panier_Accessoires { get; set; }
        public virtual DbSet<Est_Mis_Panier_Velo>Est_Mis_Panier_Velos { get; set; }
        public virtual DbSet<Est_Propose_Similaire>Est_Propose_Similaires { get; set; }
        public virtual DbSet<Etat> Etats { get; set; }
        public virtual DbSet<Fonction> Fonctions { get; set; }
        public virtual DbSet<Habite>Habites { get; set; }
        public virtual DbSet<Marque> Marques { get; set; }
        public virtual DbSet<ModeExpedition> ModeExpeditions { get; set; }
        public virtual DbSet<Modele> Modeles { get; set; }
        public virtual DbSet<ModePayement> ModePayements { get; set; }
        public virtual DbSet<Moteur> Moteurs { get; set; }
        public virtual DbSet<Pays> Pays { get; set; }
        public virtual DbSet<Peut_Etre_Teste>Peut_Etre_Testes { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Possede>Possedes { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Propose_Assur>Propose_Assurs { get; set; }
        public virtual DbSet<RapportInspection> RapportInspections { get; set; }
        public virtual DbSet<SousCategorie> SousCategories { get; set; }
        public virtual DbSet<SousType> SousTypes { get; set; }
        public virtual DbSet<Statut> Statuts { get; set; }
        public virtual DbSet<SurType> SurTypes { get; set; }
        public virtual DbSet<Taille> Tailles { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Valide> Valides { get; set; }
        public virtual DbSet<Velo> Velos { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging();

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
                    .WithOne(p => p.Accessoire)
                    .HasForeignKey<Accessoire>(d => d.IdProduit)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Accessoire_Produit");

                // Configuration de la relation avec la table CategorieAccessoire
                entity.HasOne(d => d.CategorieAccessoire)
                    .WithMany(c => c.Accessoires)
                    .HasForeignKey(d => d.IdCatA)
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
                entity.HasCheckConstraint("chk_mailclient_format", "clt_mail ~* '^[A-Za-z0-9._%-+]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,3}$'");

                // Configuration de la relation avec la table Alerte
                entity.HasMany(d => d.Alertes)
                    .WithOne(a => a.Client)
                    .HasForeignKey(a => a.IdClient)
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
                    .WithMany(p => p.CommandesFactu)
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
                // Définir la clé primaire
                entity.HasKey(p => p.Idproduit).HasName("PK_Produit");

                // Configuration des colonnes
                entity.Property(p => p.NomProduit)
                    .HasMaxLength(250);

                entity.Property(p => p.DescriptionProduit)
                    .HasMaxLength(200);

                entity.Property(p => p.PrixProduit)
                    .IsRequired();

                entity.Property(p => p.StockProduit)
                    .IsRequired();

                entity.Property(e => e.IdPhoto)
                    .HasColumnName("pto_id")
                    .IsRequired();

                entity.Property(e => e.IdMarque)
                    .HasColumnName("mrq_id")
                    .IsRequired();

                // Configuration de la relation avec la table Photo
                entity.HasOne(p => p.Photo)
                    .WithOne(f => f.Produit)
                    .HasForeignKey<Produit>(p => p.IdPhoto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Produit_Photo");

                // Configuration de la relation avec la table Marque
                entity.HasOne(p => p.Marque)
                    .WithMany(m => m.Produits)
                    .HasForeignKey(p => p.IdMarque)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Produit_Marque");

                // Configuration de la relation avec la table Est_En_Favoris
                entity.HasMany(p => p.DansLesFavoris)
                    .WithOne(f => f.LesProduits)
                    .HasForeignKey(f => f.IdProduit)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Produit_Est_En_Favoris");

                // Configuration de la relation avec la table Accessoire
                entity.HasOne(p => p.Accessoire)
                    .WithOne(a => a.Produit)
                    .HasForeignKey<Accessoire>(a => a.IdProduit)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Produit_Accessoire");

                // Configuration de la relation avec la table Velo
                entity.HasOne(p => p.Velo)
                    .WithOne(v => v.Produit)
                    .HasForeignKey<Velo>(v => v.IdProduit)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Produit_Velo");

                // Configuration de la relation avec la table A_Pour_Photo
                entity.HasMany(p => p.APhotos)
                    .WithOne(a => a.ProduitAPhoto)
                    .HasForeignKey(a => a.IdProduit)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Produit_A_Pour_Photo");
            });

            modelBuilder.Entity<Velo>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdVelo).HasName("PK_Velo");

                // Configuration de la relation avec la table Produit
                entity.HasOne(d => d.Produit)
                    .WithOne(p => p.Velo)
                    .HasForeignKey<Velo>(d => d.IdProduit)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Velo_Produit");

                // Configuration de la relation avec la table RapportInspection
                entity.HasOne(d => d.RapportInspection)
                    .WithOne(r => r.LeVelo)
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
                entity.HasOne(d => d.LeModele)
                    .WithMany(m => m.Velos)
                    .HasForeignKey(d => d.IdModele)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Velo_Modele");

                // Configuration de la relation avec la table CategorieVelo
                entity.HasOne(d => d.LaCategorie)
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
                    .IsRequired();

                // Configuration de la relation avec la table Client
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Alertes)
                    .HasForeignKey(d => d.IdClient)
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
                // Définir la clé primaire
                entity.HasKey(e => e.IdBoutique).HasName("PK_Boutique");

                // Configuration de la colonne NomBoutique
                entity.Property(e => e.NomBoutique)
                    .HasMaxLength(50)
                    .IsRequired();

                // Configuration de la relation avec la table Adresse
                entity.HasOne(d => d.Adresse)
                    .WithOne(a => a.Boutique)
                    .HasForeignKey<Boutique>(d => d.IdAdresse)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Boutique_Adresse");

                // Configuration de la relation avec la table Commande
                entity.HasMany(d => d.Commandes)
                    .WithOne(c => c.Boutique)
                    .HasForeignKey(c => c.IdBoutique)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Boutique_Commande");
            });

            modelBuilder.Entity<Caracteristique>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdCaract).HasName("PK_Caracteristique");

                // Configuration de la colonne Typecaract
                entity.Property(e => e.Typecaract)
                    .HasMaxLength(250)
                    .IsRequired();

                // Configuration de la relation avec la table SousCategorie
                entity.HasOne(d => d.SousCategorie)
                    .WithMany(s => s.Caracteristiques)
                    .HasForeignKey(d => d.IdSousCat)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Caracteristique_SousCategorie");
            });

            modelBuilder.Entity<CategorieAccessoire>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdCatA).HasName("PK_CategorieAccessoire");

                // Configuration de la colonne NomCatA
                entity.Property(e => e.NomCatA)
                    .HasMaxLength(30)
                    .IsRequired();

                // Configuration de la relation avec la table Accessoire
                entity.HasMany(d => d.Accessoires)
                    .WithOne(a => a.CategorieAccessoire)
                    .HasForeignKey(a => a.IdCatA)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CategorieAccessoire_Accessoire");
            });

            modelBuilder.Entity<CategorieVelo>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdCat).HasName("PK_CategorieVelo");

                // Configuration de la colonne NomCategorie
                entity.Property(e => e.NomCategorie)
                    .HasMaxLength(50)
                    .IsRequired();

                // Configuration de la relation avec la table Velo
                entity.HasMany(d => d.Velos)
                    .WithOne(v => v.LaCategorie)
                    .HasForeignKey(v => v.IdCat)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CategorieVelo_Velo");

                // Configuration de la relation avec la table Concerne
                entity.HasMany(d => d.ConcerneAlerte)
                    .WithOne(c => c.ConcerneCategorieVelo)
                    .HasForeignKey(c => c.IdCat)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CategorieVelo_Concerne");
            });

            modelBuilder.Entity<CodeReduc>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.Idcode).HasName("PK_CodeReduc");

                // Configuration de la colonne Libellecode
                entity.Property(e => e.Libellecode)
                    .HasMaxLength(30)
                    .IsRequired();

                // Configuration de la relation avec la table Commande
                entity.HasMany(d => d.Commandes)
                    .WithOne(c => c.Code)
                    .HasForeignKey(c => c.IdCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CodeReduc_Commande");
            });

            modelBuilder.Entity<Etat>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdEtat).HasName("PK_Etat");

                // Configuration de la colonne NomEtat
                entity.Property(e => e.NomEtat)
                    .HasMaxLength(20)
                    .IsRequired();

                // Configuration de la relation avec la table Velo
                entity.HasMany(d => d.Velos)
                    .WithOne(v => v.Etat)
                    .HasForeignKey(v => v.IdEtat)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Etat_Velo");
            });

            modelBuilder.Entity<Fonction>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.Id).HasName("PK_Fonction");

                // Configuration de la colonne NomFonction
                entity.Property(e => e.NomFonction)
                    .HasMaxLength(80)
                    .IsRequired();

                // Configuration de la relation avec la table Client
                entity.HasMany(d => d.Clients)
                    .WithOne(c => c.Fonction)
                    .HasForeignKey(c => c.IdFonction)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Fonction_Client");
            });

            modelBuilder.Entity<Marque>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdMarque).HasName("PK_Marque");

                // Configuration de la colonne NomMarque
                entity.Property(e => e.NomMarque)
                    .HasMaxLength(30)
                    .IsRequired();

                // Configuration de la relation avec la table Modele
                entity.HasMany(d => d.Modeles)
                    .WithOne(m => m.Marque)
                    .HasForeignKey(m => m.IdMarque)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Marque_Modele");

                // Configuration de la relation avec la table Produit
                entity.HasMany(d => d.Produits)
                    .WithOne(p => p.Marque)
                    .HasForeignKey(p => p.IdMarque)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Marque_Produit");
            });

            modelBuilder.Entity<ModeExpedition>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdModeExp).HasName("PK_ModeExpedition");

                // Configuration de la colonne LibellemodeExp
                entity.Property(e => e.LibellemodeExp)
                    .HasMaxLength(30)
                    .IsRequired();

                // Configuration de la relation avec la table Commande
                entity.HasMany(d => d.Commandes)
                    .WithOne(c => c.ModeExpedition)
                    .HasForeignKey(c => c.IdModeExp)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ModeExpedition_Commande");
            });

            modelBuilder.Entity<ModePayement>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.Idmodepayement).HasName("PK_ModePayement");

                // Configuration de la colonne NomModepayement
                entity.Property(e => e.NomModepayement)
                    .HasMaxLength(50)
                    .IsRequired();

                // Configuration de la relation avec la table Commande
                entity.HasMany(d => d.Commandes)
                    .WithOne(c => c.ModePayement)
                    .HasForeignKey(c => c.IdModePayement)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ModePayement_Commande");
            });

            modelBuilder.Entity<Moteur>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdMoteur).HasName("PK_Moteur");

                // Configuration de la colonne Positionmoteur
                entity.Property(e => e.Positionmoteur)
                    .HasMaxLength(20)
                    .IsRequired();

                // Configuration de la colonne CoupleMoteur
                entity.Property(e => e.CoupleMoteur)
                    .IsRequired();

                // Configuration de la colonne VitesseMax
                entity.Property(e => e.VitesseMax)
                    .IsRequired();

                // Configuration de la relation avec la table Est_Compose
                entity.HasMany(d => d.LesVelos)
                    .WithOne(e => e.LeMoteur)
                    .HasForeignKey(e => e.IdMoteur)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Moteur_Est_Compose");

                // Configuration de la relation avec la table Est_De_ModeleM
                entity.HasMany(d => d.LesModeles)
                    .WithOne(e => e.LeMoteur)
                    .HasForeignKey(e => e.IdMoteur)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Moteur_Est_De_ModeleM");
            });

            modelBuilder.Entity<Pays>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdPays).HasName("PK_Pays");

                // Configuration de la colonne NomPays
                entity.Property(e => e.NomPays)
                    .HasMaxLength(50)
                    .IsRequired();

                // Configuration de la relation avec la table Adresse
                entity.HasMany(d => d.Adresses)
                    .WithOne(a => a.Pays)
                    .HasForeignKey(a => a.PaysId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Pays_Adresse");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdPhoto).HasName("PK_Photo");

                // Configuration de la colonne Url
                entity.Property(e => e.Url)
                    .HasMaxLength(300)
                    .IsRequired();

                // Configuration de la colonne Description
                entity.Property(e => e.Description)
                    .HasMaxLength(200);

                // Configuration de la relation avec la table Produit (1 à 0..1)
                entity.HasOne(d => d.Produit)
                    .WithOne(p => p.Photo)
                    .HasForeignKey<Produit>(p => p.IdPhoto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Photo_Produit");

                // Configuration de la relation avec la table A_Pour_Photo (1 à 0..1)
                entity.HasOne(d => d.AProduit)
                    .WithOne(a => a.Photo)
                    .HasForeignKey<A_Pour_Photo>(a => a.IdPhoto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Photo_A_Pour_Photo");
            });

            modelBuilder.Entity<Statut>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdStatut).HasName("PK_Statut");

                // Configuration de la colonne NomStatut
                entity.Property(e => e.NomStatut)
                    .HasMaxLength(30)
                    .IsRequired();

                // Configuration de la relation avec la table Commande
                entity.HasMany(d => d.Commandes)
                    .WithOne(c => c.Statut)
                    .HasForeignKey(c => c.IdStatut)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Statut_Commande");
            });

            modelBuilder.Entity<Taille>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.Idtaille).HasName("PK_Taille");

                // Configuration de la colonne TailleCm
                entity.Property(e => e.TailleCm)
                    .IsRequired();

                // Configuration de la relation avec la table Alerte
                entity.HasMany(d => d.Alerte)
                    .WithOne(a => a.Taille)
                    .HasForeignKey(a => a.IdTaille)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Taille_Alerte");

                // Configuration de la relation avec la table Velo (TailleMin)
                entity.HasMany(d => d.VelosMin)
                    .WithOne(v => v.TailleMin)
                    .HasForeignKey(v => v.IdTailleMin)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Taille_Velo_Min");

                // Configuration de la relation avec la table Velo (TailleMax)
                entity.HasMany(d => d.VelosMax)
                    .WithOne(v => v.TailleMax)
                    .HasForeignKey(v => v.IdTailleMax)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Taille_Velo_Max");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.Idtype).HasName("PK_Type");

                // Configuration de la colonne NomType
                entity.Property(e => e.NomType)
                    .HasMaxLength(50)
                    .IsRequired();

                // Configuration de la relation avec la table Valide
                entity.HasMany(d => d.LesRapports)
                    .WithOne(v => v.LeType)
                    .HasForeignKey(v => v.IdType)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Type_Valide");

                // Configuration de la relation avec la table Contient
                entity.HasMany(d => d.ASousTypes)
                    .WithOne(c => c.ContientType)
                    .HasForeignKey(c => c.IdType)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Type_Contient");
            });
            modelBuilder.Entity<A_Pour_Photo>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(pp => pp.Idapourphoto);

                // Configurer la relation avec la table Photo
                entity.HasOne(pp => pp.Photo)
                      .WithOne(p => p.AProduit) 
                      .HasForeignKey<A_Pour_Photo>(pp => pp.IdPhoto)
                      .OnDelete(DeleteBehavior.Cascade); 

                // Configurer la relation avec la table Produit
                entity.HasOne(pp => pp.ProduitAPhoto)
                      .WithMany(p => p.APhotos) 
                      .HasForeignKey(pp => pp.IdProduit)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Concerne>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(c => c.IdConcerne);

                // Configurer la relation avec la table Alerte
                entity.HasOne(c => c.ConcerneAlerte)
                      .WithMany(a => a.EstConcerneCategorie) 
                      .HasForeignKey(c => c.IdAlerte)
                      .OnDelete(DeleteBehavior.Cascade); 

                // Configurer la relation avec la table CategorieVelo
                entity.HasOne(c => c.ConcerneCategorieVelo)
                      .WithMany(cv => cv.ConcerneAlerte) 
                      .HasForeignKey(c => c.IdCat)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Contient>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(c => c.IdContient);

                // Configurer la relation avec la table SousType
                entity.HasOne(c => c.ContientSousType)
                      .WithMany(st => st.AType) 
                      .HasForeignKey(c => c.IdSoustype)
                      .OnDelete(DeleteBehavior.Cascade); 

                // Configurer la relation avec la table Type
                entity.HasOne(c => c.ContientType)
                      .WithMany(t => t.ASousTypes) 
                      .HasForeignKey(c => c.IdType)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Est_Caracterise>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(ec => ec.IdestCaracterise);

                // Configurer la relation avec la table Velo
                entity.HasOne(ec => ec.CaracteriseVelo)
                      .WithMany(v => v.Caracteristiques) 
                      .HasForeignKey(ec => ec.IdVelo)
                      .OnDelete(DeleteBehavior.Cascade); 

                // Configurer la relation avec la table Caracteristique
                entity.HasOne(ec => ec.Caracterise)
                      .WithMany(c => c.CaracteriseVelo) 
                      .HasForeignKey(ec => ec.IdCaract)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Est_Compose>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(ec => ec.IdCompose);

                // Configurer la relation avec la table Velo
                entity.HasOne(ec => ec.LeVelo)
                      .WithMany(v => v.LesMoteurs) 
                      .HasForeignKey(ec => ec.IdVelo)
                      .OnDelete(DeleteBehavior.Cascade); 

                // Configurer la relation avec la table Moteur
                entity.HasOne(ec => ec.LeMoteur)
                      .WithMany(m => m.LesVelos) 
                      .HasForeignKey(ec => ec.IdMoteur)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Est_De_ModeleM>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(edm => edm.EstDeModeleM);

                // Configurer la relation avec la table Modele
                entity.HasOne(edm => edm.LeModele)
                      .WithMany(m => m.LesMoteurs) 
                      .HasForeignKey(edm => edm.IdModele)
                      .OnDelete(DeleteBehavior.Cascade); 

                // Configurer la relation avec la table Moteur
                entity.HasOne(edm => edm.LeMoteur)
                      .WithMany(m => m.LesModeles) 
                      .HasForeignKey(edm => edm.IdMoteur)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Est_En_Favoris>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(eef => eef.IdEstEnFavoris);

                // Configurer la relation avec la table Client
                entity.HasOne(eef => eef.ClientFavoris)
                      .WithMany(c => c.LesFavoris) 
                      .HasForeignKey(eef => eef.IdClient)
                      .OnDelete(DeleteBehavior.Cascade); 

                // Configurer la relation avec la table Produit
                entity.HasOne(eef => eef.LesProduits)
                      .WithMany(p => p.DansLesFavoris) 
                      .HasForeignKey(eef => eef.IdProduit)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Est_Mis_Panier_Accessoire>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(empa => empa.IdEstProposeSimilaire);

                // Configurer la relation avec la table Accessoire
                entity.HasOne(empa => empa.LAccessoire)
                      .WithMany(a => a.LesCommandesAccessoire) 
                      .HasForeignKey(empa => empa.IdAccessoire)
                      .OnDelete(DeleteBehavior.Cascade); 

                // Configurer la relation avec la table Commande
                entity.HasOne(empa => empa.LaCommande)
                      .WithMany(c => c.LesAccessoires) 
                      .HasForeignKey(empa => empa.IdCommande)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Est_Mis_Panier_Velo>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(empv => empv.IdPanierVelo);

                // Configurer la relation avec la table Velo
                entity.HasOne(empv => empv.PanierVelo)
                      .WithMany(v => v.ACommandes) 
                      .HasForeignKey(empv => empv.IdVelo)
                      .OnDelete(DeleteBehavior.Cascade); 

                // Configurer la relation avec la table Commande
                entity.HasOne(empv => empv.PanierCommande)
                      .WithMany(c => c.PanierVelo) 
                      .HasForeignKey(empv => empv.IdCommande)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Est_Propose_Similaire>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(eps => eps.IdEstProposeSimilaire);

                // Configurer la relation avec la table Accessoire
                entity.HasOne(eps => eps.LAccessoire)
                      .WithMany(a => a.LesCommandes) 
                      .HasForeignKey(eps => eps.IdAccessoire)
                      .OnDelete(DeleteBehavior.Cascade); 

                // Configurer la relation avec la table Commande
                entity.HasOne(eps => eps.LaCommande)
                      .WithMany(c => c.LesSimilaires) 
                      .HasForeignKey(eps => eps.IdCommande)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Habite>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(h => h.Idhabite);

                // Configurer la relation avec la table Client
                entity.HasOne(h => h.ClientHabite)
                      .WithMany(c => c.HabiteA) 
                      .HasForeignKey(h => h.Idclient)
                      .OnDelete(DeleteBehavior.Cascade); 

                // Configurer la relation avec la table Adresse
                entity.HasOne(h => h.AdresseHabite)
                      .WithMany(a => a.AClients) 
                      .HasForeignKey(h => h.Idadresse)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Peut_Etre_Teste>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(pet => pet.IdTest);

                // Configurer la relation avec la table Boutique
                entity.HasOne(pet => pet.LaBoutique)
                      .WithMany(b => b.LesVelos)
                      .HasForeignKey(pet => pet.IdBoutique)
                      .OnDelete(DeleteBehavior.Cascade);

                // Configurer la relation avec la table Velo
                entity.HasOne(pet => pet.LeVelo)
                      .WithMany(v => v.LesBoutiques)
                      .HasForeignKey(pet => pet.IdVelo)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Possede>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(p => p.IdPossede);

                // Configurer la relation avec la table SousCategorie
                entity.HasOne(p => p.LaSousCategorie)
                      .WithMany(sc => sc.LesVelos)
                      .HasForeignKey(p => p.IdSousCat)
                      .OnDelete(DeleteBehavior.Cascade);

                // Configurer la relation avec la table Velo
                entity.HasOne(p => p.LeVelo)
                      .WithMany(v => v.LesSousCategories)
                      .HasForeignKey(p => p.IdVelo)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Propose_Assur>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(pa => pa.IdProposeAssur);

                // Configurer la relation avec la table Commande
                entity.HasOne(pa => pa.Commande)
                      .WithMany(c => c.AssurancesPropose)
                      .HasForeignKey(pa => pa.IdCommande)
                      .OnDelete(DeleteBehavior.Cascade);

                // Configurer la relation avec la table Assurance
                entity.HasOne(pa => pa.Assurance)
                      .WithMany(a => a.AssureCommande)
                      .HasForeignKey(pa => pa.IdAssurance)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Valide>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(v => v.IdValide);

                // Configurer la relation avec la table RapportInspection
                entity.HasOne(v => v.LeRapport)
                      .WithMany(r => r.LesTypes)
                      .HasForeignKey(v => v.IdRapport)
                      .OnDelete(DeleteBehavior.Cascade);

                // Configurer la relation avec la table Type
                entity.HasOne(v => v.LeType)
                      .WithMany(t => t.LesRapports)
                      .HasForeignKey(v => v.IdType)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Modele>(entity =>
            {
                // Définir la clé primaire
                entity.HasKey(e => e.IdModele);

                // Configurer les propriétés
                entity.Property(e => e.NomModele)
                      .IsRequired()
                      .HasMaxLength(200);

                // Configurer la relation avec la table Marque
                entity.HasOne(m => m.Marque)
                      .WithMany()
                      .HasForeignKey(m => m.IdMarque)
                      .OnDelete(DeleteBehavior.Cascade);

                // Configurer la relation avec la table Velo
                entity.HasMany(m => m.Velos)
                      .WithOne(v => v.LeModele)
                      .HasForeignKey(v => v.IdModele)
                      .OnDelete(DeleteBehavior.Cascade);

                // Configurer la relation avec la table Est_De_ModeleM
                entity.HasMany(m => m.LesMoteurs)
                      .WithOne(edm => edm.LeModele)
                      .HasForeignKey(edm => edm.IdModele)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.NomModele)
                    .HasColumnName("mdl_nom")
                    .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
