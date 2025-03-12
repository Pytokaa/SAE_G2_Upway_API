using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SAE_G2_Upway_API.Migrations
{
    /// <inheritdoc />
    public partial class CreationDBUpway : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "upway");

            migrationBuilder.CreateTable(
                name: "assurance",
                schema: "upway",
                columns: table => new
                {
                    idassurance = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomassurance = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    prixassurance = table.Column<decimal>(type: "numeric(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assurance", x => x.idassurance);
                });

            migrationBuilder.CreateTable(
                name: "categorieaccessoire",
                schema: "upway",
                columns: table => new
                {
                    idcata = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomcata = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieAccessoire", x => x.idcata);
                });

            migrationBuilder.CreateTable(
                name: "categorievelo",
                schema: "upway",
                columns: table => new
                {
                    idcat = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomcat = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieVelo", x => x.idcat);
                });

            migrationBuilder.CreateTable(
                name: "codereduc",
                schema: "upway",
                columns: table => new
                {
                    idcode = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libellecode = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeReduc", x => x.idcode);
                });

            migrationBuilder.CreateTable(
                name: "etat",
                schema: "upway",
                columns: table => new
                {
                    idetat = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nometat = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etat", x => x.idetat);
                });

            migrationBuilder.CreateTable(
                name: "fonction",
                schema: "upway",
                columns: table => new
                {
                    idfonction = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomfonction = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fonction", x => x.idfonction);
                });

            migrationBuilder.CreateTable(
                name: "marque",
                schema: "upway",
                columns: table => new
                {
                    idmarque = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nommarque = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marque", x => x.idmarque);
                });

            migrationBuilder.CreateTable(
                name: "modeexpedition",
                schema: "upway",
                columns: table => new
                {
                    idmodeexp = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libellemodeexp = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeExpedition", x => x.idmodeexp);
                });

            migrationBuilder.CreateTable(
                name: "modepayement",
                schema: "upway",
                columns: table => new
                {
                    idmodepayement = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nommodepayement = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModePayement", x => x.idmodepayement);
                });

            migrationBuilder.CreateTable(
                name: "moteur",
                schema: "upway",
                columns: table => new
                {
                    idmoteur = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    positionmoteur = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    couplemoteur = table.Column<int>(type: "integer", nullable: false),
                    vitessemax = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moteur", x => x.idmoteur);
                });

            migrationBuilder.CreateTable(
                name: "pays",
                schema: "upway",
                columns: table => new
                {
                    idpays = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nompays = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.idpays);
                });

            migrationBuilder.CreateTable(
                name: "photo",
                schema: "upway",
                columns: table => new
                {
                    idphoto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    url = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.idphoto);
                });

            migrationBuilder.CreateTable(
                name: "souscategorie",
                schema: "upway",
                columns: table => new
                {
                    idsouscat = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    typesouscat = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_souscategorie", x => x.idsouscat);
                });

            migrationBuilder.CreateTable(
                name: "soustype",
                schema: "upway",
                columns: table => new
                {
                    idsoustype = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libellesoustype = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_soustype", x => x.idsoustype);
                });

            migrationBuilder.CreateTable(
                name: "statut",
                schema: "upway",
                columns: table => new
                {
                    idstatut = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomstatut = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statut", x => x.idstatut);
                });

            migrationBuilder.CreateTable(
                name: "taille",
                schema: "upway",
                columns: table => new
                {
                    idtaille = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    taillecm = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taille", x => x.idtaille);
                });

            migrationBuilder.CreateTable(
                name: "type",
                schema: "upway",
                columns: table => new
                {
                    idtype = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomtype = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.idtype);
                });

            migrationBuilder.CreateTable(
                name: "client",
                schema: "upway",
                columns: table => new
                {
                    idclient = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idfonction = table.Column<int>(type: "integer", nullable: false),
                    nomclient = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    prenomclient = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    mailclient = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    telephone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.idclient);
                    table.CheckConstraint("chk_mailclient_format", "mailclient ~* '^[A-Za-z0-9._%-+]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,3}$'");
                    table.ForeignKey(
                        name: "FK_Fonction_Client",
                        column: x => x.idfonction,
                        principalSchema: "upway",
                        principalTable: "fonction",
                        principalColumn: "idfonction",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "modele",
                schema: "upway",
                columns: table => new
                {
                    idmodele = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idmarque = table.Column<int>(type: "integer", nullable: false),
                    nomModele = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modele", x => x.idmodele);
                    table.ForeignKey(
                        name: "FK_Marque_Modele",
                        column: x => x.idmarque,
                        principalSchema: "upway",
                        principalTable: "marque",
                        principalColumn: "idmarque",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "adresse",
                schema: "upway",
                columns: table => new
                {
                    idadresse = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idpays = table.Column<int>(type: "integer", nullable: false),
                    rue = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cp = table.Column<int>(type: "integer", nullable: false),
                    ville = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.idadresse);
                    table.ForeignKey(
                        name: "FK_Pays_Adresse",
                        column: x => x.idpays,
                        principalSchema: "upway",
                        principalTable: "pays",
                        principalColumn: "idpays",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "produit",
                schema: "upway",
                columns: table => new
                {
                    idproduit = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idphoto = table.Column<int>(type: "integer", nullable: false),
                    idmarque = table.Column<int>(type: "integer", nullable: false),
                    nomproduit = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    prixproduit = table.Column<double>(type: "double precision", nullable: false),
                    stockproduit = table.Column<int>(type: "integer", nullable: false),
                    descriptionproduit = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.idproduit);
                    table.ForeignKey(
                        name: "FK_Marque_Produit",
                        column: x => x.idmarque,
                        principalSchema: "upway",
                        principalTable: "marque",
                        principalColumn: "idmarque",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_Produit",
                        column: x => x.idphoto,
                        principalSchema: "upway",
                        principalTable: "photo",
                        principalColumn: "idphoto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "caracteristique",
                schema: "upway",
                columns: table => new
                {
                    idcaract = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idsouscat = table.Column<int>(type: "integer", nullable: false),
                    typecaract = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristique", x => x.idcaract);
                    table.ForeignKey(
                        name: "FK_Caracteristique_SousCategorie",
                        column: x => x.idsouscat,
                        principalSchema: "upway",
                        principalTable: "souscategorie",
                        principalColumn: "idsouscat",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "surtype",
                schema: "upway",
                columns: table => new
                {
                    idsurtype = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idsoustype = table.Column<int>(type: "integer", nullable: false),
                    libellesurtype = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    repare = table.Column<bool>(type: "boolean", nullable: false),
                    checke = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surtype", x => x.idsurtype);
                    table.ForeignKey(
                        name: "FK_surtype_soustype_idsoustype",
                        column: x => x.idsoustype,
                        principalSchema: "upway",
                        principalTable: "soustype",
                        principalColumn: "idsoustype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contient",
                schema: "upway",
                columns: table => new
                {
                    idcontient = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idsoustype = table.Column<int>(type: "integer", nullable: false),
                    idtype = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contient", x => x.idcontient);
                    table.ForeignKey(
                        name: "FK_Type_Contient",
                        column: x => x.idtype,
                        principalSchema: "upway",
                        principalTable: "type",
                        principalColumn: "idtype",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contient_soustype_idsoustype",
                        column: x => x.idsoustype,
                        principalSchema: "upway",
                        principalTable: "soustype",
                        principalColumn: "idsoustype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alerte",
                schema: "upway",
                columns: table => new
                {
                    idalerte = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idclient = table.Column<int>(type: "integer", nullable: false),
                    idtaille = table.Column<int>(type: "integer", nullable: false),
                    budgetmax = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerte", x => x.idalerte);
                    table.ForeignKey(
                        name: "FK_Alerte_Client",
                        column: x => x.idclient,
                        principalSchema: "upway",
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Taille_Alerte",
                        column: x => x.idtaille,
                        principalSchema: "upway",
                        principalTable: "taille",
                        principalColumn: "idtaille",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "estdemodelem",
                schema: "upway",
                columns: table => new
                {
                    idestdemodelem = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idmoteur = table.Column<int>(type: "integer", nullable: false),
                    idmodele = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estdemodelem", x => x.idestdemodelem);
                    table.ForeignKey(
                        name: "FK_Moteur_Est_De_ModeleM",
                        column: x => x.idmoteur,
                        principalSchema: "upway",
                        principalTable: "moteur",
                        principalColumn: "idmoteur",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_estdemodelem_modele_idmodele",
                        column: x => x.idmodele,
                        principalSchema: "upway",
                        principalTable: "modele",
                        principalColumn: "idmodele",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "boutique",
                schema: "upway",
                columns: table => new
                {
                    idboutique = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomboutique = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    idadresse = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boutique", x => x.idboutique);
                    table.ForeignKey(
                        name: "FK_Boutique_Adresse",
                        column: x => x.idadresse,
                        principalSchema: "upway",
                        principalTable: "adresse",
                        principalColumn: "idadresse",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "habite",
                schema: "upway",
                columns: table => new
                {
                    idhabite = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idclient = table.Column<int>(type: "integer", nullable: false),
                    idadresse = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_habite", x => x.idhabite);
                    table.ForeignKey(
                        name: "FK_habite_adresse_idadresse",
                        column: x => x.idadresse,
                        principalSchema: "upway",
                        principalTable: "adresse",
                        principalColumn: "idadresse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_habite_client_idclient",
                        column: x => x.idclient,
                        principalSchema: "upway",
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "a_pour_photo",
                schema: "upway",
                columns: table => new
                {
                    idapourphoto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idphoto = table.Column<int>(type: "integer", nullable: false),
                    idproduit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_a_pour_photo", x => x.idapourphoto);
                    table.ForeignKey(
                        name: "FK_Photo_A_Pour_Photo",
                        column: x => x.idphoto,
                        principalSchema: "upway",
                        principalTable: "photo",
                        principalColumn: "idphoto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produit_A_Pour_Photo",
                        column: x => x.idproduit,
                        principalSchema: "upway",
                        principalTable: "produit",
                        principalColumn: "idproduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accessoire",
                schema: "upway",
                columns: table => new
                {
                    idaccessoire = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idproduit = table.Column<int>(type: "integer", nullable: false),
                    idcatA = table.Column<int>(type: "integer", nullable: false),
                    dateaccessoire = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessoire", x => x.idaccessoire);
                    table.ForeignKey(
                        name: "FK_CategorieAccessoire_Accessoire",
                        column: x => x.idcatA,
                        principalSchema: "upway",
                        principalTable: "categorieaccessoire",
                        principalColumn: "idcata",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produit_Accessoire",
                        column: x => x.idproduit,
                        principalSchema: "upway",
                        principalTable: "produit",
                        principalColumn: "idproduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estenfavoris",
                schema: "upway",
                columns: table => new
                {
                    idestenfavoris = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idclient = table.Column<int>(type: "integer", nullable: false),
                    idproduit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estenfavoris", x => x.idestenfavoris);
                    table.ForeignKey(
                        name: "FK_Client_Est_En_Favoris",
                        column: x => x.idclient,
                        principalSchema: "upway",
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produit_Est_En_Favoris",
                        column: x => x.idproduit,
                        principalSchema: "upway",
                        principalTable: "produit",
                        principalColumn: "idproduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "velo",
                schema: "upway",
                columns: table => new
                {
                    idvelo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idproduit = table.Column<int>(type: "integer", nullable: false),
                    idtaillemin = table.Column<int>(type: "integer", nullable: false),
                    idtaillemax = table.Column<int>(type: "integer", nullable: false),
                    idmodele = table.Column<int>(type: "integer", nullable: false),
                    idcat = table.Column<int>(type: "integer", nullable: false),
                    idetat = table.Column<int>(type: "integer", nullable: false),
                    nbkms = table.Column<double>(type: "double precision", nullable: false),
                    prixneuf = table.Column<double>(type: "double precision", nullable: false),
                    poids = table.Column<double>(type: "double precision", nullable: false),
                    typecadre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Velo", x => x.idvelo);
                    table.ForeignKey(
                        name: "FK_CategorieVelo_Velo",
                        column: x => x.idcat,
                        principalSchema: "upway",
                        principalTable: "categorievelo",
                        principalColumn: "idcat",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Etat_Velo",
                        column: x => x.idetat,
                        principalSchema: "upway",
                        principalTable: "etat",
                        principalColumn: "idetat",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Taille_Velo_Max",
                        column: x => x.idtaillemax,
                        principalSchema: "upway",
                        principalTable: "taille",
                        principalColumn: "idtaille",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Taille_Velo_Min",
                        column: x => x.idtaillemin,
                        principalSchema: "upway",
                        principalTable: "taille",
                        principalColumn: "idtaille",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Velo_Modele",
                        column: x => x.idmodele,
                        principalSchema: "upway",
                        principalTable: "modele",
                        principalColumn: "idmodele",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Velo_Produit",
                        column: x => x.idproduit,
                        principalSchema: "upway",
                        principalTable: "produit",
                        principalColumn: "idproduit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "concerne",
                schema: "upway",
                columns: table => new
                {
                    idconcerne = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idalerte = table.Column<int>(type: "integer", nullable: false),
                    idcat = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concerne", x => x.idconcerne);
                    table.ForeignKey(
                        name: "FK_CategorieVelo_Concerne",
                        column: x => x.idcat,
                        principalSchema: "upway",
                        principalTable: "categorievelo",
                        principalColumn: "idcat",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_concerne_alerte_idalerte",
                        column: x => x.idalerte,
                        principalSchema: "upway",
                        principalTable: "alerte",
                        principalColumn: "idalerte",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "commande",
                schema: "upway",
                columns: table => new
                {
                    idcommande = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datecommande = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    idcode = table.Column<int>(type: "integer", nullable: false),
                    idstatut = table.Column<int>(type: "integer", nullable: false),
                    idmodeexp = table.Column<int>(type: "integer", nullable: false),
                    idadresse = table.Column<int>(type: "integer", nullable: false),
                    idboutique = table.Column<int>(type: "integer", nullable: false),
                    idadressefactu = table.Column<int>(type: "integer", nullable: false),
                    idmodepayement = table.Column<int>(type: "integer", nullable: false),
                    idclient = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commande", x => x.idcommande);
                    table.ForeignKey(
                        name: "FK_Boutique_Commande",
                        column: x => x.idboutique,
                        principalSchema: "upway",
                        principalTable: "boutique",
                        principalColumn: "idboutique",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CodeReduc_Commande",
                        column: x => x.idcode,
                        principalSchema: "upway",
                        principalTable: "codereduc",
                        principalColumn: "idcode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commande_Adresse",
                        column: x => x.idadresse,
                        principalSchema: "upway",
                        principalTable: "adresse",
                        principalColumn: "idadresse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commande_AdresseFactu",
                        column: x => x.idadressefactu,
                        principalSchema: "upway",
                        principalTable: "adresse",
                        principalColumn: "idadresse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commande_Client",
                        column: x => x.idclient,
                        principalSchema: "upway",
                        principalTable: "client",
                        principalColumn: "idclient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModeExpedition_Commande",
                        column: x => x.idmodeexp,
                        principalSchema: "upway",
                        principalTable: "modeexpedition",
                        principalColumn: "idmodeexp",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModePayement_Commande",
                        column: x => x.idmodepayement,
                        principalSchema: "upway",
                        principalTable: "modepayement",
                        principalColumn: "idmodepayement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statut_Commande",
                        column: x => x.idstatut,
                        principalSchema: "upway",
                        principalTable: "statut",
                        principalColumn: "idstatut",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "est_caracterise",
                schema: "upway",
                columns: table => new
                {
                    idestcaracterise = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idcaract = table.Column<int>(type: "integer", nullable: false),
                    idvelo = table.Column<int>(type: "integer", nullable: false),
                    valeurcaracteristique = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_est_caracterise", x => x.idestcaracterise);
                    table.ForeignKey(
                        name: "FK_est_caracterise_caracteristique_idcaract",
                        column: x => x.idcaract,
                        principalSchema: "upway",
                        principalTable: "caracteristique",
                        principalColumn: "idcaract",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_est_caracterise_velo_idvelo",
                        column: x => x.idvelo,
                        principalSchema: "upway",
                        principalTable: "velo",
                        principalColumn: "idvelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estcompose",
                schema: "upway",
                columns: table => new
                {
                    idcompose = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idvelo = table.Column<int>(type: "integer", nullable: false),
                    idmoteur = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estcompose", x => x.idcompose);
                    table.ForeignKey(
                        name: "FK_Moteur_Est_Compose",
                        column: x => x.idmoteur,
                        principalSchema: "upway",
                        principalTable: "moteur",
                        principalColumn: "idmoteur",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_estcompose_velo_idvelo",
                        column: x => x.idvelo,
                        principalSchema: "upway",
                        principalTable: "velo",
                        principalColumn: "idvelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "peutetreteste",
                schema: "upway",
                columns: table => new
                {
                    idtest = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idvelo = table.Column<int>(type: "integer", nullable: false),
                    idboutique = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peutetreteste", x => x.idtest);
                    table.ForeignKey(
                        name: "FK_peutetreteste_boutique_idboutique",
                        column: x => x.idboutique,
                        principalSchema: "upway",
                        principalTable: "boutique",
                        principalColumn: "idboutique",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_peutetreteste_velo_idvelo",
                        column: x => x.idvelo,
                        principalSchema: "upway",
                        principalTable: "velo",
                        principalColumn: "idvelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "possede",
                schema: "upway",
                columns: table => new
                {
                    idpossede = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idsouscat = table.Column<int>(type: "integer", nullable: false),
                    idvelo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_possede", x => x.idpossede);
                    table.ForeignKey(
                        name: "FK_possede_souscategorie_idsouscat",
                        column: x => x.idsouscat,
                        principalSchema: "upway",
                        principalTable: "souscategorie",
                        principalColumn: "idsouscat",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_possede_velo_idvelo",
                        column: x => x.idvelo,
                        principalSchema: "upway",
                        principalTable: "velo",
                        principalColumn: "idvelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rapportinspection",
                schema: "upway",
                columns: table => new
                {
                    idrapport = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idvelo = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    centre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    historique = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    commentaire = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rapportinspection", x => x.idrapport);
                    table.ForeignKey(
                        name: "FK_Velo_RapportInspection",
                        column: x => x.idvelo,
                        principalSchema: "upway",
                        principalTable: "velo",
                        principalColumn: "idvelo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "est_mis_panier_velo",
                schema: "upway",
                columns: table => new
                {
                    idpaniervelo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idvelo = table.Column<int>(type: "integer", nullable: false),
                    idcommande = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_est_mis_panier_velo", x => x.idpaniervelo);
                    table.ForeignKey(
                        name: "FK_est_mis_panier_velo_commande_idcommande",
                        column: x => x.idcommande,
                        principalSchema: "upway",
                        principalTable: "commande",
                        principalColumn: "idcommande",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_est_mis_panier_velo_velo_idvelo",
                        column: x => x.idvelo,
                        principalSchema: "upway",
                        principalTable: "velo",
                        principalColumn: "idvelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estmispanieraccessorie",
                schema: "upway",
                columns: table => new
                {
                    idpanieraccessoire = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idaccessoire = table.Column<int>(type: "integer", nullable: false),
                    idcommande = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estmispanieraccessorie", x => x.idpanieraccessoire);
                    table.ForeignKey(
                        name: "FK_estmispanieraccessorie_accessoire_idaccessoire",
                        column: x => x.idaccessoire,
                        principalSchema: "upway",
                        principalTable: "accessoire",
                        principalColumn: "idaccessoire",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estmispanieraccessorie_commande_idcommande",
                        column: x => x.idcommande,
                        principalSchema: "upway",
                        principalTable: "commande",
                        principalColumn: "idcommande",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estproposesimilaire",
                schema: "upway",
                columns: table => new
                {
                    idestproposesimilaire = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idaccessoire = table.Column<int>(type: "integer", nullable: false),
                    idcommande = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estproposesimilaire", x => x.idestproposesimilaire);
                    table.ForeignKey(
                        name: "FK_estproposesimilaire_accessoire_idaccessoire",
                        column: x => x.idaccessoire,
                        principalSchema: "upway",
                        principalTable: "accessoire",
                        principalColumn: "idaccessoire",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estproposesimilaire_commande_idcommande",
                        column: x => x.idcommande,
                        principalSchema: "upway",
                        principalTable: "commande",
                        principalColumn: "idcommande",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propose_assur",
                schema: "upway",
                columns: table => new
                {
                    idproposeassur = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idassurance = table.Column<int>(type: "integer", nullable: false),
                    idcommande = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propose_assur", x => x.idproposeassur);
                    table.ForeignKey(
                        name: "FK_propose_assur_assurance_idassurance",
                        column: x => x.idassurance,
                        principalSchema: "upway",
                        principalTable: "assurance",
                        principalColumn: "idassurance",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_propose_assur_commande_idcommande",
                        column: x => x.idcommande,
                        principalSchema: "upway",
                        principalTable: "commande",
                        principalColumn: "idcommande",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "valide",
                schema: "upway",
                columns: table => new
                {
                    idvalide = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idrapport = table.Column<int>(type: "integer", nullable: false),
                    idtype = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_valide", x => x.idvalide);
                    table.ForeignKey(
                        name: "FK_Type_Valide",
                        column: x => x.idtype,
                        principalSchema: "upway",
                        principalTable: "type",
                        principalColumn: "idtype",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_valide_rapportinspection_idrapport",
                        column: x => x.idrapport,
                        principalSchema: "upway",
                        principalTable: "rapportinspection",
                        principalColumn: "idrapport",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_a_pour_photo_idphoto",
                schema: "upway",
                table: "a_pour_photo",
                column: "idphoto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_a_pour_photo_idproduit",
                schema: "upway",
                table: "a_pour_photo",
                column: "idproduit");

            migrationBuilder.CreateIndex(
                name: "IX_accessoire_idcatA",
                schema: "upway",
                table: "accessoire",
                column: "idcatA");

            migrationBuilder.CreateIndex(
                name: "IX_accessoire_idproduit",
                schema: "upway",
                table: "accessoire",
                column: "idproduit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_adresse_idpays",
                schema: "upway",
                table: "adresse",
                column: "idpays");

            migrationBuilder.CreateIndex(
                name: "IX_alerte_idclient",
                schema: "upway",
                table: "alerte",
                column: "idclient");

            migrationBuilder.CreateIndex(
                name: "IX_alerte_idtaille",
                schema: "upway",
                table: "alerte",
                column: "idtaille");

            migrationBuilder.CreateIndex(
                name: "IX_boutique_idadresse",
                schema: "upway",
                table: "boutique",
                column: "idadresse",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_caracteristique_idsouscat",
                schema: "upway",
                table: "caracteristique",
                column: "idsouscat");

            migrationBuilder.CreateIndex(
                name: "IX_client_idfonction",
                schema: "upway",
                table: "client",
                column: "idfonction");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idadresse",
                schema: "upway",
                table: "commande",
                column: "idadresse");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idadressefactu",
                schema: "upway",
                table: "commande",
                column: "idadressefactu");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idboutique",
                schema: "upway",
                table: "commande",
                column: "idboutique");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idclient",
                schema: "upway",
                table: "commande",
                column: "idclient");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idcode",
                schema: "upway",
                table: "commande",
                column: "idcode");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idmodeexp",
                schema: "upway",
                table: "commande",
                column: "idmodeexp");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idmodepayement",
                schema: "upway",
                table: "commande",
                column: "idmodepayement");

            migrationBuilder.CreateIndex(
                name: "IX_commande_idstatut",
                schema: "upway",
                table: "commande",
                column: "idstatut");

            migrationBuilder.CreateIndex(
                name: "IX_concerne_idalerte",
                schema: "upway",
                table: "concerne",
                column: "idalerte");

            migrationBuilder.CreateIndex(
                name: "IX_concerne_idcat",
                schema: "upway",
                table: "concerne",
                column: "idcat");

            migrationBuilder.CreateIndex(
                name: "IX_contient_idsoustype",
                schema: "upway",
                table: "contient",
                column: "idsoustype");

            migrationBuilder.CreateIndex(
                name: "IX_contient_idtype",
                schema: "upway",
                table: "contient",
                column: "idtype");

            migrationBuilder.CreateIndex(
                name: "IX_est_caracterise_idcaract",
                schema: "upway",
                table: "est_caracterise",
                column: "idcaract");

            migrationBuilder.CreateIndex(
                name: "IX_est_caracterise_idvelo",
                schema: "upway",
                table: "est_caracterise",
                column: "idvelo");

            migrationBuilder.CreateIndex(
                name: "IX_est_mis_panier_velo_idcommande",
                schema: "upway",
                table: "est_mis_panier_velo",
                column: "idcommande");

            migrationBuilder.CreateIndex(
                name: "IX_est_mis_panier_velo_idvelo",
                schema: "upway",
                table: "est_mis_panier_velo",
                column: "idvelo");

            migrationBuilder.CreateIndex(
                name: "IX_estcompose_idmoteur",
                schema: "upway",
                table: "estcompose",
                column: "idmoteur");

            migrationBuilder.CreateIndex(
                name: "IX_estcompose_idvelo",
                schema: "upway",
                table: "estcompose",
                column: "idvelo");

            migrationBuilder.CreateIndex(
                name: "IX_estdemodelem_idmodele",
                schema: "upway",
                table: "estdemodelem",
                column: "idmodele");

            migrationBuilder.CreateIndex(
                name: "IX_estdemodelem_idmoteur",
                schema: "upway",
                table: "estdemodelem",
                column: "idmoteur");

            migrationBuilder.CreateIndex(
                name: "IX_estenfavoris_idclient",
                schema: "upway",
                table: "estenfavoris",
                column: "idclient");

            migrationBuilder.CreateIndex(
                name: "IX_estenfavoris_idproduit",
                schema: "upway",
                table: "estenfavoris",
                column: "idproduit");

            migrationBuilder.CreateIndex(
                name: "IX_estmispanieraccessorie_idaccessoire",
                schema: "upway",
                table: "estmispanieraccessorie",
                column: "idaccessoire");

            migrationBuilder.CreateIndex(
                name: "IX_estmispanieraccessorie_idcommande",
                schema: "upway",
                table: "estmispanieraccessorie",
                column: "idcommande");

            migrationBuilder.CreateIndex(
                name: "IX_estproposesimilaire_idaccessoire",
                schema: "upway",
                table: "estproposesimilaire",
                column: "idaccessoire");

            migrationBuilder.CreateIndex(
                name: "IX_estproposesimilaire_idcommande",
                schema: "upway",
                table: "estproposesimilaire",
                column: "idcommande");

            migrationBuilder.CreateIndex(
                name: "IX_habite_idadresse",
                schema: "upway",
                table: "habite",
                column: "idadresse");

            migrationBuilder.CreateIndex(
                name: "IX_habite_idclient",
                schema: "upway",
                table: "habite",
                column: "idclient");

            migrationBuilder.CreateIndex(
                name: "IX_modele_idmarque",
                schema: "upway",
                table: "modele",
                column: "idmarque");

            migrationBuilder.CreateIndex(
                name: "IX_peutetreteste_idboutique",
                schema: "upway",
                table: "peutetreteste",
                column: "idboutique");

            migrationBuilder.CreateIndex(
                name: "IX_peutetreteste_idvelo",
                schema: "upway",
                table: "peutetreteste",
                column: "idvelo");

            migrationBuilder.CreateIndex(
                name: "IX_possede_idsouscat",
                schema: "upway",
                table: "possede",
                column: "idsouscat");

            migrationBuilder.CreateIndex(
                name: "IX_possede_idvelo",
                schema: "upway",
                table: "possede",
                column: "idvelo");

            migrationBuilder.CreateIndex(
                name: "IX_produit_idmarque",
                schema: "upway",
                table: "produit",
                column: "idmarque");

            migrationBuilder.CreateIndex(
                name: "IX_produit_idphoto",
                schema: "upway",
                table: "produit",
                column: "idphoto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_propose_assur_idassurance",
                schema: "upway",
                table: "propose_assur",
                column: "idassurance");

            migrationBuilder.CreateIndex(
                name: "IX_propose_assur_idcommande",
                schema: "upway",
                table: "propose_assur",
                column: "idcommande");

            migrationBuilder.CreateIndex(
                name: "IX_rapportinspection_idvelo",
                schema: "upway",
                table: "rapportinspection",
                column: "idvelo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_surtype_idsoustype",
                schema: "upway",
                table: "surtype",
                column: "idsoustype");

            migrationBuilder.CreateIndex(
                name: "IX_valide_idrapport",
                schema: "upway",
                table: "valide",
                column: "idrapport");

            migrationBuilder.CreateIndex(
                name: "IX_valide_idtype",
                schema: "upway",
                table: "valide",
                column: "idtype");

            migrationBuilder.CreateIndex(
                name: "IX_velo_idcat",
                schema: "upway",
                table: "velo",
                column: "idcat");

            migrationBuilder.CreateIndex(
                name: "IX_velo_idetat",
                schema: "upway",
                table: "velo",
                column: "idetat");

            migrationBuilder.CreateIndex(
                name: "IX_velo_idmodele",
                schema: "upway",
                table: "velo",
                column: "idmodele");

            migrationBuilder.CreateIndex(
                name: "IX_velo_idproduit",
                schema: "upway",
                table: "velo",
                column: "idproduit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_velo_idtaillemax",
                schema: "upway",
                table: "velo",
                column: "idtaillemax");

            migrationBuilder.CreateIndex(
                name: "IX_velo_idtaillemin",
                schema: "upway",
                table: "velo",
                column: "idtaillemin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "a_pour_photo",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "concerne",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "contient",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "est_caracterise",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "est_mis_panier_velo",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "estcompose",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "estdemodelem",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "estenfavoris",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "estmispanieraccessorie",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "estproposesimilaire",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "habite",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "peutetreteste",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "possede",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "propose_assur",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "surtype",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "valide",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "alerte",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "caracteristique",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "moteur",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "accessoire",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "assurance",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "commande",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "soustype",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "type",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "rapportinspection",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "souscategorie",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "categorieaccessoire",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "boutique",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "codereduc",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "client",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "modeexpedition",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "modepayement",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "statut",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "velo",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "adresse",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "fonction",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "categorievelo",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "etat",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "taille",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "modele",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "produit",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "pays",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "marque",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "photo",
                schema: "upway");
        }
    }
}
