using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Generators
{
    public static class GeneratorFactory
    {
        public static ObjectGenerator<TEntity> Create<TEntity>()
          where TEntity : class, new()
          => Activator.CreateInstance<ObjectGenerator<TEntity>>();
    }
}
