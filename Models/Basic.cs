using System;

namespace Models
{
    public class Basic : Product
    {
        private const double BasicTaxes = 0.1;
        public Basic(long id, string name, double cost) : base(id, name, cost)
        {
            SetTaxes(CalculateTax(cost));
            SetTotal();
        }


        private double CalculateTax(double cost)
        {
            return Math.Ceiling((cost * BasicTaxes) * 20) / 20;
        }

    }
}
