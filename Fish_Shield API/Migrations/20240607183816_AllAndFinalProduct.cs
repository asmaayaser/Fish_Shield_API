using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fish_Shield_API.Migrations
{
    /// <inheritdoc />
    public partial class AllAndFinalProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonalPhoto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isPaid = table.Column<bool>(type: "bit", nullable: true),
                    SubscriptionEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HasFreeTrialCount = table.Column<byte>(type: "tinyint", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: true),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoreInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FarmAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FishDiseases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishDiseases", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Equipments_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ownerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_ownerId",
                        column: x => x.ownerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripePaymentRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StripeSessionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripePaymentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripePaymentRecords_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CausativeAgents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseID = table.Column<int>(type: "int", nullable: false),
                    Agents = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CausativeAgents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CausativeAgents_FishDiseases_DiseaseID",
                        column: x => x.DiseaseID,
                        principalTable: "FishDiseases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClinicalSigns",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseID = table.Column<int>(type: "int", nullable: false),
                    Sign = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalSigns", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClinicalSigns_FishDiseases_DiseaseID",
                        column: x => x.DiseaseID,
                        principalTable: "FishDiseases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameOfDisFromAIModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false),
                    DiseaseId = table.Column<int>(type: "int", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detects_FishDiseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "FishDiseases",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseID = table.Column<int>(type: "int", nullable: false),
                    Diagones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Diagnosis_FishDiseases_DiseaseID",
                        column: x => x.DiseaseID,
                        principalTable: "FishDiseases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImpactOnAquaculture",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseID = table.Column<int>(type: "int", nullable: false),
                    ImpactOnAquaculturee = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpactOnAquaculture", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImpactOnAquaculture_FishDiseases_DiseaseID",
                        column: x => x.DiseaseID,
                        principalTable: "FishDiseases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreventionAndControll",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseID = table.Column<int>(type: "int", nullable: false),
                    Prevention = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreventionAndControll", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PreventionAndControll_FishDiseases_DiseaseID",
                        column: x => x.DiseaseID,
                        principalTable: "FishDiseases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecommandationActions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseID = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommandationActions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecommandationActions_FishDiseases_DiseaseID",
                        column: x => x.DiseaseID,
                        principalTable: "FishDiseases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseID = table.Column<int>(type: "int", nullable: false),
                    TreatmentDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Treatment_FishDiseases_DiseaseID",
                        column: x => x.DiseaseID,
                        principalTable: "FishDiseases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00130047-1c96-4729-a703-f227aebc419d", null, "Doctor", "DOCTOR" },
                    { "85705ba5-ec88-4881-8d2c-eb7ce123fabe", null, "Admin", "ADMIN" },
                    { "f54b86f6-3893-4d64-bfe9-23355b48083d", null, "FarmOwner", "FARMOWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "BirthDate", "Code", "ConcurrencyStamp", "Disabled", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalPhoto", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "90e579bd-33cd-4479-b311-c07e13c5901d", 0, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "1438a72d-7c6d-41b8-aa5c-ad1943661e7c", false, "Admin", null, false, false, null, null, null, "admin", null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7d42d9be-02f9-4c33-8e3d-0928572255ce", false, "admin", false });

            migrationBuilder.InsertData(
                table: "FishDiseases",
                columns: new[] { "ID", "Description", "Name", "PhotoPath", "Type" },
                values: new object[,]
                {
                    { 1, "Streptococcosis is a systemic bacterial infection affecting tilapia, primarily caused by Streptococcus iniae. It poses a significant threat to tilapia aquaculture globally, leading to morbidity and mortality in affected populations.", "Streptococcosis Disease", "https://localhost:7289/images/Detects/1.jpg", "Bacterial Disease" },
                    { 2, "Epizootic Ulcerative Syndrome (EUS) is a devastating infectious disease that primarily affects freshwater and estuarine fish species. It is caused by the fungus Aphanomyces invadans. EUS is characterized by the development of ulcerative lesions on the skin and fins of affected fish, which can lead to tissue necrosis and systemic infection. The disease is often associated with warm water temperatures and environmental stressors. EUS outbreaks can result in high mortality rates, significant economic losses for aquaculture operations, and ecological impacts on wild fish populations.", "EUS Disease", "https://localhost:7289/images/Detects/2.jpg", "Fungal disease" },
                    { 3, "Columnaris disease, also known as cotton wool disease or saddleback disease, is a common bacterial infection affecting tilapia. It is caused by the bacterium Flavobacterium columnare. Columnaris disease typically presents as a systemic infection, primarily affecting the skin and gills of tilapia, although it can also impact other organs.", "Columnaris Disease", "https://localhost:7289/images/Detects/3.jpg", "Bacterial Disease" },
                    { 4, "(BGD) is a common external infection of hatchery reared salmonids and occasionally of warm water species reared under intensive conditions. As defined by Wood (1974), the name of the disease describes the clinical signs of bacterial infections on the gills. The etiological agent of the disease is considered to be one or more species of filamentous bacteria including Flavobacterium sp. as most recently described by Wakabayashi et al. (1980). BGD is characterized by the presence of large numbers of filamentous bacteria on the gills accompanied by fusing and clubbing of the gill filaments. Acute or chronic forms of the disease may occur and acute outbreaks may involve daily mortality rates approaching 20% (Warren 1981). The onset of bacterial gill disease usually follows a deterioration of environmental conditions associated with overcrowding and increases in toxic metabolic waste products. According to Wood (1979), fish smaller than 90-100/lb are most susceptible to the disease. Successful treatment can only be accomplished through prompt therapy and alleviation of poor environmental conditions.", "Gill Disease", "https://localhost:7289/images/Detects/4.jpg", "bacterial, viral, or parasitic Disease" }
                });

            migrationBuilder.InsertData(
                table: "CausativeAgents",
                columns: new[] { "ID", "Agents", "DiseaseID" },
                values: new object[,]
                {
                    { 1, "Identification: Streptococcus iniae is isolated and identified as the primary pathogen causing streptococcosis in tilapia.", 1 },
                    { 2, "Characterization: Its morphological, biochemical, and molecular properties are examined to confirm its identity.", 1 },
                    { 3, "Virulence Factors: S. iniae possesses adhesion proteins, enzymes, and toxins that contribute to its ability to infect and cause disease in tilapia.", 1 },
                    { 4, "Host-Pathogen Interaction: The bacterium infects tilapia through breaches in the skin or mucosal surfaces, colonizing tissues and evading immune defenses.", 1 },
                    { 5, "Disease Manifestation: Infection leads to streptococcosis, resulting in systemic dissemination and clinical signs in affected tilapia.", 1 },
                    { 6, "EUS is caused by Aphanomyces invadans , a fungus belonging to Saprolegniales, Oomycetida, and is classified in Stramenopiles or Chromista along with diatoms and brown algae. Disinfection of infected fish pond by hydrated lime and addition of salt to inhibit the fungus has been used in EUS outbreaks", 2 },
                    { 7, "Bacterial Pathogen: Flavobacterium columnare is the causative agent of Columnaris disease in tilapia.", 3 },
                    { 8, "Gram-Negative Bacterium: It is a Gram-negative bacterium commonly found in freshwater environments.", 3 },
                    { 9, "Characteristic Appearance: F. columnare forms slimy colonies resembling columns, hence the name \"Columnaris.\"", 3 },
                    { 10, "Skin and Gill Affliction: It primarily affects the skin and gills of tilapia, causing white or grayish patches resembling cotton wool.", 3 },
                    { 11, "Bacterial gill disease typically occurs as a result of poor living conditions, such as overcrowding, poor water quality, high organic debris, increased temperature of the water, and increased ammonia levels. While it is most often the young and/or weak fish that contract the disease, due to their vulnerable immune systems, gill disease can affect fish of any age.", 4 },
                    { 12, "The bacteria that cause gill infections are primarily Flavobacteria, Aeromonas and Pseudomonas spp. The direct initiating cause by these bacteria is not conclusive, but they will often be found as secondary, opportunistic infections.", 4 }
                });

            migrationBuilder.InsertData(
                table: "ClinicalSigns",
                columns: new[] { "ID", "DiseaseID", "Sign" },
                values: new object[,]
                {
                    { 1, 1, "Lethargy and reduced activity levels." },
                    { 2, 1, "Loss of appetite and reduced feeding behavior." },
                    { 3, 1, "Skin lesions, including ulcers, reddening, and hemorrhages." },
                    { 4, 1, "Pop-eye (exophthalmia) due to eye swelling." },
                    { 5, 1, "Abnormal swimming behavior and respiratory distress." },
                    { 6, 2, "Fish usually develop red spots or small to large ulcerative lesions on the body. The early signs of the disease include loss of appetite and fish become darker. Infected fish may float near the surface of the water, and become hyperactive with a very jerky pattern of movement" },
                    { 7, 3, "White or grayish patches resembling cotton wool on the skin, fins, and gills." },
                    { 8, 3, "Ulcerations and lesions on the skin, often accompanied by inflammation." },
                    { 9, 3, "Loss of scales and fin rot." },
                    { 10, 3, "Respiratory distress, including rapid gill movement or gasping at the water surface." },
                    { 11, 3, "Behavioral changes such as lethargy and loss of appetite." },
                    { 12, 4, "Bacterial Gill Disease will attack your fish's gills, causing them to rot and erode. This will make it harder for your fish to breath, so you may see it gasping for air at the water surface or rapid gill movement. Unsurprisingly, your fish will also have little appetite and may be losing weight" }
                });

            migrationBuilder.InsertData(
                table: "Diagnosis",
                columns: new[] { "ID", "Diagones", "DiseaseID" },
                values: new object[,]
                {
                    { 1, "Clinical Observation: Identify clinical signs such as lethargy, loss of appetite, skin lesions, pop-eye, and respiratory distress in affected tilapia.", 1 },
                    { 2, "Sample Collection: Collect tissue samples (e.g., liver, spleen) from affected fish for laboratory analysis.", 1 },
                    { 3, "Bacterial Isolation: Isolate Streptococcus bacteria from the tissue samples using appropriate culture techniques.", 1 },
                    { 4, "Confirmation: Confirm the presence of Streptococcus iniae or other relevant species through bacterial identification tests, such as PCR or biochemical assays.", 1 },
                    { 5, "Clinical Examination: Fish displaying symptoms such as ulcerative lesions on the skin and fins are examined closely for characteristic signs of EUS.", 2 },
                    { 6, "Microscopic Analysis: Samples of affected tissue, such as skin or fin lesions, are collected and examined under a microscope to identify the presence of Aphanomyces invadans, the fungus responsible for EUS.\r\n", 2 },
                    { 7, "Culture and Molecular Techniques: The fungus can be cultured from tissue samples to confirm its presence and identify its characteristics. Molecular techniques such as PCR (polymerase chain reaction) may also be employed for more rapid and specific detection of Aphanomyces invadans DNA.", 2 },
                    { 8, "Histopathology: Histopathological examination of tissue samples can provide additional insights into the extent of tissue damage and the inflammatory response associated with EUS.", 2 },
                    { 9, "Clinical Examination: Identify clinical signs such as white or grayish patches resembling cotton wool on the skin, fins, and gills, as well as ulcerations and lesions.", 3 },
                    { 10, "Microscopic Examination: Examine skin and gill smears under a microscope for characteristic bacterial colonies and signs of infection.", 3 },
                    { 11, "Bacterial Culture: Perform bacterial culture to isolate and identify Flavobacterium columnare.", 3 },
                    { 12, "Confirmation: Confirm the diagnosis based on clinical signs, microscopic examination, and bacterial culture results.", 3 },
                    { 13, "Diagnosis of bacterial gill disease depends on the detection of large numbers of filamentous bacteria on the gills. Along with the clinical signs described above, this observation represents diagnostic evidence of the disease. there are several forms for diagnosing Bacterial gill disease:", 4 },
                    { 14, "Microscopic Examination: To diagnose gill disease, a microscopic examination of the affected gill tissue is typically performed. The presence of fungal hyphae, spores, or other characteristic structures can confirm the infection. The examination may involve taking a small sample of the gill tissue and staining it for microscopic observation.", 4 },
                    { 15, "Laboratory Culture: In some cases, the pathogenic fungus may need to be cultured in a laboratory setting to confirm the diagnosis. This involves growing the fungus from a sample taken from the affected gills on specific culture media. The growth characteristics and appearance of the cultured fungus can help identify the causative organism.", 4 },
                    { 16, "Differential Diagnosis: Other diseases or conditions can cause similar symptoms to gill disease, so it is essential to consider differential diagnoses. These can include other fungal infections, bacterial infections, parasitic infestations, and environmental factors like poor water quality.", 4 },
                    { 17, "Veterinary Consultation: If gill disease is suspected, it is advisable to consult a veterinarian or fish health professional with experience in aquatic diseases. They can perform the necessary diagnostic tests, provide treatment recommendations, and offer guidance on disease prevention and management.", 4 },
                    { 18, "Early diagnosis and prompt treatment are crucial in managing gill disease. Treatment typically involves antifungal medications, which may be administered orally, through the water, or by injection, depending on the severity of the infection. Additionally, addressing any underlying environmental issues, such as poor water quality or stressors, is essential to prevent disease recurrence.", 4 }
                });

            migrationBuilder.InsertData(
                table: "ImpactOnAquaculture",
                columns: new[] { "ID", "DiseaseID", "ImpactOnAquaculturee" },
                values: new object[,]
                {
                    { 1, 1, "Economic Losses: Streptococcosis outbreaks can lead to high mortality rates in affected fish populations, resulting in economic losses for tilapia farmers. Mortality can occur at any stage of production, from juvenile to market size, affecting both production efficiency and profitability." },
                    { 2, 1, "Reduced Growth Rates: Infected tilapia often exhibit reduced growth rates and poor feed conversion efficiency, leading to prolonged production cycles and decreased marketable sizes. This results in decreased productivity and increased production costs." },
                    { 3, 1, "Treatment Costs: Treating streptococcosis infections in tilapia requires the administration of antibiotics, which adds to production costs. Additionally, repeated use of antibiotics can contribute to the development of antimicrobial resistance, posing long-term challenges for disease management in aquaculture." },
                    { 4, 1, "Market Access Restrictions: Streptococcosis outbreaks may lead to market access restrictions or trade bans on affected tilapia products due to concerns about food safety and public health. This can further exacerbate economic losses for tilapia farmers and impact the reputation of the aquaculture industry." },
                    { 5, 1, "Environmental Impact: Streptococcosis outbreaks can result in increased nutrient loading and microbial contamination in aquaculture systems, potentially leading to environmental degradation and negative impacts on water quality and ecosystem health." },
                    { 6, 2, "Economic Losses: EUS outbreaks can lead to mass mortality events, resulting in substantial financial losses for aquaculture businesses due to the death of fish stocks and reduced production." },
                    { 7, 2, "Production Disruption: Disease outbreaks can disrupt aquaculture production schedules, leading to delays in harvesting or stocking and affecting market supply and demand dynamics." },
                    { 8, 2, "Increased Costs: Controlling and managing EUS outbreaks often require additional expenses for disease treatment, water quality management, and implementing biosecurity measures, increasing overall production costs." },
                    { 9, 2, "Market Perception: Public perception of EUS outbreaks can negatively affect consumer confidence in the safety and quality of farmed fish products, potentially leading to decreased market demand and sales." },
                    { 10, 2, "Regulatory Scrutiny: EUS outbreaks may attract regulatory attention, leading to increased oversight, stricter regulations, and compliance requirements for aquaculture operations, further adding to operational challenges and costs." },
                    { 11, 3, "Economic Losses: Columnaris disease leads to economic losses in tilapia aquaculture due to morbidity, mortality, and treatment costs." },
                    { 12, 3, "Decreased Growth Rates: Infected tilapia exhibit reduced growth rates and poor feed conversion efficiency." },
                    { 13, 3, "Marketability: It can reduce the marketability of infected fish due to skin lesions, fin rot, and other clinical signs." },
                    { 14, 3, "Overall Health Impact: Outbreaks compromise the overall health of tilapia populations, impacting the sustainability of aquaculture operations." },
                    { 15, 3, "Treatment Challenges: Treatment involves antibiotics, adding to production costs and posing challenges due to antimicrobial resistance concerns." },
                    { 16, 4, "Economic Losses: Bacterial gill diseases can lead to high mortality rates among fish populations, resulting in economic losses for aquaculture producers due to decreased yields and potential market losses." },
                    { 17, 4, "Treatment Costs: Treating bacterial gill diseases often requires the use of antibiotics or other medications, which can be costly for aquaculture operations. Additionally, the labor and resources required for disease management further add to production expenses." },
                    { 18, 4, "Environmental Impact: The use of antibiotics and other medications in aquaculture to control bacterial gill diseases can contribute to the development of antibiotic resistance in bacteria, posing risks to human health and the environment." },
                    { 19, 4, "Biosecurity Risks: Bacterial gill diseases can spread rapidly within aquaculture facilities, especially in densely stocked systems. Poor biosecurity practices can further exacerbate disease transmission and impact overall farm health." },
                    { 20, 4, "Market Reputation: Recurrent outbreaks of bacterial gill diseases can damage the reputation of aquaculture producers and their products in the market, leading to decreased consumer confidence and potential market rejection." }
                });

            migrationBuilder.InsertData(
                table: "PreventionAndControll",
                columns: new[] { "ID", "DiseaseID", "Prevention" },
                values: new object[,]
                {
                    { 1, 1, "Quarantine protocols for new fish introductions." },
                    { 2, 1, "Disinfection of equipment and facilities." },
                    { 3, 1, "Minimization of stressors through proper husbandry practices" },
                    { 4, 1, "Implementation of vaccination programs where feasible." },
                    { 5, 1, "Surveillance and early intervention in case of disease outbreaks." },
                    { 6, 2, "Isolation and Screening: Quarantine new fish and screen them for disease." },
                    { 7, 2, "Biosecurity: Tighten facility access and disinfect regularly." },
                    { 8, 2, "Water Quality: Maintain optimal conditions to reduce stress." },
                    { 9, 2, "Stocking and Care: Avoid overcrowding and ensure proper care." },
                    { 10, 2, "Environment: Manage water quality and sediment effectively." },
                    { 11, 2, "Monitoring: Regularly check for pathogens to catch outbreaks early." },
                    { 12, 2, "Vaccination: Support vaccine development for long-term protection." },
                    { 13, 2, "Regulations: Enforce rules to maintain responsible aquaculture practices." },
                    { 14, 3, "Antibiotic Therapy: Administer antibiotics such as florfenicol or oxytetracycline under veterinary supervision." },
                    { 15, 3, "Topical Treatments: Apply topical treatments or baths with antimicrobial agents to affected fish, targeting the infection directly." },
                    { 16, 3, "Supportive Care: Provide supportive care, including maintaining optimal water quality and nutrition, to enhance the fish's immune response and aid in recovery." },
                    { 17, 3, "Quarantine: Isolate infected fish to prevent the spread of the disease to other individuals in the population." },
                    { 18, 3, "Implement early intervention and treatment protocols in case of disease outbreaks." },
                    { 19, 4, "The best way to prevent bacterial gill disease from occurring is by maintaining hygienic living conditions for your fish." },
                    { 20, 4, "Keeping the water clean of organic debris, giving the fish plenty of space in which to move, with no overcrowding" },
                    { 21, 4, "maintaining a consistent temperature" },
                    { 22, 4, "testing the water quality regularly to ensure that it is balanced are all the best practices for keeping your fish healthy and stress free" },
                    { 23, 4, "Additionally, filters should be changed every month or checked according to the filter manufacturer's directions." }
                });

            migrationBuilder.InsertData(
                table: "RecommandationActions",
                columns: new[] { "ID", "Action", "DiseaseID" },
                values: new object[,]
                {
                    { 1, "Biosecurity Measures: Implement strict biosecurity protocols to prevent the introduction and spread of the bacteria.", 1 },
                    { 2, "Water Quality Management: Maintain optimal water quality parameters to reduce stress on tilapia and support their immune function.", 1 },
                    { 3, "Regular Health Monitoring: Conduct routine health assessments to detect early signs of infection and initiate timely interventions.", 1 },
                    { 4, "Vaccination: Utilize available and effective vaccines to confer immunity against Streptococcus iniae.", 1 },
                    { 5, "Prompt Treatment: Diagnose and treat infected fish promptly with appropriate antibiotics under veterinary supervision.", 1 },
                    { 6, "Early Detection: Regular monitoring for signs of EUS, such as ulcerative lesions on the skin and fins, is crucial for early detection and intervention.", 2 },
                    { 7, "Quarantine Measures: Implement quarantine protocols for new fish arrivals to prevent the introduction and spread of EUS to existing populations.", 2 },
                    { 8, "Biosecurity Protocols: Maintain strict biosecurity measures to minimize the risk of EUS transmission between aquaculture facilities and wild fish populations.", 2 },
                    { 9, "Environmental Management: Optimize water quality parameters and minimize environmental stressors to reduce the susceptibility of fish to EUS infection.", 2 },
                    { 10, "Treatment: Investigate and implement appropriate treatment options, such as antifungal medications, under the guidance of a veterinarian or aquatic health professional.", 2 },
                    { 11, "Sanitation: Ensure proper hygiene practices, including disinfection of equipment and facilities, to prevent the buildup and spread of EUS-causing pathogens.", 2 },
                    { 12, "Research and Monitoring: Support ongoing research efforts to better understand the epidemiology and pathogenesis of EUS, and collaborate with relevant agencies for surveillance and monitoring of EUS outbreaks.", 2 },
                    { 13, "Water Quality Management: Maintain optimal water quality parameters to reduce stress on tilapia and minimize the risk of infection.", 3 },
                    { 14, "Biosecurity Measures: Implement strict biosecurity protocols to prevent the introduction and spread of F. columnare in aquaculture systems.", 3 },
                    { 15, "Regular Monitoring: Conduct routine health assessments and monitor fish behavior closely to detect early signs of infection.", 3 },
                    { 16, "Treatment: Administer antimicrobial treatments under veterinary supervision if infections occur.", 3 },
                    { 17, "Stress Reduction: Minimize stressors such as overcrowding, poor nutrition, and environmental fluctuations to enhance tilapia immune function.", 3 },
                    { 18, "Isolation: Separate affected fish from the main population to prevent disease spread.", 4 },
                    { 19, "Water Quality: Maintain optimal water conditions with regular monitoring and adjustments.", 4 },
                    { 20, "Treatment: Administer antibiotics or other medications as directed by a veterinarian.", 4 },
                    { 21, "Stress Reduction: Minimize stressors such as overcrowding and poor water quality.", 4 },
                    { 22, "Quarantine: Quarantine new arrivals to prevent introducing pathogens.", 4 },
                    { 23, "Biosecurity: Implement disinfection and hygiene practices to prevent disease transmission.", 4 },
                    { 24, "Monitoring: Monitor fish closely for changes in behavior and gill condition.", 4 },
                    { 25, "Consultation: Seek advice from experts for diagnosis and treatment guidance.", 4 },
                    { 26, "Prevention: Take preventive measures to avoid future outbreaks.", 4 }
                });

            migrationBuilder.InsertData(
                table: "Treatment",
                columns: new[] { "ID", "DiseaseID", "TreatmentDesc" },
                values: new object[,]
                {
                    { 1, 1, "Antibiotic Therapy: Administer antibiotics effective against Streptococcus bacteria, such as florfenicol or oxytetracycline, following veterinary guidance." },
                    { 2, 1, "Supportive Care: Provide supportive care, including maintaining optimal water quality, nutrition, and minimizing stressors to enhance fish immune function." },
                    { 3, 1, "Topical Treatments: Employ topical treatments or baths with antimicrobial agents to target localized infections, especially for skin lesions." },
                    { 4, 1, "Quarantine: Isolate infected fish to prevent the spread of the disease to other individuals in the population." },
                    { 5, 1, "Monitoring: Monitor the progress of treatment closely and adjust treatment protocols as necessary based on the response of the infected fish" },
                    { 6, 2, "Quarantine and Biosecurity: Infected fish should be isolated to prevent the spread of the disease to healthy populations. Implementing strict biosecurity measures in aquaculture facilities can help prevent the introduction and transmission of EUS." },
                    { 7, 2, "Water Quality Management: Maintaining optimal water quality parameters such as temperature, pH, dissolved oxygen levels, and ammonia concentration can help reduce stress on fish and enhance their immune response to the disease." },
                    { 8, 2, "Antimicrobial Treatment: In cases of severe infection, antimicrobial agents may be used to control secondary bacterial infections and prevent further tissue damage. However, the use of antibiotics should be carefully regulated to prevent the development of antimicrobial resistance." },
                    { 9, 2, "Topical Treatments: Topical treatments such as antiseptic solutions or medicated baths may be applied directly to the ulcerated lesions to promote healing and prevent secondary infections." },
                    { 10, 2, "Supportive Care: Providing appropriate nutrition and minimizing stress through proper husbandry practices can help boost the immune system of infected fish and improve their overall health." },
                    { 11, 2, "Environmental Management: Implementing environmental modifications such as reducing stocking density, improving water circulation, and removing organic debris can create less favorable conditions for the pathogen responsible for EUS." },
                    { 12, 2, "Vaccination: Research into the development of vaccines against EUS-causing pathogens is ongoing. Vaccination of susceptible fish populations may offer long-term protection against the disease." },
                    { 13, 3, "Antibiotic Therapy: Administer antibiotics effective against Streptococcus bacteria, such as florfenicol or oxytetracycline, following veterinary guidance." },
                    { 14, 3, "Supportive Care: Provide supportive care, including maintaining optimal water quality, nutrition, and minimizing stressors to enhance fish immune function." },
                    { 15, 3, "Topical Treatments: Employ topical treatments or baths with antimicrobial agents to target localized infections, especially for skin lesions." },
                    { 16, 3, "Quarantine: Isolate infected fish to prevent the spread of the disease to other individuals in the population." },
                    { 17, 3, "Monitoring: Monitor the progress of treatment closely and adjust treatment protocols as necessary based on the response of the infected fish" },
                    { 18, 4, "Bacterial gill disease must first be treated with a change in the living conditions of the fish. If they are crowded, they will need to be given more space, either in a larger aquarium, or separated into different aquariums. The cleanliness of the water and aquarium is paramount. A treatment of potassium permanganate and salt water additives can be used to help the fish heal and recover from the infection. The amount of salt you will use will depend upon the species you are treating, but it must be a salt that is specifically made for fish water, and it should only be in the prescribed amount. Antibiotic therapy may be used to treat secondary bacterial infections." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CausativeAgents_DiseaseID",
                table: "CausativeAgents",
                column: "DiseaseID");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalSigns_DiseaseID",
                table: "ClinicalSigns",
                column: "DiseaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Detects_DiseaseId",
                table: "Detects",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Detects_UserId",
                table: "Detects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_DiseaseID",
                table: "Diagnosis",
                column: "DiseaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_OwnerId",
                table: "Equipments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FishDiseases_Name",
                table: "FishDiseases",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ImpactOnAquaculture_DiseaseID",
                table: "ImpactOnAquaculture",
                column: "DiseaseID");

            migrationBuilder.CreateIndex(
                name: "IX_PreventionAndControll_DiseaseID",
                table: "PreventionAndControll",
                column: "DiseaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_DoctorId",
                table: "Ratings",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ownerId",
                table: "Ratings",
                column: "ownerId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommandationActions_DiseaseID",
                table: "RecommandationActions",
                column: "DiseaseID");

            migrationBuilder.CreateIndex(
                name: "IX_StripePaymentRecords_OwnerId",
                table: "StripePaymentRecords",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_DiseaseID",
                table: "Treatment",
                column: "DiseaseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CausativeAgents");

            migrationBuilder.DropTable(
                name: "ClinicalSigns");

            migrationBuilder.DropTable(
                name: "Detects");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "ImpactOnAquaculture");

            migrationBuilder.DropTable(
                name: "PreventionAndControll");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "RecommandationActions");

            migrationBuilder.DropTable(
                name: "StripePaymentRecords");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FishDiseases");
        }
    }
}
