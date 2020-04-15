using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuicPoc.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "promotion",
                columns: table => new
                {
                    PromotionId = table.Column<Guid>(nullable: false),
                    PromotionCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promotion", x => x.PromotionId);
                });

            migrationBuilder.CreateTable(
                name: "coupon",
                columns: table => new
                {
                    CouponId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    PromotionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coupon", x => x.CouponId);
                    table.ForeignKey(
                        name: "FK_coupon_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_coupon_promotion_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "promotion",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_coupon_CustomerId",
                table: "coupon",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_coupon_PromotionId",
                table: "coupon",
                column: "PromotionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coupon");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "promotion");
        }
    }
}
