using Dapper;
using GarageInventory.Persistence.Abstract.Interfaces;
using GarageInventory.Persistence.Abstract.Models;
using GarageInventory.Persistence.Database.Interfaces;

namespace GarageInventory.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UserRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> ExistsAsync(string email)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var count = await connection.ExecuteScalarAsync<int>(
                    "SELECT COUNT(1) FROM Users WHERE Email = @Email",
                    new { Email = email });
                return count > 0;
            }
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync(int skip, int take)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var users = await connection.QueryAsync<UserModel>(
                    "SELECT * FROM Users ORDER BY Nickname OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY",
                    new { Skip = skip, Take = take });
                return users;
            }
        }

        public async Task<UserModel?> GetByUserLoginAsync(string login)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<UserModel>(
                    "SELECT * FROM Users WHERE Nickname = @Nickname",
                    new { Nickname = login });
                return user;
            }
        }

        public async Task<Guid?> CreateAsync(UserModel user)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(
                    "INSERT INTO Users (Id, Nickname, Name, Surname, Email, UserType, PasswordHash, IsActive) " +
                    "VALUES (@Id, @Nickname, @Name, @Surname, @Email, @UserType, @PasswordHash, @IsActive)",
                    new
                    {
                        Id = user.Id,
                        Nickname = user.Login,
                        Name = user.Name,
                        Surname = user.Surname,
                        Email = user.Email,
                        UserType = (int)user.UserType,
                        PasswordHash = user.PasswordHash
                    });

                if (affectedRows > 0)
                {
                    return user.Id;
                }

                return null;
            }
        }

        public async Task<bool> UpdateAsync(UserModel user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            int affectedRows = 0;

            using (var connection = _connectionFactory.CreateConnection())
            {
                affectedRows = await connection.ExecuteAsync(
                    "DELETE FROM Users WHERE Id = @Id",
                    new { Id = id });
            }
            return affectedRows > 0;
        }
    }
}
