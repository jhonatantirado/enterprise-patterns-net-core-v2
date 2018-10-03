using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(2)]
    public class BankAccountTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("2_BankAccountTable.sql");
        }

        public override void Down()
        {
        }
    }
}
