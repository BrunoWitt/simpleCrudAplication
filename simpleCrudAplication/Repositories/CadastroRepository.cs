using System;
using System.Collections.Generic;
using System.Text;
using simpleCrudAplication.Database;
using simpleCrudAplication.Models;

namespace simpleCrudAplication.Repositories
{
    internal class CadastroRepository
    {
        public void Inserir(Cadastro cadastro)
        {
             /*
             * Função responsável por inserir um novo cadastro no banco de dados
             */
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();

            var query = "INSERT INTO cadastros (texto, numero) VALUES (@texto, @numero);";
            using var command = new Npgsql.NpgsqlCommand(query, connection);

            command.Parameters.AddWithValue("texto", cadastro.Texto);
            command.Parameters.AddWithValue("numero", cadastro.Numero);

            command.ExecuteNonQuery();
        }


        public List<Cadastro> Listar()
        {
            /*
             * Função responsável por listar todos os cadastros do banco de dados
             */
            var list = new List<Cadastro>();

            using var connection = DatabaseConnection.GetConnection();
            connection.Open();

            var query = "SELECT texto, numero FROM cadastros;";
            using var command = new Npgsql.NpgsqlCommand(query, connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var cadastro = new Cadastro
                {
                    Texto = reader.GetString(0),
                    Numero = reader.GetInt32(1)
                };

                list.Add(cadastro);
            }

            return list;
        }


        public void Update(Cadastro cadastro)
        {
            /*
             * Função responsável por atualizar um cadastro no banco de dados
             */
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();

            var query = "UPDATE cadastros SET texto = @texto WHERE numero = @numero;";
            using var command = new Npgsql.NpgsqlCommand(query, connection);

            command.Parameters.AddWithValue("texto", cadastro.Texto);
            command.Parameters.AddWithValue("numero", cadastro.Numero);

            command.ExecuteNonQuery()
        }
    }
}
