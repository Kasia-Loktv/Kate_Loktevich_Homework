using System;

namespace Princess
{
    public class Prince
    {
        private const string Health = "\nHP = {0}  ";

        public int HP { get; set; }
        public int XPrince { get; set; }
        public int YPrince { get; set; }

        public Prince()
        {
            HP = 10;
            XPrince = 1;
            YPrince = 1;
        }

        public void PrintHP()
        {
            Console.WriteLine(Health, HP);
        }
    }
}
