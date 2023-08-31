using Microsoft.EntityFrameworkCore;
using MusicLibrary.Core.Models.Abstract;
using MusicLibrary.Data.DbContexts;
using MusicLibrary.Tests.Setup.Builders.Abstract;

namespace MusicLibrary.Tests.Setup.Builders.DbContexts;

internal class MusicLibraryDbContextMockBuilder
    : BaseMockBuilder<MusicLibraryDbContextMockBuilder, MusicLibraryDbContext>
{
    /// <summary>
    /// Mocks the FindAsync() method.
    /// </summary>
    /// <param name="entity">The entity to be returned.</param>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public MusicLibraryDbContextMockBuilder SetupFindAsync<TEntity>(TEntity entity)
        where TEntity : Entity
    {
        Mock.Setup(dbContext => dbContext.FindAsync<TEntity>(It.IsAny<object[]>())).ReturnsAsync(entity);
        return this;
    }

    /// <summary>
    /// Mocks the Set{TEntity}() method.
    /// </summary>
    /// <param name="entities">The models to be populated in the <see cref="DbSet{TEntity}"/>.</param>
    public MusicLibraryDbContextMockBuilder SetupSet<TEntity>(params TEntity[] entities)
        where TEntity : Entity
    {
        Mock.Setup(dbContext => dbContext.Set<TEntity>()).Returns(SetupDbSet(entities));
        return this;
    }

    private static DbSet<TEntity> SetupDbSet<TEntity>(ICollection<TEntity> entities)
        where TEntity : Entity
    {
        var query = entities.AsQueryable();
        var dbSetMock = new Mock<DbSet<TEntity>>();

        dbSetMock.As<IQueryable<TEntity>>().Setup(dbSet => dbSet.Provider).Returns(query.Provider);
        dbSetMock.As<IQueryable<TEntity>>().Setup(dbSet => dbSet.Expression).Returns(query.Expression);
        dbSetMock.As<IQueryable<TEntity>>().Setup(dbSet => dbSet.ElementType).Returns(query.ElementType);
        dbSetMock.As<IQueryable<TEntity>>().Setup(dbSet => dbSet.GetEnumerator()).Returns(() => query.GetEnumerator());
        dbSetMock.Setup(dbSet => dbSet.Add(It.IsAny<TEntity>())).Callback<TEntity>(entities.Add);

        return dbSetMock.Object;
    }
}