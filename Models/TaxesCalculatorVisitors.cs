using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TaxesCalculatorVisitors : IVisitor
    {
        private const int Pressition = 2;
        private const double BasicTaxes = 0.1;
        private const double ImportedTaxes = 0.05;
        public double Visit(Basic basic)
        {
            return Math.Round(basic.Cost * BasicTaxes, Pressition);
        }

        public double Visit(ImportedExcent imported)
        {
            return Math.Round(imported.Cost * ImportedTaxes, Pressition);
        }
    }
}
