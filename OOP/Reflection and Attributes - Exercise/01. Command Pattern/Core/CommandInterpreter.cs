using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {

        private const string COMMAND_POSTFIX = "Command";

        public CommandInterpreter()
        {

        }
        public string Read(string args)
        {
            string[] commandTokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string commandName = commandTokens[0] + COMMAND_POSTFIX;

            string[] commandArgs = commandTokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(x => x.Name.ToLower() == commandName.ToLower());

            if (type == null)
            {
                throw new ArgumentException("Invalid command type!");

            }

            ICommand instance = (ICommand)Activator.CreateInstance(type);

            string result = instance.Execute(commandArgs);

            return result;
        }
    }
}
