namespace Models
{
    public class Exempt : Product
    {
        public Exempt(string name, double cost) : base(name, cost)
        {
            SetTaxes(0);
            SetTotal();
        }
    }
}
