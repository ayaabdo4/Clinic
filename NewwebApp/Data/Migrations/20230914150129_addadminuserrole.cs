using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewwebApp.Data.Migrations
{
    public partial class addadminuserrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUserRoles] (UserId , RoleId) SELECT '92609770-51b9-4dea-99d2-7e05ea2f577e', Id FROM  [dbo].[AspNetRoles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUserRoles] WHERE UserId ='92609770-51b9-4dea-99d2-7e05ea2f577e'");

        }
    }
}
