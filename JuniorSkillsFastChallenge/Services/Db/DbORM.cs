using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace JuniorSkillsFastChallenge.Services.Db
{
    public class DbORM
    {
        private readonly AppDbConnection _connection;


        public DbORM()
        {
            _connection = new AppDbConnection();
        }


        public object ExecuteScalar(string sql, params object[] parameters)
        {
            return Execute(sql, parameters, command =>
            {
                return command.ExecuteScalar();
            });
        }

        public List<TResult> ExecuteQuery<TResult>(string sql, params object[] parameters)
            where TResult : class, new()
        {
            return Execute(sql, parameters, command =>
            {
                using (var reader = command.ExecuteReader())
                {
                    return MapReaderToEntity<TResult>(reader);
                }
            });
        }

        public int ExecuteQuery(string sql, params object[] parameters)
        {
            return Execute(sql, parameters, command =>
            {
                return command.ExecuteNonQuery();
            });
        }

        
        private List<TResult> MapReaderToEntity<TResult>(SqlDataReader reader)
            where TResult : class, new()
        {
            var result = new List<TResult>();
            if (!reader.HasRows) return result;

            while (reader.Read())
            {
                var entity = new TResult();
                for (var i = 0; i < reader.FieldCount; ++i)
                {
                    var prop = typeof(TResult).GetProperty(reader.GetName(i));
                    if (reader.IsDBNull(i) || prop == null) continue;

                    prop.SetValue(entity, reader.GetValue(i));
                }
                result.Add(entity);
            }

            return result;
        }

        private TResult Execute<TResult>(string sql, object[] parameters, Func<SqlCommand, TResult> executeFunc)
        {
            try
            {
                _connection.Open();

                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = InsertParameters(sql, parameters);
                    return executeFunc(command);
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        private string InsertParameters(string sql, params object[] parameters)
        {
            return string.Format(sql, parameters.Select(MapParameter).ToArray());
        }

        private object MapParameter(object obj)
        {
            if (obj is string str)
            {
                return $"'{str}'";
            }
            if (obj is DateTime dateTime)
            {
                return $"'{dateTime.ToString("yyyy-MM-dd hh:mm:ss")}'";
            }
            if (obj == null)
            {
                return "''";
            }


            return obj;
        }
    }
}
