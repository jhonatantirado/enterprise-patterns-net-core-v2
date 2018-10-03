using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(3)]
    public class IdsTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("3_IdsTable.sql");
        }

        public override void Down()
        {
        }
    }
}
