using ExtremeStudio.ViewModels;
using System;
using System.Collections.Generic;
using Caliburn.Micro;
using ExtremeStudio.Classes;
using MahApps.Metro.Controls.Dialogs;
using Metro.Dialogs;

namespace ExtremeStudio {

    public class AppBootstrapper : BootstrapperBase {
        SimpleContainer _container;

        public AppBootstrapper() {
            Initialize();
        }

        protected override void Configure()
        {
            _container = new SimpleContainer();

            //Subscribe Managers.
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.Singleton<IWindowsDialogs, WindowsDialogs>();
            _container.Singleton<IDialogCoordinator, DialogCoordinator>();

            //Subscribe Forms.
            _container.PerRequest<StartupViewModel>();

            //Subscribe Global Classes
            _container.Singleton<CurrentProjectClass>();
        }

        protected override object GetInstance(Type service, string key) {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service) {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance) {
            _container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e) {
            DisplayRootViewFor<StartupViewModel>();
        }
    }
}