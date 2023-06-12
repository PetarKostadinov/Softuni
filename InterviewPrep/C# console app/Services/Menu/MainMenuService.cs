using Backend.Helpers.Constants;
using Backend.Services.Menu.Interfaces;
using Backend.Services.MovieStar.Interfaces;
using Backend.Services.Salary.Interfaces;
using System;
using System.Linq;
using System.Text;

namespace Backend.Services.Menu
{
    public class MainMenuService : IMainMenuService
    {
        private readonly string movieStarsResult;
        private readonly ConsoleKey[] allowedInputValues = new ConsoleKey[] { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3 };

        private readonly IMovieStarService movieStarService;
        private readonly ISalaryCalculatorService salaryCalculatorService;

        public MainMenuService(IMovieStarService movieStarService, ISalaryCalculatorService salaryCalculatorService)
        {
            this.movieStarService = movieStarService;
            this.salaryCalculatorService = salaryCalculatorService;

            movieStarsResult = this.movieStarService.GetMovieStarsResult();
        }

        public string BuildMainMenuNavigation()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Main Menu");
            sb.AppendLine("---------");
            sb.AppendLine();
            sb.AppendLine("1. View Movie Stars List");
            sb.AppendLine("2. Calculate Net Salary");
            sb.AppendLine("3. Exit");

            return sb.ToString();
        }

        public string MenuCommandHandler(ConsoleKey inputCommand, string inputValue)
        {
            switch (inputCommand)
            {
                case ConsoleKey.D1:
                    return movieStarsResult;
                case ConsoleKey.D2:
                    return this.salaryCalculatorService.CalculateSalary(inputValue);
                default: 
                    return ErrorMessages.InvalidCommandErrorMessage;
            }
        }

        public bool ValidateMenuInputCommand(ConsoleKey inputCommand) 
            => this.allowedInputValues.Contains(inputCommand);
    }
}
