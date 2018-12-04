using FluentMigrator;

namespace WebCore.Migrations
{
    [Migration(5)]
    public class CreateTableEmployees :  Migration
    {
        const string TableName = "Employees";
        
        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt32().PrimaryKey()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable()
                .WithColumn("Age").AsInt16().NotNullable()
                .WithColumn("LanguageId").AsInt32().ForeignKey("Languages","Id").NotNullable()
                .WithColumn("DepartmentId").AsInt32().ForeignKey("Departments","Id").NotNullable();
        }

        public override void Down()
        {
            Delete.Table(TableName);
        }
    }
}