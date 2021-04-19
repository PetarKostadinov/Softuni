namespace SantaWorkshop
{
    using System;
    using System.IO;
    using SantaWorkshop.Core;
    using SantaWorkshop.Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            File.Delete(@"../../../result.txt");

            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
