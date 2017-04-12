﻿using Npgsql;
using System;
using System.Data;
using YesSql.Core.Services;
using YesSql.Storage.Sql;

namespace YesSql.Provider.PostgreSql
{
    public static class PostgreSqlDbProviderOptionsExtensions
    {
        public static Configuration UsePostgreSql(
            this Configuration configuration,
            string connectionString)
        {
            return UsePostgreSql(configuration, connectionString, IsolationLevel.ReadUncommitted);
        }

        public static Configuration UsePostgreSql(
            this Configuration configuration,
            string connectionString,
            IsolationLevel isolationLevel)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException(nameof(connectionString));
            }

            configuration.ConnectionFactory = new DbConnectionFactory<NpgsqlConnection>(connectionString);
            configuration.DocumentStorageFactory = new SqlDocumentStorageFactory();
            configuration.IsolationLevel = isolationLevel;

            return configuration;
        }
    }
}