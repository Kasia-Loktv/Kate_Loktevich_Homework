using System;

namespace Princess
{
    
    class Program
    {
       
        static void Main(string[] args)
        {
            bool isStart = true;
            while (isStart)
            {
                Prince prince = new Prince();
                Game game = new Game();
                string[,] trap = new string[11, 11];
                
                game.GetTraps(ref trap);
                bool isContinue = true;
                while (isContinue)
                {
                    game.PrintField(ref prince);
                    prince.PrintHP(); 
                    game.MovePrince( ref prince);                     
                    game.FallIntoTrap(ref prince, ref trap);
                    game.FinishGame(ref prince, ref isStart, ref isContinue);                    
                }
            }
            Console.ReadKey();
        }
    }
}
