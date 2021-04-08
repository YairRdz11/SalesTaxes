namespace Models
{
    public class Exempt : Product
    {
        public Exempt(long id, string name, double cost) : base(id, name, cost)
        {
            SetTaxes(0);
            SetTotal();
        }
    }
}
