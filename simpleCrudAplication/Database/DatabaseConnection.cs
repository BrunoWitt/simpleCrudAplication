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
                $"Host={Env.GetString("DB_HOST")};" +
                $"Port={Env.GetString("DB_PORT")};" +
                $"Username={Env.GetString("DB_USER")};" +
                $"Password={Env.GetString("DB_PASSWORD")};" +
                $"Database={Env.GetString("DB_NAME")};";

            return new NpgsqlConnection(connection);
        }
    }
}
