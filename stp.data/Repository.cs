using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using SqlKata;
using SqlKata.Compilers;

namespace stp.data
{
    public class Repository
    {
        private readonly IDbConnection _connection;
        private readonly SqlServerCompiler _compiler;

        public Repository(IDbConnection connection)
        {
            _connection = connection;
            _compiler = new SqlServerCompiler();
        }

        public IEnumerable<DTOs.UserAccount> GetAllUserAccounts()
        {
            var query = new Query("UserAccount");
            var sqlResult = _compiler.Compile(query);
            return _connection.Query<DTOs.UserAccount>(sqlResult.Sql);
        }

        public DTOs.UserAccount FindUserAccountByUsernameAndPassword(string username, string password)
        {
            var query = new Query("UserAccount")
                .Where("Username", username)
                .Where("password", password);
            var sqlResult = _compiler.Compile(query);
            DTOs.UserAccount result;
            try
            {
                result = _connection.QuerySingle<DTOs.UserAccount>(sqlResult.Sql, new { p0 = sqlResult.Bindings[0], p1 = sqlResult.Bindings[1] });
            }
            catch (InvalidOperationException e) when (e.Message.Contains("no elements", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            return result;
        }
    }
}