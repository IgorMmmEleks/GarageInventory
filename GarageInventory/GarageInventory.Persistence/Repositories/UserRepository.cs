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
                    "SELECT * FROM Users ORDER BY Login, Id LIMIT @Take OFFSET @Skip",
                    new { Skip = skip, Take = take });
                return users;
            }
        }

        public async Task<UserModel?> GetByLoginAsync(string login)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<UserModel>(
                    "SELECT (1) FROM Users WHERE Login = @Login",
                    new { Login = login });
                return user;
            }
        }

        public async Task<UserModel?> GetByIdAsync(Guid id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<UserModel>(
                    "SELECT * FROM Users WHERE Id = @Id",
                    new { Id = id });
                return user;
            }
        }

        public async Task<Guid?> CreateAsync(UserModel user)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(
                    "INSERT INTO Users (Id, Login, Name, Surname, Email, UserType, PasswordHash, CreatedAt) " +
                    "VALUES (@Id, @Login, @Name, @Surname, @Email, @UserType, @PasswordHash, @CreatedAt)",
                    new
                    {
                        Id = user.Id,
                        Login = user.Login,
                        Name = user.Name,
                        Surname = user.Surname,
                        Email = user.Email,
                        UserType = (int)user.UserType,
                        PasswordHash = user.PasswordHash,
                        CreatedAt = DateTime.UtcNow
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
            using (var connection = _connectionFactory.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(
                    "UPDATE Users SET Login = @Login, Name = @Name, Surname = @Surname, Email = @Email, " +
                    "UserType = @UserType, PasswordHash = @PasswordHash, UpdatedAt = @UpdatedAt " + 
                    "WHERE Id = @Id",
                    new
                    {
                        Id = user.Id,
                        Login = user.Login,
                        Name = user.Name,
                        Surname = user.Surname,
                        Email = user.Email,
                        UserType = (int)user.UserType,
                        PasswordHash = user.PasswordHash,
                        UpdatedAt = DateTime.UtcNow
                    });

                return affectedRows > 0;
            }
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
