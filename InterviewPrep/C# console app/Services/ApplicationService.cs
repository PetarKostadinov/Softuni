using Backend.Helpers.Constants;
using Backend.Models.Interfaces;
using Backend.Services.Menu.Interfaces;
using log4net;
using System;

namespace Backend.Services
{
    public class ApplicationService : IApplicationService
    {
        //Here you should create Menu which your Console application will show to user
        //User should be able to choose between: 1. Movie star 2. Calculate Net salary 3. Exit

        private readonly ILog logger;
        private readonly IMainMenuService mainMenuService;

        public ApplicationService(ILog logger, IMainMenuService mainMenuService)
        {
            this.logger = logger;
            this.mainMenuService = mainMenuService;
        }

        public void Run()
        {
            DisplayMenu();
            StartProcess();
        }

        private void DisplayMenu()
        {
            try
            {
                var mainMenuResult = this.mainMenuService.BuildMainMenuNavigation();

                Console.WriteLine(mainMenuResult);
            }
            catch (Exception ex)
            {
                this.logger.Error(ErrorMessages.MainMenuBuildErrorMessage, ex);
                Console.WriteLine(ErrorMessages.MainMenuBuildErrorMessage);

                Environment.Exit(42);
            }
        }

        private void StartProcess()
        {
            try
            {
                while (true)
                {
                    var inputCommand = Console.ReadKey();
                    Console.WriteLine();

                    var isValidInputCommand = this.mainMenuService.ValidateMenuInputCommand(inputCommand.Key);

                    if (!isValidInputCommand) PrintErrorMessage();

                    if (inputCommand.Key == ConsoleKey.D3) return;

                    string inputValue = null;
                    if (inputCommand.Key == ConsoleKey.D2)
                    {
                        Console.WriteLine("Please, enter salary:");
                        inputValue = Console.ReadLine();
                    }

                    var result = this.mainMenuService.MenuCommandHandler(inputCommand.Key, inputValue);

                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ErrorMessages.FailedProcessErrorMessage, ex);
                Console.WriteLine(ErrorMessages.FailedProcessErrorMessage);

                Environment.Exit(43);
            }
        }

        private static void PrintErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine(ErrorMessages.InvalidCommandErrorMessage);
        }
    }
}
