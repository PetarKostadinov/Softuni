using System;

namespace Backend.Services.Menu.Interfaces
{
    public interface IMainMenuService
    {
        string BuildMainMenuNavigation();
        bool ValidateMenuInputCommand(ConsoleKey inputCommand);
        string MenuCommandHandler(ConsoleKey inputCommand, string inputValue);
    }
}
