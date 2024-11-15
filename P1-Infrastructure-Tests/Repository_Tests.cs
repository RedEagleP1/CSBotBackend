using Microsoft.EntityFrameworkCore;
using Moq;
using P1_Core.Entities;
using P1_Core.Interfaces;
using P1_Infrastructure;
using P1_Infrastructure.Database;
using P1_Infrastructure.Repositories;

namespace P1_Infrastructure_Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        private Mock<P1DatabaseContext> _mockContext;
        private Mock<DbSet<TestEntity>> _mockDbSet;
        private Repository<TestEntity> _repository;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<P1DatabaseContext>();
            _mockDbSet = new Mock<DbSet<TestEntity>>();
            _mockContext.Setup(m => m.Set<TestEntity>()).Returns(_mockDbSet.Object);
            _repository = new Repository<TestEntity>(_mockContext.Object);
        }

        [Test]
        public async Task Add_ShouldAddEntity()
        {
            var entity = new TestEntity();

            await _repository.AddAsync(entity);

            _mockDbSet.Verify(m => m.Add(It.IsAny<TestEntity>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public async Task Delete_ShouldRemoveEntity()
        {
            var entity = new TestEntity();
            _mockDbSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(entity);

            await _repository.DeleteAsync(entity.Id);

            _mockDbSet.Verify(m => m.Remove(It.IsAny<TestEntity>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public async Task Delete_ShouldThrowExceptionIfEntityNotFound()
        {
            var entity = new TestEntity();
            _mockDbSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns((TestEntity)null);

            Assert.Throws<Exception>(async () => await _repository.DeleteAsync(entity.Id));
        }

        [Test]
        public async Task GetAll_ShouldReturnAllEntities()
        {
            var data = new List<TestEntity> { new TestEntity(), new TestEntity() }.AsQueryable();
            _mockDbSet.As<IQueryable<TestEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            _mockDbSet.As<IQueryable<TestEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            _mockDbSet.As<IQueryable<TestEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _mockDbSet.As<IQueryable<TestEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var result = await _repository.GetAllAsync();

            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetById_ShouldReturnEntity()
        {
            var entity = new TestEntity();
            _mockDbSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(entity);

            var result = await _repository.GetByIdAsync(1);

            Assert.That(result, Is.EqualTo(entity));
        }

        [Test]
        public async Task GetById_ShouldThrowExceptionIfEntityNotFound()
        {
            _mockDbSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns((TestEntity)null);

            Assert.Throws<Exception>(async () => await _repository.GetByIdAsync(1));
        }

        [Test]
        public async Task Update_ShouldUpdateEntity()
        {
            var entity = new TestEntity();
            _mockDbSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(entity);

            await _repository.UpdateAsync(entity);

            _mockDbSet.Verify(m => m.Update(It.IsAny<TestEntity>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void Update_ShouldThrowExceptionIfEntityNotFound()
        {
            var entity = new TestEntity();
            _mockDbSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns((TestEntity)null);

            Assert.Throws<Exception>(async () => await _repository.UpdateAsync(entity));
        }
    }


    public class TestEntity : BaseEntity
    {
    }
}