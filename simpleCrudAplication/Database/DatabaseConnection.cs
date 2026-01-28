using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using DotNetEnv;


namespace simpleCrudAplication.Database
{
    internal class DatabaseConnection
    {
        public static NpgsqlConnection GetConnection()
        {
            /*
            função responsável por criar a conexão com o banco de dados PostgreSQL
            */
            string connection =
                "Host=localhost;" +
                "Port=5432;" +
                "Username=postgres;" +
                "Password=1234;" +
                "Database=simpleCrudDataBase";

            return new NpgsqlConnection(connection);
        }
    }
}
