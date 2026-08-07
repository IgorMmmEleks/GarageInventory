namespace GarageInventory.Persistence.Database.Interfaces
{
    public interface IDatabaseInitializer
    {
        Task InitializeDatabaseAsync(string connectionString);
    }
}
