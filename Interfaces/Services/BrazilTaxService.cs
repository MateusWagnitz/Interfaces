using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Services
{
    class BrazilTaxService : ITaxService  //subtipo de ItaxService mesmo símbolo da herança : para realização de interface
    {
        public double Tax(double amount)
        {
            if (amount <= 100.00)
            {
                return amount * 0.2;
            }
            else
            {
                return amount * 0.15;
            }
        }
    }
}
