using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorpCLI.Utils
{
    public static class UserInputUtil
    { 
        public static int GetIntFromUser() {
            
            int number;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Not a number");
                }
                else return number;

            }
        }



    }
}
