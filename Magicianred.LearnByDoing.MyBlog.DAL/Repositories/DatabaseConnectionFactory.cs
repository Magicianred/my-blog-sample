﻿using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace Magicianred.LearnByDoing.MyBlog.DAL.Repositories
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DatabaseConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            var databaseType = _configuration.GetSection("DatabaseType").Value;
            if (!string.IsNullOrWhiteSpace(databaseType) && databaseType.ToLower().Trim() == "mysql")
            {
                return new MySqlConnection(_configuration.GetConnectionString("MyBlog"));
            }
            return new SqlConnection(_configuration.GetConnectionString("MyBlog"));
        }
    }
}
