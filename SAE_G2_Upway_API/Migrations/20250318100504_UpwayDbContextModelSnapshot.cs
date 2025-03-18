using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SAE_G2_Upway_API.Migrations
{
    /// <inheritdoc />
    public partial class UpwayDbContextModelSnapshot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "upway");

            migrationBuilder.CreateTable(
                name: "t_e_assurance_assur",
                schema: "upway",
                columns: table => new
                {
                    assur_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    assur_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    assur_prix = table.Column<decimal>(type: "numeric(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assurance", x => x.assur_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_categorieaccessoire_cata",
                schema: "upway",
                columns: table => new
                {
                    cata_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cata_nom = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieAccessoire", x => x.cata_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_categorievelo_catv",
                schema: "upway",
                columns: table => new
                {
                    catv_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    catv_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieVelo", x => x.catv_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_codereduc_codred",
                schema: "upway",
                columns: table => new
                {
                    codred_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codred_libelle = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeReduc", x => x.codred_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_etat_eta",
                schema: "upway",
                columns: table => new
                {
                    eta_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    eta_nom = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etat", x => x.eta_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_fonction_fn",
                schema: "upway",
                columns: table => new
                {
                    fn_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fn_nom = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fonction", x => x.fn_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_marque_mrq",
                schema: "upway",
                columns: table => new
                {
                    mrq_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mrq_nom = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marque", x => x.mrq_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_modeexpedition_modexpe",
                schema: "upway",
                columns: table => new
                {
                    modexpe_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    modexpe_libelle = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeExpedition", x => x.modexpe_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_modepayement_mpay",
                schema: "upway",
                columns: table => new
                {
                    mpay_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mpay_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModePayement", x => x.mpay_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_moteur_mtr",
                schema: "upway",
                columns: table => new
                {
                    mtr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mtr_position = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    mtr_couple = table.Column<int>(type: "integer", nullable: false),
                    mtr_vitessemax = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moteur", x => x.mtr_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_pays_pays",
                schema: "upway",
                columns: table => new
                {
                    pays_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pays_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.pays_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_photo_pto",
                schema: "upway",
                columns: table => new
                {
                    pto_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pto_url = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    pto_description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.pto_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_souscategorie_scat",
                schema: "upway",
                columns: table => new
                {
                    scat_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scat_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_souscategorie_scat", x => x.scat_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_soustype_styp",
                schema: "upway",
                columns: table => new
                {
                    styp_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    styp_libelle = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_soustype_styp", x => x.styp_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_statut_stu",
                schema: "upway",
                columns: table => new
                {
                    stu_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stu_nom = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statut", x => x.stu_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_taille_tle",
                schema: "upway",
                columns: table => new
                {
                    tle_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tle_taillecm = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taille", x => x.tle_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_type_typ",
                schema: "upway",
                columns: table => new
                {
                    typ_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    typ_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.typ_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_client_clt",
                schema: "upway",
                columns: table => new
                {
                    clt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fn_id = table.Column<int>(type: "integer", nullable: false),
                    clt_nom = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    clt_prenom = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    clt_mail = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    clt_telephone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    clt_password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    clt_userrole = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, defaultValue: "User")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.clt_id);
                    table.CheckConstraint("chk_mailclient_format", "clt_mail ~* '^[A-Za-z0-9._%-+]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,3}$'");
                    table.ForeignKey(
                        name: "FK_Fonction_Client",
                        column: x => x.fn_id,
                        principalSchema: "upway",
                        principalTable: "t_e_fonction_fn",
                        principalColumn: "fn_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_modele_mdl",
                schema: "upway",
                columns: table => new
                {
                    mdl_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mrq_id = table.Column<int>(type: "integer", nullable: false),
                    mdl_nom = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    MarqueIdMarque = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_modele_mdl", x => x.mdl_id);
                    table.ForeignKey(
                        name: "FK_Marque_Modele",
                        column: x => x.mrq_id,
                        principalSchema: "upway",
                        principalTable: "t_e_marque_mrq",
                        principalColumn: "mrq_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_modele_mdl_t_e_marque_mrq_MarqueIdMarque",
                        column: x => x.MarqueIdMarque,
                        principalSchema: "upway",
                        principalTable: "t_e_marque_mrq",
                        principalColumn: "mrq_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_adresse_adr",
                schema: "upway",
                columns: table => new
                {
                    adr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pays_id = table.Column<int>(type: "integer", nullable: false),
                    adr_rue = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    adr_cp = table.Column<int>(type: "integer", nullable: false),
                    adr_ville = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.adr_id);
                    table.ForeignKey(
                        name: "FK_Pays_Adresse",
                        column: x => x.pays_id,
                        principalSchema: "upway",
                        principalTable: "t_e_pays_pays",
                        principalColumn: "pays_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_produit_pdt",
                schema: "upway",
                columns: table => new
                {
                    pdt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pto_id = table.Column<int>(type: "integer", nullable: false),
                    mrq_id = table.Column<int>(type: "integer", nullable: false),
                    pdt_nom = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    pdt_prix = table.Column<double>(type: "double precision", nullable: false),
                    pdt_stock = table.Column<int>(type: "integer", nullable: false),
                    pdt_description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.pdt_id);
                    table.ForeignKey(
                        name: "FK_Marque_Produit",
                        column: x => x.mrq_id,
                        principalSchema: "upway",
                        principalTable: "t_e_marque_mrq",
                        principalColumn: "mrq_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_Produit",
                        column: x => x.pto_id,
                        principalSchema: "upway",
                        principalTable: "t_e_photo_pto",
                        principalColumn: "pto_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_caracteristique_caract",
                schema: "upway",
                columns: table => new
                {
                    caract_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scat_id = table.Column<int>(type: "integer", nullable: false),
                    caract_type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristique", x => x.caract_id);
                    table.ForeignKey(
                        name: "FK_Caracteristique_SousCategorie",
                        column: x => x.scat_id,
                        principalSchema: "upway",
                        principalTable: "t_e_souscategorie_scat",
                        principalColumn: "scat_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_surtype_srtyp",
                schema: "upway",
                columns: table => new
                {
                    srtyp_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    styp_id = table.Column<int>(type: "integer", nullable: false),
                    srtyp_libelle = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    srtyp_repare = table.Column<bool>(type: "boolean", nullable: false),
                    srtyp_checke = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_surtype_srtyp", x => x.srtyp_id);
                    table.ForeignKey(
                        name: "FK_t_e_surtype_srtyp_t_e_soustype_styp_styp_id",
                        column: x => x.styp_id,
                        principalSchema: "upway",
                        principalTable: "t_e_soustype_styp",
                        principalColumn: "styp_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_contient_ctn",
                schema: "upway",
                columns: table => new
                {
                    ctn_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    styp_id = table.Column<int>(type: "integer", nullable: false),
                    typ_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_contient_ctn", x => x.ctn_id);
                    table.ForeignKey(
                        name: "FK_Type_Contient",
                        column: x => x.typ_id,
                        principalSchema: "upway",
                        principalTable: "t_e_type_typ",
                        principalColumn: "typ_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_contient_ctn_t_e_soustype_styp_styp_id",
                        column: x => x.styp_id,
                        principalSchema: "upway",
                        principalTable: "t_e_soustype_styp",
                        principalColumn: "styp_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_alerte_alt",
                schema: "upway",
                columns: table => new
                {
                    alt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_id = table.Column<int>(type: "integer", nullable: false),
                    tle_id = table.Column<int>(type: "integer", nullable: false),
                    alt_budgetmax = table.Column<int>(type: "integer", nullable: false),
                    alt_email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerte", x => x.alt_id);
                    table.ForeignKey(
                        name: "FK_Alerte_Client",
                        column: x => x.clt_id,
                        principalSchema: "upway",
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Taille_Alerte",
                        column: x => x.tle_id,
                        principalSchema: "upway",
                        principalTable: "t_e_taille_tle",
                        principalColumn: "tle_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_estdemodelem_edmdlm",
                schema: "upway",
                columns: table => new
                {
                    edmdlm_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mtr_id = table.Column<int>(type: "integer", nullable: false),
                    mdl_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_estdemodelem_edmdlm", x => x.edmdlm_id);
                    table.ForeignKey(
                        name: "FK_Moteur_Est_De_ModeleM",
                        column: x => x.mtr_id,
                        principalSchema: "upway",
                        principalTable: "t_e_moteur_mtr",
                        principalColumn: "mtr_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_estdemodelem_edmdlm_t_e_modele_mdl_mdl_id",
                        column: x => x.mdl_id,
                        principalSchema: "upway",
                        principalTable: "t_e_modele_mdl",
                        principalColumn: "mdl_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_boutique_btq",
                schema: "upway",
                columns: table => new
                {
                    btq_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    btq_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    adr_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boutique", x => x.btq_id);
                    table.ForeignKey(
                        name: "FK_Boutique_Adresse",
                        column: x => x.adr_id,
                        principalSchema: "upway",
                        principalTable: "t_e_adresse_adr",
                        principalColumn: "adr_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_habite_hab",
                schema: "upway",
                columns: table => new
                {
                    hab_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_id = table.Column<int>(type: "integer", nullable: true),
                    adr_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_habite_hab", x => x.hab_id);
                    table.ForeignKey(
                        name: "FK_t_j_habite_hab_t_e_adresse_adr_adr_id",
                        column: x => x.adr_id,
                        principalSchema: "upway",
                        principalTable: "t_e_adresse_adr",
                        principalColumn: "adr_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_habite_hab_t_e_client_clt_clt_id",
                        column: x => x.clt_id,
                        principalSchema: "upway",
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_accessoire_acce",
                schema: "upway",
                columns: table => new
                {
                    acce_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pdt_id = table.Column<int>(type: "integer", nullable: false),
                    cata_id = table.Column<int>(type: "integer", nullable: false),
                    acce_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessoire", x => x.acce_id);
                    table.ForeignKey(
                        name: "FK_CategorieAccessoire_Accessoire",
                        column: x => x.cata_id,
                        principalSchema: "upway",
                        principalTable: "t_e_categorieaccessoire_cata",
                        principalColumn: "cata_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produit_Accessoire",
                        column: x => x.pdt_id,
                        principalSchema: "upway",
                        principalTable: "t_e_produit_pdt",
                        principalColumn: "pdt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_velo_vel",
                schema: "upway",
                columns: table => new
                {
                    vel_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pdt_id = table.Column<int>(type: "integer", nullable: false),
                    tle_idtaillemin = table.Column<int>(type: "integer", nullable: false),
                    tle_idtaillemax = table.Column<int>(type: "integer", nullable: false),
                    mdl_id = table.Column<int>(type: "integer", nullable: false),
                    catv_id = table.Column<int>(type: "integer", nullable: false),
                    eta_id = table.Column<int>(type: "integer", nullable: false),
                    vel_nbkms = table.Column<double>(type: "double precision", nullable: false),
                    vel_prixneuf = table.Column<double>(type: "double precision", nullable: false),
                    vel_poids = table.Column<double>(type: "double precision", nullable: false),
                    vel_typecadre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    vel_annee = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vel_bestseller = table.Column<bool>(type: "boolean", nullable: false),
                    vel_nbvente = table.Column<int>(type: "integer", nullable: false),
                    vel_qualitevelo = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Velo", x => x.vel_id);
                    table.ForeignKey(
                        name: "FK_CategorieVelo_Velo",
                        column: x => x.catv_id,
                        principalSchema: "upway",
                        principalTable: "t_e_categorievelo_catv",
                        principalColumn: "catv_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Etat_Velo",
                        column: x => x.eta_id,
                        principalSchema: "upway",
                        principalTable: "t_e_etat_eta",
                        principalColumn: "eta_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Taille_Velo_Max",
                        column: x => x.tle_idtaillemax,
                        principalSchema: "upway",
                        principalTable: "t_e_taille_tle",
                        principalColumn: "tle_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Taille_Velo_Min",
                        column: x => x.tle_idtaillemin,
                        principalSchema: "upway",
                        principalTable: "t_e_taille_tle",
                        principalColumn: "tle_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Velo_Modele",
                        column: x => x.mdl_id,
                        principalSchema: "upway",
                        principalTable: "t_e_modele_mdl",
                        principalColumn: "mdl_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Velo_Produit",
                        column: x => x.pdt_id,
                        principalSchema: "upway",
                        principalTable: "t_e_produit_pdt",
                        principalColumn: "pdt_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_apourphoto_appto",
                schema: "upway",
                columns: table => new
                {
                    appto_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pto_id = table.Column<int>(type: "integer", nullable: false),
                    pdt_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_apourphoto_appto", x => x.appto_id);
                    table.ForeignKey(
                        name: "FK_Photo_A_Pour_Photo",
                        column: x => x.pto_id,
                        principalSchema: "upway",
                        principalTable: "t_e_photo_pto",
                        principalColumn: "pto_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produit_A_Pour_Photo",
                        column: x => x.pdt_id,
                        principalSchema: "upway",
                        principalTable: "t_e_produit_pdt",
                        principalColumn: "pdt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_estenfavoris_eefav",
                schema: "upway",
                columns: table => new
                {
                    eefav_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_id = table.Column<int>(type: "integer", nullable: false),
                    pdt_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_estenfavoris_eefav", x => x.eefav_id);
                    table.ForeignKey(
                        name: "FK_Client_Est_En_Favoris",
                        column: x => x.clt_id,
                        principalSchema: "upway",
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produit_Est_En_Favoris",
                        column: x => x.pdt_id,
                        principalSchema: "upway",
                        principalTable: "t_e_produit_pdt",
                        principalColumn: "pdt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_concerne_crn",
                schema: "upway",
                columns: table => new
                {
                    crn_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    alt_id = table.Column<int>(type: "integer", nullable: true),
                    catv_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_concerne_crn", x => x.crn_id);
                    table.ForeignKey(
                        name: "FK_CategorieVelo_Concerne",
                        column: x => x.catv_id,
                        principalSchema: "upway",
                        principalTable: "t_e_categorievelo_catv",
                        principalColumn: "catv_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_concerne_crn_t_e_alerte_alt_alt_id",
                        column: x => x.alt_id,
                        principalSchema: "upway",
                        principalTable: "t_e_alerte_alt",
                        principalColumn: "alt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_commande_comm",
                schema: "upway",
                columns: table => new
                {
                    comm_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comm_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    codred_id = table.Column<int>(type: "integer", nullable: true),
                    stu_id = table.Column<int>(type: "integer", nullable: false),
                    modexpe_id = table.Column<int>(type: "integer", nullable: false),
                    adr_id = table.Column<int>(type: "integer", nullable: false),
                    btq_id = table.Column<int>(type: "integer", nullable: true),
                    adr_idfactu = table.Column<int>(type: "integer", nullable: true),
                    mpay_id = table.Column<int>(type: "integer", nullable: false),
                    clt_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commande", x => x.comm_id);
                    table.ForeignKey(
                        name: "FK_Boutique_Commande",
                        column: x => x.btq_id,
                        principalSchema: "upway",
                        principalTable: "t_e_boutique_btq",
                        principalColumn: "btq_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CodeReduc_Commande",
                        column: x => x.codred_id,
                        principalSchema: "upway",
                        principalTable: "t_e_codereduc_codred",
                        principalColumn: "codred_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commande_Adresse",
                        column: x => x.adr_id,
                        principalSchema: "upway",
                        principalTable: "t_e_adresse_adr",
                        principalColumn: "adr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commande_AdresseFactu",
                        column: x => x.adr_idfactu,
                        principalSchema: "upway",
                        principalTable: "t_e_adresse_adr",
                        principalColumn: "adr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commande_Client",
                        column: x => x.clt_id,
                        principalSchema: "upway",
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModeExpedition_Commande",
                        column: x => x.modexpe_id,
                        principalSchema: "upway",
                        principalTable: "t_e_modeexpedition_modexpe",
                        principalColumn: "modexpe_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModePayement_Commande",
                        column: x => x.mpay_id,
                        principalSchema: "upway",
                        principalTable: "t_e_modepayement_mpay",
                        principalColumn: "mpay_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statut_Commande",
                        column: x => x.stu_id,
                        principalSchema: "upway",
                        principalTable: "t_e_statut_stu",
                        principalColumn: "stu_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_estcaracterise_estcaract",
                schema: "upway",
                columns: table => new
                {
                    estcaract_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    caract_id = table.Column<int>(type: "integer", nullable: false),
                    vel_id = table.Column<int>(type: "integer", nullable: false),
                    estcaract_valeurcaracteristique = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_estcaracterise_estcaract", x => x.estcaract_id);
                    table.ForeignKey(
                        name: "FK_t_e_estcaracterise_estcaract_t_e_caracteristique_caract_car~",
                        column: x => x.caract_id,
                        principalSchema: "upway",
                        principalTable: "t_e_caracteristique_caract",
                        principalColumn: "caract_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_estcaracterise_estcaract_t_e_velo_vel_vel_id",
                        column: x => x.vel_id,
                        principalSchema: "upway",
                        principalTable: "t_e_velo_vel",
                        principalColumn: "vel_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_rapportinspection_rapinsp",
                schema: "upway",
                columns: table => new
                {
                    rapinsp_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vel_id = table.Column<int>(type: "integer", nullable: false),
                    rapinsp_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rapinsp_centre = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    rapinsp_historique = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    rapinsp_commentaire = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_rapportinspection_rapinsp", x => x.rapinsp_id);
                    table.ForeignKey(
                        name: "FK_Velo_RapportInspection",
                        column: x => x.vel_id,
                        principalSchema: "upway",
                        principalTable: "t_e_velo_vel",
                        principalColumn: "vel_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_estcompose_estcomp",
                schema: "upway",
                columns: table => new
                {
                    estcomp_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vel_id = table.Column<int>(type: "integer", nullable: false),
                    mtr_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_estcompose_estcomp", x => x.estcomp_id);
                    table.ForeignKey(
                        name: "FK_Moteur_Est_Compose",
                        column: x => x.mtr_id,
                        principalSchema: "upway",
                        principalTable: "t_e_moteur_mtr",
                        principalColumn: "mtr_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_estcompose_estcomp_t_e_velo_vel_vel_id",
                        column: x => x.vel_id,
                        principalSchema: "upway",
                        principalTable: "t_e_velo_vel",
                        principalColumn: "vel_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_peutetreteste_petest",
                schema: "upway",
                columns: table => new
                {
                    petest_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vel_id = table.Column<int>(type: "integer", nullable: false),
                    btq_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_peutetreteste_petest", x => x.petest_id);
                    table.ForeignKey(
                        name: "FK_t_j_peutetreteste_petest_t_e_boutique_btq_btq_id",
                        column: x => x.btq_id,
                        principalSchema: "upway",
                        principalTable: "t_e_boutique_btq",
                        principalColumn: "btq_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_peutetreteste_petest_t_e_velo_vel_vel_id",
                        column: x => x.vel_id,
                        principalSchema: "upway",
                        principalTable: "t_e_velo_vel",
                        principalColumn: "vel_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_possede_poss",
                schema: "upway",
                columns: table => new
                {
                    poss_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scat_id = table.Column<int>(type: "integer", nullable: false),
                    vel_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_possede_poss", x => x.poss_id);
                    table.ForeignKey(
                        name: "FK_t_j_possede_poss_t_e_souscategorie_scat_scat_id",
                        column: x => x.scat_id,
                        principalSchema: "upway",
                        principalTable: "t_e_souscategorie_scat",
                        principalColumn: "scat_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_possede_poss_t_e_velo_vel_vel_id",
                        column: x => x.vel_id,
                        principalSchema: "upway",
                        principalTable: "t_e_velo_vel",
                        principalColumn: "vel_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_estmispanieraccessoire_empanacc",
                schema: "upway",
                columns: table => new
                {
                    empanacc_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    acce_id = table.Column<int>(type: "integer", nullable: false),
                    comm_id = table.Column<int>(type: "integer", nullable: false),
                    empanacc_quantite = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_estmispanieraccessoire_empanacc", x => x.empanacc_id);
                    table.ForeignKey(
                        name: "FK_t_j_estmispanieraccessoire_empanacc_t_e_accessoire_acce_acc~",
                        column: x => x.acce_id,
                        principalSchema: "upway",
                        principalTable: "t_e_accessoire_acce",
                        principalColumn: "acce_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_estmispanieraccessoire_empanacc_t_e_commande_comm_comm_~",
                        column: x => x.comm_id,
                        principalSchema: "upway",
                        principalTable: "t_e_commande_comm",
                        principalColumn: "comm_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_estmispaniervelo_empanvel",
                schema: "upway",
                columns: table => new
                {
                    empanvel_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vel_id = table.Column<int>(type: "integer", nullable: false),
                    comm_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_estmispaniervelo_empanvel", x => x.empanvel_id);
                    table.ForeignKey(
                        name: "FK_t_j_estmispaniervelo_empanvel_t_e_commande_comm_comm_id",
                        column: x => x.comm_id,
                        principalSchema: "upway",
                        principalTable: "t_e_commande_comm",
                        principalColumn: "comm_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_estmispaniervelo_empanvel_t_e_velo_vel_vel_id",
                        column: x => x.vel_id,
                        principalSchema: "upway",
                        principalTable: "t_e_velo_vel",
                        principalColumn: "vel_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_estproposesimilaire_estpropsim",
                schema: "upway",
                columns: table => new
                {
                    estpropsim_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    acce_id = table.Column<int>(type: "integer", nullable: false),
                    comm_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_estproposesimilaire_estpropsim", x => x.estpropsim_id);
                    table.ForeignKey(
                        name: "FK_t_j_estproposesimilaire_estpropsim_t_e_accessoire_acce_acce~",
                        column: x => x.acce_id,
                        principalSchema: "upway",
                        principalTable: "t_e_accessoire_acce",
                        principalColumn: "acce_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_estproposesimilaire_estpropsim_t_e_commande_comm_comm_id",
                        column: x => x.comm_id,
                        principalSchema: "upway",
                        principalTable: "t_e_commande_comm",
                        principalColumn: "comm_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_proposeassur_propassur",
                schema: "upway",
                columns: table => new
                {
                    propassur_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    assur_id = table.Column<int>(type: "integer", nullable: false),
                    comm_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_proposeassur_propassur", x => x.propassur_id);
                    table.ForeignKey(
                        name: "FK_t_j_proposeassur_propassur_t_e_assurance_assur_assur_id",
                        column: x => x.assur_id,
                        principalSchema: "upway",
                        principalTable: "t_e_assurance_assur",
                        principalColumn: "assur_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_proposeassur_propassur_t_e_commande_comm_comm_id",
                        column: x => x.comm_id,
                        principalSchema: "upway",
                        principalTable: "t_e_commande_comm",
                        principalColumn: "comm_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_valide_val",
                schema: "upway",
                columns: table => new
                {
                    val_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rapinsp_id = table.Column<int>(type: "integer", nullable: false),
                    typ_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_valide_val", x => x.val_id);
                    table.ForeignKey(
                        name: "FK_Type_Valide",
                        column: x => x.typ_id,
                        principalSchema: "upway",
                        principalTable: "t_e_type_typ",
                        principalColumn: "typ_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_valide_val_t_e_rapportinspection_rapinsp_rapinsp_id",
                        column: x => x.rapinsp_id,
                        principalSchema: "upway",
                        principalTable: "t_e_rapportinspection_rapinsp",
                        principalColumn: "rapinsp_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_accessoire_acce_cata_id",
                schema: "upway",
                table: "t_e_accessoire_acce",
                column: "cata_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_accessoire_acce_pdt_id",
                schema: "upway",
                table: "t_e_accessoire_acce",
                column: "pdt_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_adresse_adr_pays_id",
                schema: "upway",
                table: "t_e_adresse_adr",
                column: "pays_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_alerte_alt_clt_id",
                schema: "upway",
                table: "t_e_alerte_alt",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_alerte_alt_tle_id",
                schema: "upway",
                table: "t_e_alerte_alt",
                column: "tle_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_boutique_btq_adr_id",
                schema: "upway",
                table: "t_e_boutique_btq",
                column: "adr_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_caracteristique_caract_scat_id",
                schema: "upway",
                table: "t_e_caracteristique_caract",
                column: "scat_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_client_clt_fn_id",
                schema: "upway",
                table: "t_e_client_clt",
                column: "fn_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_comm_adr_id",
                schema: "upway",
                table: "t_e_commande_comm",
                column: "adr_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_comm_adr_idfactu",
                schema: "upway",
                table: "t_e_commande_comm",
                column: "adr_idfactu");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_comm_btq_id",
                schema: "upway",
                table: "t_e_commande_comm",
                column: "btq_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_comm_clt_id",
                schema: "upway",
                table: "t_e_commande_comm",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_comm_codred_id",
                schema: "upway",
                table: "t_e_commande_comm",
                column: "codred_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_comm_modexpe_id",
                schema: "upway",
                table: "t_e_commande_comm",
                column: "modexpe_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_comm_mpay_id",
                schema: "upway",
                table: "t_e_commande_comm",
                column: "mpay_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_comm_stu_id",
                schema: "upway",
                table: "t_e_commande_comm",
                column: "stu_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_estcaracterise_estcaract_caract_id",
                schema: "upway",
                table: "t_e_estcaracterise_estcaract",
                column: "caract_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_estcaracterise_estcaract_vel_id",
                schema: "upway",
                table: "t_e_estcaracterise_estcaract",
                column: "vel_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_modele_mdl_MarqueIdMarque",
                schema: "upway",
                table: "t_e_modele_mdl",
                column: "MarqueIdMarque");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_modele_mdl_mrq_id",
                schema: "upway",
                table: "t_e_modele_mdl",
                column: "mrq_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_produit_pdt_mrq_id",
                schema: "upway",
                table: "t_e_produit_pdt",
                column: "mrq_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_produit_pdt_pto_id",
                schema: "upway",
                table: "t_e_produit_pdt",
                column: "pto_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_rapportinspection_rapinsp_vel_id",
                schema: "upway",
                table: "t_e_rapportinspection_rapinsp",
                column: "vel_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_surtype_srtyp_styp_id",
                schema: "upway",
                table: "t_e_surtype_srtyp",
                column: "styp_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_velo_vel_catv_id",
                schema: "upway",
                table: "t_e_velo_vel",
                column: "catv_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_velo_vel_eta_id",
                schema: "upway",
                table: "t_e_velo_vel",
                column: "eta_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_velo_vel_mdl_id",
                schema: "upway",
                table: "t_e_velo_vel",
                column: "mdl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_velo_vel_pdt_id",
                schema: "upway",
                table: "t_e_velo_vel",
                column: "pdt_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_velo_vel_tle_idtaillemax",
                schema: "upway",
                table: "t_e_velo_vel",
                column: "tle_idtaillemax");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_velo_vel_tle_idtaillemin",
                schema: "upway",
                table: "t_e_velo_vel",
                column: "tle_idtaillemin");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_apourphoto_appto_pdt_id",
                schema: "upway",
                table: "t_j_apourphoto_appto",
                column: "pdt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_apourphoto_appto_pto_id",
                schema: "upway",
                table: "t_j_apourphoto_appto",
                column: "pto_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_j_concerne_crn_alt_id",
                schema: "upway",
                table: "t_j_concerne_crn",
                column: "alt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_concerne_crn_catv_id",
                schema: "upway",
                table: "t_j_concerne_crn",
                column: "catv_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_contient_ctn_styp_id",
                schema: "upway",
                table: "t_j_contient_ctn",
                column: "styp_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_contient_ctn_typ_id",
                schema: "upway",
                table: "t_j_contient_ctn",
                column: "typ_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_estcompose_estcomp_mtr_id",
                schema: "upway",
                table: "t_j_estcompose_estcomp",
                column: "mtr_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_estcompose_estcomp_vel_id",
                schema: "upway",
                table: "t_j_estcompose_estcomp",
                column: "vel_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_estdemodelem_edmdlm_mdl_id",
                schema: "upway",
                table: "t_j_estdemodelem_edmdlm",
                column: "mdl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_estdemodelem_edmdlm_mtr_id",
                schema: "upway",
                table: "t_j_estdemodelem_edmdlm",
                column: "mtr_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_estenfavoris_eefav_clt_id",
                schema: "upway",
                table: "t_j_estenfavoris_eefav",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_estenfavoris_eefav_pdt_id",
                schema: "upway",
                table: "t_j_estenfavoris_eefav",
                column: "pdt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_estmispanieraccessoire_empanacc_acce_id",
                schema: "upway",
                table: "t_j_estmispanieraccessoire_empanacc",
                column: "acce_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_estmispanieraccessoire_empanacc_comm_id",
                schema: "upway",
                table: "t_j_estmispanieraccessoire_empanacc",
                column: "comm_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_estmispaniervelo_empanvel_comm_id",
                schema: "upway",
                table: "t_j_estmispaniervelo_empanvel",
                column: "comm_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_estmispaniervelo_empanvel_vel_id",
                schema: "upway",
                table: "t_j_estmispaniervelo_empanvel",
                column: "vel_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_estproposesimilaire_estpropsim_acce_id",
                schema: "upway",
                table: "t_j_estproposesimilaire_estpropsim",
                column: "acce_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_estproposesimilaire_estpropsim_comm_id",
                schema: "upway",
                table: "t_j_estproposesimilaire_estpropsim",
                column: "comm_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_habite_hab_adr_id",
                schema: "upway",
                table: "t_j_habite_hab",
                column: "adr_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_habite_hab_clt_id",
                schema: "upway",
                table: "t_j_habite_hab",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_peutetreteste_petest_btq_id",
                schema: "upway",
                table: "t_j_peutetreteste_petest",
                column: "btq_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_peutetreteste_petest_vel_id",
                schema: "upway",
                table: "t_j_peutetreteste_petest",
                column: "vel_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_possede_poss_scat_id",
                schema: "upway",
                table: "t_j_possede_poss",
                column: "scat_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_possede_poss_vel_id",
                schema: "upway",
                table: "t_j_possede_poss",
                column: "vel_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_proposeassur_propassur_assur_id",
                schema: "upway",
                table: "t_j_proposeassur_propassur",
                column: "assur_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_proposeassur_propassur_comm_id",
                schema: "upway",
                table: "t_j_proposeassur_propassur",
                column: "comm_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_valide_val_rapinsp_id",
                schema: "upway",
                table: "t_j_valide_val",
                column: "rapinsp_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_valide_val_typ_id",
                schema: "upway",
                table: "t_j_valide_val",
                column: "typ_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_estcaracterise_estcaract",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_surtype_srtyp",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_j_apourphoto_appto",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_j_concerne_crn",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_j_contient_ctn",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_j_estcompose_estcomp",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_j_estdemodelem_edmdlm",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_j_estenfavoris_eefav",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_j_estmispanieraccessoire_empanacc",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_j_estmispaniervelo_empanvel",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_j_estproposesimilaire_estpropsim",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_j_habite_hab",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_j_peutetreteste_petest",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_j_possede_poss",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_j_proposeassur_propassur",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_j_valide_val",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_caracteristique_caract",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_alerte_alt",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_soustype_styp",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_moteur_mtr",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_accessoire_acce",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_assurance_assur",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_commande_comm",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_type_typ",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_rapportinspection_rapinsp",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_souscategorie_scat",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_categorieaccessoire_cata",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_boutique_btq",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_codereduc_codred",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_client_clt",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_modeexpedition_modexpe",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_modepayement_mpay",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_statut_stu",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_velo_vel",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_adresse_adr",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_fonction_fn",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_categorievelo_catv",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_etat_eta",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_taille_tle",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_modele_mdl",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_produit_pdt",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_pays_pays",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_marque_mrq",
                schema: "upway");

            migrationBuilder.DropTable(
                name: "t_e_photo_pto",
                schema: "upway");
        }
    }
}
