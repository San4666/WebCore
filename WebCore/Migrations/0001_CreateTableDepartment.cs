using FluentMigrator;

namespace WebCore.Migrations
{
    [Migration(1)]
    public class CreateTableDepartments : Migration
    {
        const string TableName = "Departments";
        
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