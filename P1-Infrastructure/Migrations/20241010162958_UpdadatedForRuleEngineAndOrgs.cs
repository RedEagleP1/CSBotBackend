using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P1_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdadatedForRuleEngineAndOrgs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Users_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ConditionRule_Condition_ConditionsId",
                table: "ConditionRule");

            migrationBuilder.DropForeignKey(
                name: "FK_ConditionRule_Rule_RulesId",
                table: "ConditionRule");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultRule_Rule_RulesId",
                table: "ResultRule");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleTrigger_Rule_RulesId",
                table: "RuleTrigger");

            migrationBuilder.DropForeignKey(
                name: "FK_UserItem_Item_ItemId",
                table: "UserItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UserItem_Users_UserId",
                table: "UserItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMetaData_Users_UserId",
                table: "UserMetaData");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserItem",
                table: "UserItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rule",
                table: "Rule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Condition",
                table: "Condition");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "DiscordId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "UserItem",
                newName: "UserItems");

            migrationBuilder.RenameTable(
                name: "Rule",
                newName: "Rules");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "Condition",
                newName: "Conditions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserMetaData",
                newName: "DiscordUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMetaData_UserId",
                table: "UserMetaData",
                newName: "IX_UserMetaData_DiscordUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUsers",
                newName: "DiscordUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_DiscordUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserItem_ItemId",
                table: "UserItems",
                newName: "IX_UserItems_ItemId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Triggers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DiscordUserId",
                table: "UserItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "UserItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Items",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ExpectedResult",
                table: "Conditions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ExpectedValue",
                table: "Conditions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Operation",
                table: "Conditions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserItems",
                table: "UserItems",
                columns: new[] { "UserId", "ItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rules",
                table: "Rules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conditions",
                table: "Conditions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ItemResults",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ResultId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemResults", x => new { x.ItemId, x.ResultId });
                    table.ForeignKey(
                        name: "FK_ItemResults_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemResults_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiscordUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DiscordId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscordUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    DiscordUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_DiscordUsers_DiscordUserId",
                        column: x => x.DiscordUserId,
                        principalTable: "DiscordUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeamLeaderId = table.Column<int>(type: "int", nullable: false),
                    CurrentGameId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_DiscordUserId",
                table: "UserItems",
                column: "DiscordUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscordUsers_GameId",
                table: "DiscordUsers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscordUsers_TeamId",
                table: "DiscordUsers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TeamId",
                table: "Games",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemResults_ResultId",
                table: "ItemResults",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_DiscordUserId",
                table: "Organization",
                column: "DiscordUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_TeamId",
                table: "Organization",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_OrganizationId",
                table: "Team",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DiscordUsers_DiscordUserId",
                table: "AspNetUsers",
                column: "DiscordUserId",
                principalTable: "DiscordUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionRule_Conditions_ConditionsId",
                table: "ConditionRule",
                column: "ConditionsId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionRule_Rules_RulesId",
                table: "ConditionRule",
                column: "RulesId",
                principalTable: "Rules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultRule_Rules_RulesId",
                table: "ResultRule",
                column: "RulesId",
                principalTable: "Rules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleTrigger_Rules_RulesId",
                table: "RuleTrigger",
                column: "RulesId",
                principalTable: "Rules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserItems_DiscordUsers_DiscordUserId",
                table: "UserItems",
                column: "DiscordUserId",
                principalTable: "DiscordUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserItems_Items_ItemId",
                table: "UserItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMetaData_DiscordUsers_DiscordUserId",
                table: "UserMetaData",
                column: "DiscordUserId",
                principalTable: "DiscordUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscordUsers_Games_GameId",
                table: "DiscordUsers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscordUsers_Team_TeamId",
                table: "DiscordUsers",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Team_TeamId",
                table: "Games",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Team_TeamId",
                table: "Organization",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DiscordUsers_DiscordUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ConditionRule_Conditions_ConditionsId",
                table: "ConditionRule");

            migrationBuilder.DropForeignKey(
                name: "FK_ConditionRule_Rules_RulesId",
                table: "ConditionRule");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultRule_Rules_RulesId",
                table: "ResultRule");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleTrigger_Rules_RulesId",
                table: "RuleTrigger");

            migrationBuilder.DropForeignKey(
                name: "FK_UserItems_DiscordUsers_DiscordUserId",
                table: "UserItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserItems_Items_ItemId",
                table: "UserItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMetaData_DiscordUsers_DiscordUserId",
                table: "UserMetaData");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscordUsers_Games_GameId",
                table: "DiscordUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscordUsers_Team_TeamId",
                table: "DiscordUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Team_TeamId",
                table: "Organization");

            migrationBuilder.DropTable(
                name: "ItemResults");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "DiscordUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserItems",
                table: "UserItems");

            migrationBuilder.DropIndex(
                name: "IX_UserItems_DiscordUserId",
                table: "UserItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rules",
                table: "Rules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conditions",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "DiscordUserId",
                table: "UserItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "UserItems");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ExpectedResult",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "ExpectedValue",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "Operation",
                table: "Conditions");

            migrationBuilder.RenameTable(
                name: "UserItems",
                newName: "UserItem");

            migrationBuilder.RenameTable(
                name: "Rules",
                newName: "Rule");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameTable(
                name: "Conditions",
                newName: "Condition");

            migrationBuilder.RenameColumn(
                name: "DiscordUserId",
                table: "UserMetaData",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMetaData_DiscordUserId",
                table: "UserMetaData",
                newName: "IX_UserMetaData_UserId");

            migrationBuilder.RenameColumn(
                name: "DiscordUserId",
                table: "AspNetUsers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_DiscordUserId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserItems_ItemId",
                table: "UserItem",
                newName: "IX_UserItem_ItemId");

            migrationBuilder.UpdateData(
                table: "Triggers",
                keyColumn: "Description",
                keyValue: null,
                column: "Description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Triggers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Results",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<ulong>(
                name: "DiscordId",
                table: "AspNetUsers",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserItem",
                table: "UserItem",
                columns: new[] { "UserId", "ItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rule",
                table: "Rule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Condition",
                table: "Condition",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DiscordId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Users_UserId",
                table: "AspNetUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionRule_Condition_ConditionsId",
                table: "ConditionRule",
                column: "ConditionsId",
                principalTable: "Condition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionRule_Rule_RulesId",
                table: "ConditionRule",
                column: "RulesId",
                principalTable: "Rule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultRule_Rule_RulesId",
                table: "ResultRule",
                column: "RulesId",
                principalTable: "Rule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleTrigger_Rule_RulesId",
                table: "RuleTrigger",
                column: "RulesId",
                principalTable: "Rule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserItem_Item_ItemId",
                table: "UserItem",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserItem_Users_UserId",
                table: "UserItem",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMetaData_Users_UserId",
                table: "UserMetaData",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
