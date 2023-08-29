using MusicLibrary.Core.Contracts.Units;
using MusicLibrary.Tests.Setup.Builders.Abstract;

namespace MusicLibrary.Tests.Setup.Builders.UnitsOfWork;

internal sealed class UnitOfWorkMockBuilder : BaseMockBuilder<UnitOfWorkMockBuilder, IUnitOfWork>
{
    /// <summary>
    /// Mocks the SaveChangesAsync() method.
    /// </summary>
    public UnitOfWorkMockBuilder SetupSaveChangesAsync()
    {
        Mock.Setup(unitOfWork => unitOfWork.SaveChangesAsync()).ReturnsAsync(default(int));
        return this;
    }
}