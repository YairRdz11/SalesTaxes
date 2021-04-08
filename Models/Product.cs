using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Product
    {
        protected const int precisionDigits = 2;
        public long Id { get; }
        public string Name { get; }
        public double Cost { get; }
        public double Taxes { get; private set; }
        public double Total { get; private set; }
        public bool Checked { get; private set; }

        protected Product(long id, string name, double cost)
        {
            Id = id;
            Name = name.Trim();
            Cost = cost;
            Checked = false;
        }

        public void Check()
        {
            Checked = true;
        }

        protected void SetTaxes(double taxes)
        {
            Taxes = taxes;
        }
        protected void SetTotal()
        {
            Total = Math.Round((Math.Round(Cost, precisionDigits) + Taxes), 2);
        }

        public bool Equals(Product obj)
        {
            return Id == obj.Id && string.Equals(Name, obj.Name, StringComparison.CurrentCultureIgnoreCase) &&
                   Cost == obj.Cost && Taxes == obj.Taxes && Total == obj.Total;
        }

        public override string ToString()
        {
            return $"{Name} at {Cost}";
        }
    }
}
