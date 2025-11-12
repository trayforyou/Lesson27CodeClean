using Lesson27.Models.Interfaces;
using Lesson27.Views;

namespace Lesson27.Presenters
{
    public class DataBasePresenter
    {
        private readonly IResultator _validator;
        private readonly IDataBaseHandler _handler;
        private readonly IMessager _messager;

        public DataBasePresenter(IResultator validator, IDataBaseHandler handler, IMessager messager)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _messager = messager ?? throw new ArgumentNullException(nameof(messager));
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));

            _validator.ResultReady += HandlePassport;
        }

        private void HandlePassport(IPassport passport)
        {
            if (passport == null)
                throw new ArgumentNullException(nameof(passport));

            IResponse response = _handler.Handle(passport);

            ShowResult(response);
        }

        private void ShowResult(IResponse response)
        {
            if (response.IsConnected == false)
                _messager.SetMessage(response.Message);
            else
                _messager.SetMessage(string.Format(response.Message)); 
        }
    }
}