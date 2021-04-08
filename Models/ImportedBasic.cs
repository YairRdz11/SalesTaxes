using System;

namespace Models
{
    public class ImportedBasic : Product
    {
        private const double ImportedTaxes = 0.05;
        private const double BasicTaxes = 0.1;
        public ImportedBasic(long id, string name, double cost) : base(id, name, cost)
        {
            SetTaxes(CalculateTax(cost));
            SetTotal();
        }

        private double CalculateTax(double cost)
        {
            var taxesByBasic = Math.Ceiling((cost * BasicTaxes) * 20) / 20;
            var taxesByImpotation = Math.Ceiling((cost * ImportedTaxes) * 20) / 20;
            return Math.Ceiling((taxesByImpotation + taxesByBasic)*20)/20;
        }
    }
}
