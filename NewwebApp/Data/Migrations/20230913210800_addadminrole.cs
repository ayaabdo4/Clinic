using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewwebApp.Data.Migrations
{
    public partial class addadminrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Address], [DOB], [Gender], [Name], [Numbber]) VALUES (N'92609770-51b9-4dea-99d2-7e05ea2f577e', N'Admin@gmail.com', N'ADMIN@GMAIL.COM', N'Admin@gmail.com', N'ADMIN@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEMFXJaRB65yUCsc8yhnQ+asW/7UdZSINwytbu5A19liBgQDo2W7y+ORFMousnKWCWw==', N'JLUZTOLXOTS2HTJ7RZIEIPMMTBKUOXZD', N'50dbd3e8-6dc3-45a9-8ecb-c42b83a4cdc5', NULL, 0, 0, NULL, 1, 0, N'Elnasr city', N'1988-10-23 00:00:00', 1, N'Admin', 1099161099)\r\n");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUsers] WHERE Id='92609770-51b9-4dea-99d2-7e05ea2f577e' ");
        }
    }
}
