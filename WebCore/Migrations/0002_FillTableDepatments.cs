using System.Collections.Generic;
using FluentMigrator;

namespace WebCore.Migrations
{
    [Migration(2)]
    public class FillTableDepartments : Migration
    {
        const string TableName = "Departments";
        
        public override void Up()
        {
            var departmentNames =  new List<string>()
            {
                "Bank",
                "Tourism",
                "Trade",
                "Marketing"            
            };
            
            foreach (var name  in departmentNames)
            {
                Insert.IntoTable(TableName).Row(new
                {
                    Name = name                  
                });     
            }  
        }

        public override void Down()
        {
            Delete.FromTable(TableName);
        }
    }
}