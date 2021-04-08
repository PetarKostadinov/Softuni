namespace CounterStrike
{
    using CounterStrike.Core;
    using CounterStrike.Core.Contracts;
    using System.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            File.Delete(@"../../../result.txt");
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
