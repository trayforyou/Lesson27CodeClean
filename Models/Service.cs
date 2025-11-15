using Lesson27.Services.Interfaces;

namespace Lesson27.Models
{
    public class Service
    {
        private readonly IHasher _hasher;
        private readonly Repository _repository;

        public Service(IHasher hasher, Repository repository)
        {
            _hasher = hasher ?? throw new ArgumentNullException(nameof(hasher));
            _repository = repository ?? throw new ArgumentNullException(nameof(_repository));
        }

        public Citizen Handle(Passport passport)
        {
            if (passport is null)
                throw new ArgumentNullException(nameof(passport));

            string hash = _hasher.GetHash(passport.Number);
            Citizen citizen = _repository.Handle(hash);

            return citizen;
        }
    }
}