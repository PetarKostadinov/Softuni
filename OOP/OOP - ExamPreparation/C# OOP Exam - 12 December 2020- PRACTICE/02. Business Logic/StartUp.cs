namespace Bakery
{
    using Bakery.Core;
    using System.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            File.Delete(@"../../../result.txt");
            //Don't forget to comment out the commented code lines in the Engine class!
            var engine = new Engine();

           

            engine.Run();

            

        }
    }
}
