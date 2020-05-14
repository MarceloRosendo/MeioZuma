using System;
using System.IO;

namespace MeioZuma
{
    internal class Program
    {
        private static String presentation; 
        
        public static void Main(string[] args)
        {
            String file = File.ReadAllText("home.txt");
            Console.WriteLine(file);
        }

        private void gameloop()
        {
            
        }
        
    }
}