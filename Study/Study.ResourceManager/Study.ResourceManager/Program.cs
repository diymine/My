using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Study.ResourceManager
{
    class Program
    {
        static void Main(string[] args)
        {

            string day;
            string year;
            string holiday;
            string celebrate = "{0} will occur on {1} in {2}.\n";

            // Create a resource manager. The GetExecutingAssembly() method
            // gets rmc.exe as an Assembly object.

            System.Resources.ResourceManager rm = new System.Resources.ResourceManager("Study.ResourceManager.Text",
                                     Assembly.GetExecutingAssembly());

            // Obtain resources using the current UI culture.
            Console.WriteLine("Obtain resources using the current UI culture.");

            // Get the resource strings for the day, year, and holiday 
            // using the current UI culture. Use those strings to 
            // display a message.

            day = rm.GetString("day");
            year = rm.GetString("year");
            holiday = rm.GetString("holiday");
            Console.WriteLine(celebrate, holiday, day, year);

            // Obtain the es-ES culture.
            CultureInfo ci = new CultureInfo("en-US");

            // Get the resource strings for the day, year, and holiday 
            // using the specified culture. Use those strings to 
            // display a message. 

            // Obtain resources using the es-ES culture.
            Console.WriteLine("Obtain resources using the en-US culture.");

            day = rm.GetString("day", ci);
            year = rm.GetString("year", ci);
            holiday = rm.GetString("holiday", ci);

            // ---------------------------------------------------------------
            // Alternatively, comment the preceding 3 code statements and 
            // uncomment the following 4 code statements:
            // ----------------------------------------------------------------

            // Set the current UI culture to "es-ES" (Spanish-Spain).
            //    Thread.CurrentThread.CurrentUICulture = ci;

            // Get the resource strings for the day, year, and holiday 
            // using the current UI culture. Use those strings to 
            // display a message. 
            //    day  = rm.GetString("day");
            //    year = rm.GetString("year");
            //    holiday = rm.GetString("holiday");
            // ---------------------------------------------------------------

            // Regardless of the alternative that you choose, display a message 
            // using the retrieved resource strings.
            Console.WriteLine(celebrate, holiday, day, year);
            Console.ReadLine();
        }
    }
}
