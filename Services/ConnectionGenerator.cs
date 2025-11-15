using Lesson27.Services.Infrastructure.Interfaces;
using System.Reflection;

namespace Lesson27.Services
{
    public class ConnectionGenerator : IConnectionGenerator
    {
        private const string FirstCommandPart = "Data Source=";
        private const string LastCommandPart = "\\db.sqlite";

        public string Generate() =>
            $"{FirstCommandPart}{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{LastCommandPart}";
    }
}