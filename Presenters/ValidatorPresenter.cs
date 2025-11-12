using Lesson27.Views;
using Lesson27.Models.Interfaces;

namespace Lesson27.Presenters
{
    public class ValidatorPresenter
    {
        IUserInterfaceView _view;
        IValidatorModel _validator;

        public ValidatorPresenter(IUserInterfaceView view,IValidatorModel validator)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));

            SubscribeToAll();
        }

        private void SubscribeToAll()
        {
            _view.ButtonClicked += Validate;
            _validator.Unverified += SendMessage;
        }

        public void Validate() => 
            _validator.Validate(_view.UserInput);

        private void SendMessage(string message) => 
            _view.SetMessage(message);
    }
}