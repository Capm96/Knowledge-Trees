using Caliburn.Micro;
<<<<<<< HEAD
using Services;
using Services.Interfaces;
=======
>>>>>>> d2b9d017515476da329690706a1471df68883430
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserInterface.ViewModels;

namespace UserInterface
{
    public class Bootstrapper : BootstrapperBase
    {
<<<<<<< HEAD
        private SimpleContainer _container = new SimpleContainer();

=======
>>>>>>> d2b9d017515476da329690706a1471df68883430
        public Bootstrapper()
        {
            Initialize();
        }

<<<<<<< HEAD
        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IFolderLogicHandler, FolderLogicHandler>()
                .Singleton<IWordLogicHandler, WordLogicHandler>();

            //_container
            //    .PerRequest<IFolderLogicHandler, FolderLogicHandler>()
            //    .PerRequest<IWordLogicHandler, WordLogicHandler>();

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

=======
>>>>>>> d2b9d017515476da329690706a1471df68883430
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainDashboardViewModel>();
        }
<<<<<<< HEAD

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
=======
>>>>>>> d2b9d017515476da329690706a1471df68883430
    }
}
