using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Generators
{
    public class ObjectGenerator<TObject> : IObjectGenerator<TObject>
        where TObject : class, new()
    {
        protected readonly TObject obj;

        public TObject Object => this.obj;

        public ObjectGenerator() { obj = (TObject)Activator.CreateInstance(typeof(TObject)); }

        public ObjectGenerator<TObject> Set(Action<TObject> action)
        {
            action.Invoke(Object);

            return this;
        }
        public ObjectGenerator<TEntity> Attach<TEntity>(Action<TObject, TEntity> action)
            where TEntity : class, new()
        {
            var generator = Activator.CreateInstance<ObjectGenerator<TEntity>>();
            if (action != null)
                action(this.obj, generator.Object);

            return generator;
        }
        public ObjectGenerator<TObject> Add<TEntity>(Action<TObject, TEntity> action)
            where TEntity : class, new()
        {
            this.Attach(action);

            return this;
        }
    }

    public abstract class ObjectGenerator<TGenerator, TObject> : ObjectGenerator<TObject>
        where TGenerator : ObjectGenerator<TGenerator, TObject>
        where TObject : class, new()
    {
        public new TGenerator Set(Action<TObject> predicate)
        {
            predicate.Invoke(Object);

            return (TGenerator)this;
        }
    }
}
