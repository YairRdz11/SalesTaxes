using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ImportedExcent : Product
    {
        private const double ImportedTaxes = 0.05;
        public ImportedExcent(long id, string name, double cost) : base(id, name, cost)
        {
            SetTaxes(CalculateTax(cost));
            SetTotal();
        }


        private double CalculateTax(double cost)
        {
            return Math.Ceiling((cost * ImportedTaxes) * 20) / 20;
        }
    }
}
