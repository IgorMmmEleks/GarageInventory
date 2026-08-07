using System.Data;

namespace GarageInventory.Persistence.Database.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
