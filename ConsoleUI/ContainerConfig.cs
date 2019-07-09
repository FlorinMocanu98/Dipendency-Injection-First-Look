using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI {
    public static class ContainerConfig {

        public static IContainer Configure() {

            // Create a new instance of the container
            var builder = new ContainerBuilder();

            // Simple one-to-one registration
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
            builder.RegisterType<Application>().As<IApplication>();

            // Registration of an entire folder of classes+interfaces
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary))).
                Where(t => t.Namespace.Contains("Utilities")).
                As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
