using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(5)]
    public class MovieTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("5_MovieTable.sql");
        }

        public override void Down()
        {
        }
    }
}
