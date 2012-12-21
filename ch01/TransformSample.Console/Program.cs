namespace TransformSample.Console {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program {
        static void Main(string[] args) {
            AppConfig config = new AppConfig();

            // print out the app settings as well as connection string
            System.Console.WriteLine("************ App Settings ************");
            System.Console.WriteLine(config.GetAppSettingsAsText());

            System.Console.WriteLine("************ Connection Strings ************");
            System.Console.WriteLine(config.GetConnectionStringsAsText());

            System.Console.WriteLine("Press any key to exit");
            System.Console.ReadKey();
        }
    }
}
