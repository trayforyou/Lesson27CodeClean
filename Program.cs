using Lesson27.Views;
using Lesson27.Models;
using Lesson27.Presenters;
using Lesson27.Services;
using Lesson27.Services.Infrastructure;

namespace Lesson27
{
    public class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository(new RequestConverter(), new ConnectionGenerator(), new DataService());
            Service service = new Service(new HasherSHA256(), repository);
            Presenter presenter = new Presenter(service, new Validator());

            Menu menu = new Menu(new TextBox(), new MessageBox(), presenter);
            presenter.InitializeMessager(menu);
        }
    }
}