using Lesson27.Enums;
using Lesson27.Models;
using Lesson27.Services;
using Lesson27.Views;

namespace Lesson27.Presenters
{
    public class Presenter
    {
        private readonly Service _service;
        private readonly Validator _validator;

        private IMessager _messager;
        private bool _isInitializedMessager;

        public Presenter(Service service, Validator validator)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));

            _isInitializedMessager = false;
        }

        public void InitializeMessager(IMessager messager)
        {
            if (_isInitializedMessager)
                throw new InvalidOperationException("Уже инициализирован");

            _messager = messager ?? throw new ArgumentNullException(nameof(messager));
            _isInitializedMessager = true;
        }

        private void ShowResult(Citizen citizen, Passport passport)
        {
            switch (citizen.State)
            {
                case CitizenStates.NoInfo:
                    _messager.SetMessage("Файл db.sqlite не найден. Положите файл в папку вместе с exe.");
                    break;

                case CitizenStates.NotGranted:
                    _messager.SetMessage(string.Format(
                        "По паспорту «{0}» доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ",
                        passport.Number));
                    break;

                case CitizenStates.NotFound:
                    _messager.SetMessage(string.Format(
                        "Паспорт «{0}» в списке участников дистанционного голосования НЕ НАЙДЕН", passport.Number));
                    break;

                case CitizenStates.Granted:
                    _messager.SetMessage(string.Format(
                        "По паспорту «{0}» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН",
                        passport.Number));
                    break;
            }
        }

        public void Handle(string rawNumber)
        {
            if (_isInitializedMessager == false)
                throw new InvalidOperationException($"{nameof(_messager)} не инициализирован");

            ValidationNumberStates result = _validator.TryValidate(rawNumber);

            switch (result)
            {
                case ValidationNumberStates.Success:
                    string number = rawNumber.Replace(" ", string.Empty);

                    Passport passport = new Passport(number);

                    Citizen citizen = _service.Handle(passport);

                    ShowResult(citizen, passport);
                    break;

                case ValidationNumberStates.IncorrectFormat:
                    _messager.SetMessage("Неверный формат серии или номера паспорта");
                    break;

                case ValidationNumberStates.Empty:
                    _messager.SetMessage("Введите серию и номер паспорта");
                    break;
            }
        }
    }
}