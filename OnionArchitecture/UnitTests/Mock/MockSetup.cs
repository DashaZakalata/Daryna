using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mock
{
    public sealed class MockSetup
    {
        public Mock<DbSet<T>> GetMockedDBSet<T>() where T : class
        {
            return GetMockedDBSet(new List<T>());
        }
        public Mock<DbSet<T>> GetMockedDBSet<T>(T data) where T : class
        {
            List<T> list = new List<T> { data };
            return GetMockedDBSet(list);
        }

        public Mock<DbSet<T>> GetMockedDBSet<T>(List<T> data) where T : class
        {
            var mockDbSet = new Mock<DbSet<T>>();
            var q = mockDbSet.As<IQueryable<T>>();
            // Some don't have [key] attribute
            var defaultPrimaryKey = "Id";

            q.Setup(m => m.Provider).Returns(() => new TestDbAsyncQueryProvider<T>(data.AsQueryable().Provider));
            q.Setup(m => m.Expression).Returns(() => data.AsQueryable().Expression);
            q.Setup(m => m.ElementType).Returns(() => data.AsQueryable().ElementType);
            q.Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
            mockDbSet.As<IDbAsyncEnumerable<T>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<T>(data.GetEnumerator()));

            mockDbSet.Setup(m => m.Add(It.IsAny<T>()))
                .Returns<T>(i =>
                {
                    var idProp = i.GetType().GetProperty(defaultPrimaryKey);
                    if (idProp != null && (int)idProp.GetValue(i) == 0)
                        idProp.SetValue(i, data.Max(x => ((dynamic)x).Id) + 1);
                    data.Add(i);
                    return i;
                });
            mockDbSet.Setup(m => m.AddRange(It.IsAny<IEnumerable<T>>()))
                .Returns<IEnumerable<T>>(enumerable =>
                {
                    foreach (var i in enumerable)
                    {
                        var idProp = i.GetType().GetProperty(defaultPrimaryKey);
                        if (idProp != null && (int)idProp.GetValue(i) == 0)
                            idProp.SetValue(i, data.Max(x => ((dynamic)x).Id) + 1);
                        data.Add(i);
                    }
                    return enumerable;
                });
            mockDbSet.Setup(m => m.Remove(It.IsAny<T>()))
                .Returns<T>(i =>
                {
                    data.Remove(i);
                    return i;
                });
            mockDbSet.Setup(m => m.Find(It.IsAny<object[]>()))
                .Returns((object[] i) =>
                {
                    return data.FirstOrDefault(x => ((dynamic)x).Id == (int)i[0]);
                });
            mockDbSet.Setup(x => x.AsNoTracking()).Returns(mockDbSet.Object);
            mockDbSet.Setup(s => s.Include(It.IsAny<string>())).Returns(mockDbSet.Object);

            return mockDbSet;
        }
    }
}
