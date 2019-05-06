using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Generators
{
    public interface IObjectGenerator<T>
    {
        T Object { get; }
    }
}
