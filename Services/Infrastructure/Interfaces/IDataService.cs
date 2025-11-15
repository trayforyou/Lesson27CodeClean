using System.Data;

namespace Lesson27.Services.Infrastructure.Interfaces
{
    public interface IDataService
    {
        public DataTable GetTable(string connectCommand, string requestCommand);
    }
}