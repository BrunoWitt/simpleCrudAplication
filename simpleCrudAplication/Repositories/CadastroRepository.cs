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
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();

            var query = "INSERT INTO cadastros (texto, numero) VALUES (@texto, @numero);";
            using var command = new Npgsql.NpgsqlCommand(query, connection);

            command.Parameters.AddWithValue("texto", cadastro.Texto);
            command.Parameters.AddWithValue("numero", cadastro.Numero);

            command.ExecuteNonQuery();
        }
    }
}
