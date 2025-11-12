using Lesson27.Models.Interfaces;
using Microsoft.Data.Sqlite;
using System.Data;

namespace Lesson27.Models
{
    public class DataBaseHandler : IDataBaseHandler
    {
        private const string MessageAccessCompleted = "По паспорту «{0}» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
        private const string MessageAccessDenied = "По паспорту «{0}» доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";
        private const string MessageNumberNotFound = "Паспорт «{0}» в списке участников дистанционного голосования НЕ НАЙДЕН";
        private const string MessageDataBaseNotFound = "Файл db.sqlite не найден. Положите файл в папку вместе с exe.";

        private readonly IConnectionGenerator _connectionGenerator;
        private readonly IConverter _requestConverter;

        public DataBaseHandler(IConverter requestConverter, IConnectionGenerator connectionGenerator)
        {
            _requestConverter = requestConverter ?? throw new ArgumentNullException(nameof(requestConverter));
            _connectionGenerator = connectionGenerator ?? throw new ArgumentNullException(nameof(connectionGenerator));
        }

        public IResponse Handle(IPassport passport)
        {
            if (passport == null)
                throw new ArgumentNullException(nameof(passport));

            string request = _requestConverter.Convert(passport.Number);
            string connection = _connectionGenerator.Generate();

            return TryFind(request, connection);
        }

        private IResponse TryFind(string requestCommand, string connectionCommand)
        {
            Response response;

            try
            {
                SqliteConnection connection = new SqliteConnection(connectionCommand);
                DataTable dataTable1 = new DataTable();

                connection.Open();

                SqliteCommand request = new SqliteCommand(requestCommand, connection);
                var reader = request.ExecuteReader();

                dataTable1.Load(reader);

                if (dataTable1.Rows.Count > 0)
                    response = FindInTable(dataTable1);
                else
                    response = new Response(true,MessageNumberNotFound);

                connection.Close();
            }
            catch (SqliteException ex)
            {
                if (ex.ErrorCode != 1)
                    throw new NotImplementedException("Не реализованно");

                response = new Response(false,MessageDataBaseNotFound);
            }

            return response;
        }

        private Response FindInTable(DataTable dataTable)
        {
            if (Convert.ToBoolean(dataTable.Rows[0].ItemArray[1]))
                return new Response(true, MessageAccessCompleted);
            else
                return new Response(true, MessageAccessDenied);
        }
    }
}