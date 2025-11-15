using Lesson27.Services.Interfaces;

namespace Lesson27.Services
{
    public class RequestConverter : IConverter
    {
        private const string FirstPartOfRequest = "select * from passports where num='{";
        private const string LastPartOfRequest = "}' limit 1;";

        public string Convert(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentNullException(nameof(number));

            string request = $"{FirstPartOfRequest}{number}{LastPartOfRequest}";

            return request;
        }
    }
}