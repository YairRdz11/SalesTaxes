using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IProduct : IVisitable
    {
        long Id { get; }
        string Name { get; }
        double Cost { get; }
    }
}
