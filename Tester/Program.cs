using System;

namespace Tester {
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length > 0) {
                if(args[0] == "generate") {
                    Console.WriteLine("Program start, generating files");
                    CodeGenerator.Generate();
                }
            }
            else { 
                using (var game = new Game())
                    game.Run();
            }
        }
    }
#endif
}
