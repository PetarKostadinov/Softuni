using System.IO;
using OnlineShop.Core;
using OnlineShop.IO;

namespace OnlineShop
{
    public class StartUp
    {
        static void Main()
        {
            //Clears output.txt file
            File.Delete(@"../../../result.txt");
          

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IController controller = new Controller();

            IEngine engine = new Engine(reader, writer, commandInterpreter, controller);
            engine.Run();
        }
    }
}
