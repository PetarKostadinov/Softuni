using Autofac;
using Backend.Helpers.Services;
using Backend.Helpers.Services.Interfaces;
using Backend.Helpers.Services.Logger;
using Backend.Models.Interfaces;
using Backend.Services;
using Backend.Services.Menu;
using Backend.Services.Menu.Interfaces;
using Backend.Services.MovieStar;
using Backend.Services.MovieStar.Interfaces;
using Backend.Services.Salary;
using Backend.Services.Salary.Interfaces;
using Backend.Services.Tax;
using Backend.Services.Tax.Interfaces;
using log4net;

namespace Backend
{
    class Program
    {
        //This is your app entry point
        static void Main(string[] args)
        {
            var container = ConfigureContainer();

            //Get your application menu class
            var application = container.Resolve<IApplicationService>();

            //Run your application
            application.Run();
        }

        //You should configure DI container (Autofac) or other DI Framework
        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            RegisterGlobalServices(builder);

            RegisterMenuServices(builder);
            RegisterMovieStarsServices(builder);
            RegisterTaxCalculatorServices(builder);
            RegisterSalaryCalculatorServices(builder);


            builder.RegisterType<Logger>().As<ILog>();

            //Here you should register Interfaces with their referent classes

            return builder.Build();
        }

        private static void RegisterMenuServices(ContainerBuilder builder)
        {
            builder.RegisterType<MainMenuService>().As<IMainMenuService>();
        }

        private static void RegisterGlobalServices(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationService>().As<IApplicationService>();
        }

        private static void RegisterMovieStarsServices(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeService>().As<IDateTimeService>();
            builder.RegisterType<MovieStarService>().As<IMovieStarService>();
        }

        private static void RegisterTaxCalculatorServices(ContainerBuilder builder)
        {
            builder.RegisterType<TaxService>().As<ITaxService>();
        }

        private static void RegisterSalaryCalculatorServices(ContainerBuilder builder)
        {
            builder.RegisterType<SalaryCalculatorService>().As<ISalaryCalculatorService>();
        }
    }
}
