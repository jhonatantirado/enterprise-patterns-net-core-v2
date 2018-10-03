using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(4)]
    public class DirectorTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("4_DirectorTable.sql");
        }

        public override void Down()
        {
        }
    }
}
