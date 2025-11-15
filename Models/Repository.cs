using Lesson27.Enums;
using Lesson27.Services.Infrastructure;
using Lesson27.Services.Infrastructure.Interfaces;
using Lesson27.Services.Interfaces;
using System.Data;

namespace Lesson27.Models
{
    public class Repository
    {
        private readonly IConnectionGenerator _connectionGenerator;
        private readonly IConverter _requestConverter;
        private readonly DataService _dataService;

        public Repository(IConverter requestConverter, IConnectionGenerator connectionGenerator,
            DataService dataService)
        {
            _requestConverter = requestConverter ?? throw new ArgumentNullException(nameof(requestConverter));
            _connectionGenerator = connectionGenerator ?? throw new ArgumentNullException(nameof(connectionGenerator));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        private Citizen FindInTable(DataTable dataTable)
        {
            if (Convert.ToBoolean(dataTable.Rows[0].ItemArray[1]))
                return new Citizen(CitizenStates.Granted);
            else
                return new Citizen(CitizenStates.NotGranted);
        }

        public Citizen Handle(string hash)
        {
            string request = _requestConverter.Convert(hash);
            string connection = _connectionGenerator.Generate();

            DataTable dataTable = _dataService.GetTable(connection, request);

            if (dataTable is null)
                return new Citizen(CitizenStates.NoInfo);

            if (dataTable.Rows.Count > 0)
                return FindInTable(dataTable);
            else
                return new Citizen(CitizenStates.NotFound);
        }
    }
}