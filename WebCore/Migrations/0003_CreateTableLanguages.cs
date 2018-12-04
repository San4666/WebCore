using FluentMigrator;

namespace WebCore.Migrations
{
    [Migration(3)]
    public class CreateTableLanguages : Migration
    {
        const string TableName = "Languages";
        
        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt32().PrimaryKey()
                .WithColumn("Name").AsString().Unique().NotNullable();
        }

        public override void Down()
        {
            Delete.Table(TableName);
        }
    }
}