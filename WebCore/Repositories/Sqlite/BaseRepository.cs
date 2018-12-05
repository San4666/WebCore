using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using WebCore.Entities;

namespace WebCore.Repositories.Sqlite
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly string ConnectionString;
        
        protected abstract string TableName { get; }
        
        protected BaseRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("main");
        }

        public void Delete(TEntity entity)
        {
            using (var connect = new SqliteConnection(ConnectionString))
            {
                connect.Open();
                var command = connect.CreateCommand();
                command.CommandText = $"DELETE FROM {TableName} WHERE Id = @Id";
                command.Parameters.Add(new SqliteParameter("@Id",entity.Id));
                
                command.ExecuteNonQuery();
            }
        }

        public ICollection<TEntity> All()
        {
            using (var connect = new SqliteConnection(ConnectionString))
            {
                connect.Open();
                var command = connect.CreateCommand();
                command.CommandText = $"SELECT * FROM {TableName}";

                return ExecuteRead(command);
            }
        }

        public TEntity Find(int id)
        {
            using (var connect = new SqliteConnection(ConnectionString))
            {
                connect.Open();
                var command = connect.CreateCommand();
                command.CommandText = $"SELECT * FROM {TableName} WHERE Id = @id LIMIT 1";
                command.Parameters.Add(new SqliteParameter("@id",id));

                return ExecuteRead(command).FirstOrDefault();
            }
        }

        public abstract void Insert(TEntity entity);

        public abstract void Update(TEntity entity);

        public bool Exist(int id)
        {
            return null != Find(id);
        }

        protected abstract TEntity ToEntity(DbDataReader reader);

        protected List<TEntity> ExecuteRead(DbCommand command)
        {
            var result = new List<TEntity>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(ToEntity(reader));
                }
            }

            return result;
        }
    }
}