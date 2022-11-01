using Microsoft.EntityFrameworkCore.Migrations;

namespace PaySlip.DbMigration.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Over = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    UpTo = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRates", x => x.Id);
                });

            // This is custom code added.
            migrationBuilder.Sql(@"SET IDENTITY_INSERT [dbo].[TaxRates] ON 
                                INSERT [dbo].[TaxRates] ([Id], [Order], [Over], [UpTo], [Rate]) VALUES (1, 1, CAST(0.00 AS Decimal(12, 2)), CAST(14000.00 AS Decimal(12, 2)), CAST(10.50 AS Decimal(5, 2)))
                                INSERT [dbo].[TaxRates] ([Id], [Order], [Over], [UpTo], [Rate]) VALUES (2, 2, CAST(14000.00 AS Decimal(12, 2)), CAST(48000.00 AS Decimal(12, 2)), CAST(17.50 AS Decimal(5, 2)))
                                INSERT [dbo].[TaxRates] ([Id], [Order], [Over], [UpTo], [Rate]) VALUES (3, 3, CAST(48000.00 AS Decimal(12, 2)), CAST(70000.00 AS Decimal(12, 2)), CAST(30.00 AS Decimal(5, 2)))
                                INSERT [dbo].[TaxRates] ([Id], [Order], [Over], [UpTo], [Rate]) VALUES (4, 4, CAST(70000.00 AS Decimal(12, 2)), CAST(140000.00 AS Decimal(12, 2)), CAST(33.00 AS Decimal(5, 2)))
                                INSERT [dbo].[TaxRates] ([Id], [Order], [Over], [UpTo], [Rate]) VALUES (5, 5, CAST(140000.00 AS Decimal(12, 2)), CAST(9999999999.99 AS Decimal(12, 2)), CAST(39.00 AS Decimal(5, 2)))
                                SET IDENTITY_INSERT [dbo].[TaxRates] OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxRates");
        }
    }
}
