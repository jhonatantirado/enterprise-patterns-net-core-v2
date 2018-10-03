using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(6)]
    public class PurchasedMovieTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("6_PurchasedMovieTable.sql");
        }

        public override void Down()
        {
        }
    }
}
