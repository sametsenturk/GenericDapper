using Dapper;
using GenericDapper.Business.Services.Dapper.Base.Abstract;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Text;

namespace GenericDapper.Business.Services.Dapper.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Data.Entities.BaseEntity
    {
        public string _tableName = "";

        //private IDbConnection _db = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        private IDbConnection _db = new MySqlConnection("Server=localhost;Database=genericdapperdb;Uid=root;");

        public void Delete(int id)
        {
            string sqlQuery = $"DELETE FROM {_tableName} where ID={id}";
            this._db.Query(sqlQuery);
        }

        public TEntity Find(int id)
        {
            string sqlQuery = $"SELECT * FROM {_tableName} where ID={id}";
            return this._db.Query<TEntity>(sqlQuery).AsList()[0];
        }

        public TEntity Get(string expression)
        {
            string sqlQuery = $"SELECT * FROM {_tableName} where {expression}";
            return this._db.Query<TEntity>(sqlQuery).AsList()[0];
        }

        public List<TEntity> GetAll()
        {
            string sqlQuery = $"SELECT * FROM {_tableName}";
            return this._db.Query<TEntity>(sqlQuery).AsList();
        }


        public List<TEntity> GetAllWithQuery(string expression)
        {
            string sqlQuery = $"SELECT * FROM {_tableName} where {expression}";
            return this._db.Query<TEntity>(sqlQuery).AsList();
        }

        public void Insert(TEntity entity)
        {
            entity.AddDate = DateTime.Now;
            PropertyInfo[] prop = typeof(TEntity).GetProperties();
            string sqlQuery = $"INSERT INTO {_tableName} (";
            for (int i = 0; i < prop.Length; i++)
            {
                if (prop[i].Name != "ID")
                {
                    sqlQuery += prop[i].Name;
                    if (i != prop.Length - 1)
                        sqlQuery += ",";
                }
            }
            sqlQuery += ") values(";
            for (int i = 0; i < prop.Length; i++)
            {
                if (prop[i].Name != "ID")
                {
                    sqlQuery += $"@{prop[i].Name}";
                    if (i != prop.Length - 1)
                        sqlQuery += ",";
                }
            }
            sqlQuery += ")";
            string a = sqlQuery;
            this._db.Execute(sqlQuery, entity);
        }

        public void Update(TEntity entity)
        {
            PropertyInfo[] prop = typeof(TEntity).GetProperties();
            string sqlQuery = $"UPDATE {_tableName} SET ";
            for (int i = 0; i < prop.Length; i++)
            {
                if (prop[i].Name != "ID")
                {
                    sqlQuery += $"{prop[i].Name} = @{prop[i].Name}";
                    if (i != prop.Length - 1)
                        sqlQuery += ", ";
                }
            }
            sqlQuery += $" where ID = {entity.ID}";
            string query = sqlQuery;
            this._db.Execute(sqlQuery, entity);
        }
    }
}
