using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class DebitAccount : Account
    {
        private const string DebitWord = "Дебетовый";

        public override string GetAccountInformation()
        {
            return DebitWord + AccountWord + Name + BalanceWord + Balance;
        }
    }
}
