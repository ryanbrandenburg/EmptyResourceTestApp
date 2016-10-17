using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;

namespace EmptyResource
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var language = new CultureInfo("sv");

#if NET451
            System.Threading.Thread.CurrentThread.CurrentCulture = language;
            System.Threading.Thread.CurrentThread.CurrentUICulture = language;
#else
            CultureInfo.CurrentCulture = language;
            CultureInfo.CurrentUICulture = language;
#endif

            var assembly = typeof(Program).GetTypeInfo().Assembly;
            var resourceManager = new ResourceManager("EmptyResource.Resources.Program", assembly);

            var output = resourceManager.GetString("Hello");

            Console.WriteLine(output);

            Console.ReadLine();
        }
    }
}
