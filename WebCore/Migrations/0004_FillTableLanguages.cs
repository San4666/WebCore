using System.Collections.Generic;
using FluentMigrator;

namespace WebCore.Migrations
{
    [Migration(4)]
    public class FillTableLanguages : Migration
    {
        const string TableName = "Languages";
        
        public override void Up()
        {
            var languageNames =  new List<string>()
            {
                "C#",
                "PHP",
                "Python",
                "JS",
                "Type Script"
            };
            
            foreach (var name  in languageNames)
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