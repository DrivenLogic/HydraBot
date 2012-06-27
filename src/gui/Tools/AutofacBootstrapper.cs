using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Autofac;
using Caliburn.Micro;
using IContainer = Autofac.IContainer;

namespace HydraBot.Gui.Tools
{
    public class AutofacBootstrapper<TRootViewModel> : Bootstrapper<TRootViewModel>
    {
        private IContainer _container;

        protected IContainer Container
        {
            get { return _container; }
        }

        protected override void Configure()
        {
            // set up NLog
            LogManager.GetLog = t => new NLogAdaptor();

            // Autofac builder
            var builder = new ContainerBuilder();

            // register the shell
            builder.RegisterAssemblyTypes(AssemblySource.Instance.ToArray())
                .Where(type => type.Name.Equals("ShellViewModel"))
                .AsSelf()
                .SingleInstance();

            //  register view models
            builder.RegisterAssemblyTypes(AssemblySource.Instance.ToArray())
                .Where(type => type.Name.EndsWith("ViewModel"))
                //  must be in a namespace ending with ViewModels
                .Where(type => !(string.IsNullOrWhiteSpace(type.Namespace)) && type.Namespace.EndsWith("ViewModels"))
                //  must implement INotifyPropertyChanged (deriving from PropertyChangedBase will statisfy this)
                .Where(type => type.GetInterface(typeof (INotifyPropertyChanged).Name) != null)
                //  registered as self
                .AsSelf()
                .InstancePerDependency();

            //  register views
            builder.RegisterAssemblyTypes(AssemblySource.Instance.ToArray())
                //  must be a type that ends with View
                .Where(type => type.Name.EndsWith("View"))
                .AsSelf()
                .InstancePerDependency();

            //  register the single window manager for this container
            builder.Register<IWindowManager>(c => new WindowManager())
                .As<IWindowManager>()
                .InstancePerLifetimeScope();

            //  register the single event aggregator for this container
            builder.Register<IEventAggregator>(c => new EventAggregator()).InstancePerLifetimeScope();

            _container = builder.Build();
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                if (Container.IsRegistered(serviceType))
                    return Container.Resolve(serviceType);
            }
            // [AS] seems autofac has moved on?
            //else
            //{
                
            //    if (Container.IsRegistered(key, serviceType))
            //        return Container.Resolve(key, serviceType);
            //}
            throw new Exception(string.Format("Could not locate any instances of contract {0}.", key ?? serviceType.Name));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return Container.Resolve(typeof (IEnumerable<>).MakeGenericType(serviceType)) as IEnumerable<object>;
        }

        protected override void BuildUp(object instance)
        {
            Container.InjectProperties(instance);
        }
    }
}

