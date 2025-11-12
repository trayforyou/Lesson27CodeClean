using Lesson27.UIElements;
using Lesson27.Views;
using Lesson27.Models;
using Lesson27.Presenters;

namespace Lesson27
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu(new TextBox(), new Button(), new MessageBox());
            HasherSHA256 hasher = new HasherSHA256();
            RequestConverter requestConverter = new RequestConverter(hasher);
            ConnectionGenerator connectionGenerator = new ConnectionGenerator();

            ValidatorModel validator = new ValidatorModel();
            DataBaseHandler dataBaseHandler = new DataBaseHandler(requestConverter, connectionGenerator);

            ValidatorPresenter validatorPresenter = new ValidatorPresenter(menu, validator);
            DataBasePresenter dataBasePresenter = new DataBasePresenter(validator, dataBaseHandler, menu);
        }
    }
}