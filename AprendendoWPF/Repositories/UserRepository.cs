using AprendendoWPF.Model;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoWPF.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser = false;

            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open(); // Certifique-se de abrir a conexão

                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT COUNT(1) FROM User WHERE username=@username AND password=@password";

                        // Adiciona os parâmetros corretamente
                        command.Parameters.Add("@username", MySqlDbType.VarChar).Value = credential.UserName;
                        command.Parameters.Add("@password", MySqlDbType.VarChar).Value = credential.Password;

                        // Executa o comando e verifica se o usuário existe
                        var result = command.ExecuteScalar();

                        // Se o resultado for maior que 0, o usuário é válido
                        validUser = Convert.ToInt32(result) > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Trate possíveis erros de conexão ou SQL aqui
                Console.WriteLine($"Erro de banco de dados: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Trate outros erros genéricos aqui
                Console.WriteLine($"Erro: {ex.Message}");
            }

            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
