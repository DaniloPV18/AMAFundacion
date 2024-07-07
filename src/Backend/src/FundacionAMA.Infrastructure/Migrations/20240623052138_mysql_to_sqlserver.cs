using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FundacionAMA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_to_sqlserver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nchar(60)", fixedLength: true, maxLength: 60, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIdentificacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationVolunteer",
                columns: table => new
                {
                    volunteer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    donor_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    lastname = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    gender = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    address = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    telephone = table.Column<int>(type: "int", nullable: true),
                    mail = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    availability = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    start_date = table.Column<DateTime>(type: "date", nullable: true),
                    end_date = table.Column<DateTime>(type: "date", nullable: true),
                    activity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Registra__0FE766B10C1C8324", x => x.volunteer_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identification = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    TempCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempCodeCreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmtpConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Profile = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Authenticate = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmtpConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmtpConfigurations_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultVolunteers",
                columns: table => new
                {
                    consult = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    volunteer_id = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ConsultV__ACEE1F39D2C73D2A", x => x.consult);
                    table.ForeignKey(
                        name: "FK__ConsultVo__volun__70DDC3D8",
                        column: x => x.volunteer_id,
                        principalTable: "RegistrationVolunteer",
                        principalColumn: "volunteer_id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => new { x.UserId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameCompleted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationTypeId = table.Column<short>(type: "smallint", nullable: true),
                    Identification = table.Column<string>(type: "varchar(22)", unicode: false, maxLength: 22, nullable: false),
                    Phone = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Volunteer = table.Column<bool>(type: "bit", nullable: false),
                    Donor = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSON_ID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_IdentificationType",
                        column: x => x.IdentificationTypeId,
                        principalTable: "IdentificationType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persons_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Persons",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Brigades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Start = table.Column<DateTime>(type: "date", nullable: false),
                    End = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brigade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brigades_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Brigades_Persons",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_Donors",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    Address = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Volunteers_ActivityType",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Volunteers_Persons",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BrigadeBeneficiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", fixedLength: true, maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrigadeId = table.Column<int>(type: "int", nullable: false),
                    BeneficiaryId = table.Column<int>(type: "int", nullable: false),
                    BeneficiaryTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrigadeBeneficiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrigadeBeneficiaries_Beneficiaries",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_BrigadeBeneficiaries_BeneficiaryType",
                        column: x => x.BeneficiaryTypeId,
                        principalTable: "BeneficiaryType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BrigadeBeneficiaries_Brigades",
                        column: x => x.BrigadeId,
                        principalTable: "Brigades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(60)", fixedLength: true, maxLength: 60, nullable: true),
                    DonationTypeId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    BrigadeId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    AssignedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DONATION_ID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_Brigades",
                        column: x => x.BrigadeId,
                        principalTable: "Brigades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Donations_DonationType",
                        column: x => x.DonationTypeId,
                        principalTable: "DonationType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Donations_Donors",
                        column: x => x.PersonId,
                        principalTable: "Donors",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "BrigadeVoluntareers",
                columns: table => new
                {
                    BrigadeId = table.Column<int>(type: "int", nullable: false),
                    VolunteerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrigadeVoluntareers", x => new { x.BrigadeId, x.VolunteerId });
                    table.ForeignKey(
                        name: "FK_BrigadeVoluntareers_Brigades",
                        column: x => x.BrigadeId,
                        principalTable: "Brigades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BrigadeVoluntareers_Volunteers",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "PersonId");
                });

            migrationBuilder.InsertData(
                table: "ActivityType",
                columns: new[] { "Id", "Active", "CompanyId", "CreatedAt", "CreatedBy", "Name", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, true, null, new DateTime(2024, 6, 23, 0, 21, 38, 398, DateTimeKind.Local).AddTicks(550), 0, "PRUEBA DE ACTIVIDAD", "A", null, null });

            migrationBuilder.InsertData(
                table: "DonationType",
                columns: new[] { "Id", "Active", "CompanyId", "CreatedAt", "CreatedBy", "Name", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2024, 6, 23, 0, 21, 38, 401, DateTimeKind.Local).AddTicks(9490), 0, "viveres", "A", null, null },
                    { 2, true, null, new DateTime(2024, 6, 23, 0, 21, 38, 401, DateTimeKind.Local).AddTicks(9505), 0, "medicina", "A", null, null },
                    { 3, true, null, new DateTime(2024, 6, 23, 0, 21, 38, 401, DateTimeKind.Local).AddTicks(9507), 0, "vestimenta", "A", null, null },
                    { 4, true, null, new DateTime(2024, 6, 23, 0, 21, 38, 401, DateTimeKind.Local).AddTicks(9509), 0, "monetario", "A", null, null },
                    { 5, true, null, new DateTime(2024, 6, 23, 0, 21, 38, 401, DateTimeKind.Local).AddTicks(9510), 0, "tecnologia", "A", null, null },
                    { 6, true, null, new DateTime(2024, 6, 23, 0, 21, 38, 401, DateTimeKind.Local).AddTicks(9511), 0, "suministros", "A", null, null },
                    { 7, true, null, new DateTime(2024, 6, 23, 0, 21, 38, 401, DateTimeKind.Local).AddTicks(9512), 0, "varios", "A", null, null }
                });

            migrationBuilder.InsertData(
                table: "IdentificationType",
                columns: new[] { "Id", "Active", "Code", "CompanyId", "CreatedAt", "CreatedBy", "Description", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { (short)1, true, "CC", null, new DateTime(2024, 6, 23, 0, 21, 38, 402, DateTimeKind.Local).AddTicks(6654), 0, "Cédula de ciudadanía", "A", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "Email", "Identification", "Name", "Password", "Salt", "Status", "TempCode", "TempCodeCreateAt", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, false, new DateTime(2024, 6, 23, 0, 21, 38, 404, DateTimeKind.Local).AddTicks(3513), 0, "system@email.com", "9999999999999", "System", "hx7w741jRKptsZJYyBjLQfz4agjKMGEJoK0kVwbbthI=", "UhfyKxRscxd78Aoj0WOzigBOnis+fUNtHEc8kfQkOCg=", "A", "809dd305-a6ff-4581-8d57-1739e00c0894", null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_BrigadeBeneficiaries_BeneficiaryId",
                table: "BrigadeBeneficiaries",
                column: "BeneficiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_BrigadeBeneficiaries_BeneficiaryTypeId",
                table: "BrigadeBeneficiaries",
                column: "BeneficiaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BrigadeBeneficiaries_BrigadeId",
                table: "BrigadeBeneficiaries",
                column: "BrigadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Brigades_CompanyId",
                table: "Brigades",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Brigades_PersonId",
                table: "Brigades",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BrigadeVoluntareers_VolunteerId",
                table: "BrigadeVoluntareers",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_CompanyId",
                table: "CompanyUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultVolunteers_volunteer_id",
                table: "ConsultVolunteers",
                column: "volunteer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_BrigadeId",
                table: "Donations",
                column: "BrigadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonationTypeId",
                table: "Donations",
                column: "DonationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_PersonId",
                table: "Donations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Id",
                table: "Persons",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IdentificationTypeId",
                table: "Persons",
                column: "IdentificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserId",
                table: "Persons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SmtpConfigurations_CompanyId",
                table: "SmtpConfigurations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_ActivityTypeId",
                table: "Volunteers",
                column: "ActivityTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrigadeBeneficiaries");

            migrationBuilder.DropTable(
                name: "BrigadeVoluntareers");

            migrationBuilder.DropTable(
                name: "CompanyUsers");

            migrationBuilder.DropTable(
                name: "ConsultVolunteers");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "SmtpConfigurations");

            migrationBuilder.DropTable(
                name: "Beneficiaries");

            migrationBuilder.DropTable(
                name: "BeneficiaryType");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "RegistrationVolunteer");

            migrationBuilder.DropTable(
                name: "Brigades");

            migrationBuilder.DropTable(
                name: "DonationType");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "IdentificationType");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
