using ApiDapper.Domain.Entities;
using ApiDapper.Domain.Repository;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ApiDapper.Infrastructure.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly string _connectionString;

        public PessoaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Pessoa> GetAll()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Pessoa>("SELECT Codigo, Nome, Endereco FROM Pessoa ORDER BY Nome ASC");
            }
        }
    }
}
