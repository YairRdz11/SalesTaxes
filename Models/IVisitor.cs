namespace Models
{
    public interface IVisitor
    {
        double Visit(Basic basic);
        double Visit(ImportedExcent imported);
    }
}
