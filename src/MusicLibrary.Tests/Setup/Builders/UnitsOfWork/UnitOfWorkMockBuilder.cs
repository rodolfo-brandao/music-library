using MusicLibrary.Core.Contracts.Units;

namespace MusicLibrary.Tests.Setup.Builders.UnitsOfWork
{
    internal sealed class UnitOfWorkMockBuilder
    {
        private readonly Mock<IUnitOfWork> _mock;

        public UnitOfWorkMockBuilder()
        {
            _mock = new Mock<IUnitOfWork>();
        }

        public IUnitOfWork Build() => _mock.Object;

        public static UnitOfWorkMockBuilder Create() => new();

        /// <summary>
        /// Mocks the SaveChangesAsync() method.
        /// </summary>
        public UnitOfWorkMockBuilder SetupSaveChangesAsync()
        {
            _mock.Setup(unitOfWork => unitOfWork.SaveChangesAsync()).ReturnsAsync(default(int));
            return this;
        }
    }
}
