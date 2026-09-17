using Dapper;
using System.Data;

namespace GarageInventory.Persistence.Database
{
    public class GuidTypeHandler : SqlMapper.TypeHandler<Guid>
    {
        public override Guid Parse(object? value)
        {
            if (value is null || value is DBNull)
                return Guid.Empty;

            if (value is Guid guid)
                return guid;

            if (value is string stringValue)
                return string.IsNullOrEmpty(stringValue) ? Guid.Empty : Guid.Parse(stringValue);

            if (value is byte[] bytes)
                return new Guid(bytes);

            throw new ArgumentException($"Cannot convert value of type {value.GetType()} to Guid", nameof(value));
        }

        public override void SetValue(IDbDataParameter parameter, Guid value)
        {
            parameter.Value = value.ToByteArray();
        }
    }
}

