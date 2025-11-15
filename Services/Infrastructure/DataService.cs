using Lesson27.Services.Infrastructure.Interfaces;
using Microsoft.Data.Sqlite;
using System.Data;

namespace Lesson27.Services.Infrastructure
{
    public class DataService : IDataService
    {
        public DataTable GetTable(string connectionCommand, string requestCommand)
        {
            try
            {
                SqliteConnection connection = new SqliteConnection(connectionCommand);
                DataTable dataTable = new DataTable();

                connection.Open();

                SqliteCommand request = new SqliteCommand(requestCommand, connection);
                var reader = request.ExecuteReader();

                dataTable.Load(reader);
                connection.Close();

                return dataTable;
            }
            catch (SqliteException ex)
            {
                if (ex.ErrorCode != 1)
                    throw new NotImplementedException("Не реализовано");

                return null;
            }
        }
    }
}