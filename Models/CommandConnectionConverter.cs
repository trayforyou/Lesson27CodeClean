using Lesson27.Models.Interfaces;
using System.Reflection;

namespace Lesson27.Models
{
    public class ConnectionGenerator : IConnectionGenerator
    {
        private const string FirstCommandPart = "Data Source=";
        private const string LastCommandPart = "\\db.sqlite";

        public string Generate() =>
            $"{FirstCommandPart}{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{LastCommandPart}";
    }
}