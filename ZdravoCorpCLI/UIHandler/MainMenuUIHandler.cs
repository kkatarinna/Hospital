using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorpCLI.UIHandler;

namespace ZdravoCorpCLI.UIHandler
{
    public class MainMenuUIHandler
    {
        private AdminMenuUIHandler adminView;

        public MainMenuUIHandler()
        {
            adminView = new AdminMenuUIHandler();
        }


        public void handleMainMenu() {
           
            string answer;
            do
            {
                Console.Out.WriteLine("\nChoose an option:");
                Console.Out.WriteLine("1 - Admin View");
                Console.Out.WriteLine("x - Exit");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        adminView.handleAdminMenu();
                        break;
                }

            } while (answer != "x");
        }
    }
}
