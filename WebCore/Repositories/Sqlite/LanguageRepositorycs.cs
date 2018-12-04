using System;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using WebCore.Entities;

namespace WebCore.Repositories.Sqlite
{
    public class LanguageRepository : BaseRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(IConfiguration configuration) : base(configuration)
        {
        }

        protected override string TableName => "Languages";

        public override void Insert(Language entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Language entity)
        {
            throw new NotImplementedException();
        }

        protected override Language Parser(DbDataReader reader)
        {
            return new Language()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString()
            };
        }
    }
}