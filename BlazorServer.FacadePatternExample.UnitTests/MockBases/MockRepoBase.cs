using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Repositories;
using Moq;

namespace BlazorServer.FacadePatternExample.UnitTests.MockBases
{
    public static class MockRepoBase
    {
        public static Mock<TRepo> MockRepo<TRepo, T>(ICollection<T> list)
           where TRepo : class, IRepositoryBase<T>
           where T : ModelBase
        {
            var mock = new Mock<TRepo>();

            mock.Setup(x => x.Add(It.IsAny<T>())).Returns((T x) =>
            {
                x.Id = list.Count() + 1;
                list.Add(x);
                return x;
            });

            mock.Setup(x => x.GetById(It.IsAny<int>())).Returns((int x) => { return list.FirstOrDefault(y => y.Id == x); });

            mock.Setup(x => x.GetAll()).Returns(() => list);

            mock.Setup(x => x.Update(It.IsAny<T>())).Returns((T Entity) => { return Entity; });

            mock.Setup(x => x.Delete(It.IsAny<T>())).Returns((T Entity) => { return !list.Contains(Entity); });

            mock.Setup(x => x.Filter(It.IsAny<Func<T, Boolean>>())).Returns((Func<T, bool> x) => { return list.Where(x); });

            return mock;
        }
    }
}
