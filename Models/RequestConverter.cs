using Lesson27.Models.Interfaces;

namespace Lesson27.Models
{
    public class RequestConverter : IConverter
    {
        private const string FirstPartOfRequest = "select * from passports where num='{";
        private const string LastPartOfRequest = "}' limit 1;";

        private readonly IHasher _hasher;

        public RequestConverter(IHasher hasher)
        {
            _hasher = hasher ?? throw new ArgumentNullException(nameof(hasher));
        }

        public string Convert(string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException(nameof(number));

            number = _hasher.GetHash(number);

            string request = $"{FirstPartOfRequest}{number}{LastPartOfRequest}";

            return request;
        }
    }
}