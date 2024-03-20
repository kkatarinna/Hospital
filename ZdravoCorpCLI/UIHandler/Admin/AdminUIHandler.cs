using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Enum;
using Hospital.Service;
using ZdravoCorpCLI.Utils;

namespace ZdravoCorpCLI.UIHandler
{
    public class AdminMenuUIHandler
    {

        RenovationMenuUIHandler renovationUIHandler;

        public AdminMenuUIHandler()
        {
            renovationUIHandler = new RenovationMenuUIHandler();
        }

        public void handleAdminMenu()
        {
            

            string answer;
            do
            {
                Console.WriteLine("\nChoose an option :");
                Console.WriteLine("1 - Complex Renovations");
                Console.WriteLine("x - Exit");


                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        renovationUIHandler.handleRenovationMenu();
                        break;
                }

            } while (answer != "x");
        }

       


    }
}
