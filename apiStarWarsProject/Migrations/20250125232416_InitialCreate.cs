using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiStarWarsProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Army Division",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmyDivisionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Army Division", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jedi Rank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JediRankName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jedi Rank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trooper Rank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankTrooperName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trooper Rank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trooper Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trooper Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jedis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JediName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JediRankId = table.Column<int>(type: "int", nullable: false),
                    ArmyDivisionJedi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jedis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jedis_Army Division_ArmyDivisionJedi",
                        column: x => x.ArmyDivisionJedi,
                        principalTable: "Army Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jedis_Jedi Rank_JediRankId",
                        column: x => x.JediRankId,
                        principalTable: "Jedi Rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clone Trooper",
                columns: table => new
                {
                    CloneTrooperId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CloneTrooperName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrooperRankId = table.Column<int>(type: "int", nullable: false),
                    TrooperArmyDivisionId = table.Column<int>(type: "int", nullable: false),
                    TrooperStatusId = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clone Trooper", x => x.CloneTrooperId);
                    table.ForeignKey(
                        name: "FK_Clone Trooper_Army Division_TrooperArmyDivisionId",
                        column: x => x.TrooperArmyDivisionId,
                        principalTable: "Army Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clone Trooper_Trooper Rank_TrooperRankId",
                        column: x => x.TrooperRankId,
                        principalTable: "Trooper Rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clone Trooper_Trooper Status_TrooperStatusId",
                        column: x => x.TrooperStatusId,
                        principalTable: "Trooper Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clone Trooper_TrooperArmyDivisionId",
                table: "Clone Trooper",
                column: "TrooperArmyDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clone Trooper_TrooperRankId",
                table: "Clone Trooper",
                column: "TrooperRankId");

            migrationBuilder.CreateIndex(
                name: "IX_Clone Trooper_TrooperStatusId",
                table: "Clone Trooper",
                column: "TrooperStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Jedis_ArmyDivisionJedi",
                table: "Jedis",
                column: "ArmyDivisionJedi");

            migrationBuilder.CreateIndex(
                name: "IX_Jedis_JediRankId",
                table: "Jedis",
                column: "JediRankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clone Trooper");

            migrationBuilder.DropTable(
                name: "Jedis");

            migrationBuilder.DropTable(
                name: "Trooper Rank");

            migrationBuilder.DropTable(
                name: "Trooper Status");

            migrationBuilder.DropTable(
                name: "Army Division");

            migrationBuilder.DropTable(
                name: "Jedi Rank");
        }
    }
}
