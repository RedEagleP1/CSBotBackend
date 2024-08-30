using Microsoft.EntityFrameworkCore;
using Moq;
using P1_Infrastructure;
using P1_Infrastructure.Database;

namespace P1_Infrastructure_Tests {
    public class RepositoryTests {
        private Mock<P1DatabaseContext> _mockContext;
        private Mock<DbSet<TestEntity>> _mockDbSet;
        private Repository<TestEntity> _repository;

        [SetUp]
        public void Setup() {
            _mockContext = new Mock<P1DatabaseContext>();
            _mockDbSet = new Mock<DbSet<TestEntity>>();
            _mockContext.Setup(m => m.Set<TestEntity>()).Returns(_mockDbSet.Object);
            _repository = new Repository<TestEntity>(_mockContext.Object);
        }

        [Test]
        public void Add_ShouldAddEntity() {
            var entity = new TestEntity();
            _repository.Add(entity);
            _mockDbSet.Verify(m => m.Add(It.IsAny<TestEntity>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void Delete_ShouldRemoveEntity() {
            var entity = new TestEntity();
            _mockDbSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(entity);
            _repository.Delete(entity);
            _mockDbSet.Verify(m => m.Remove(It.IsAny<TestEntity>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void Delete_ShouldThrowExceptionIfEntityNotFound() {
            var entity = new TestEntity();
            _mockDbSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns((TestEntity)null);
            Assert.Throws<Exception>(() => _repository.Delete(entity));
        }

        [Test]
        public void GetAll_ShouldReturnAllEntities() {
            var data = new List<TestEntity> { new TestEntity(), new TestEntity() }.AsQueryable();
            _mockDbSet.As<IQueryable<TestEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            _mockDbSet.As<IQueryable<TestEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            _mockDbSet.As<IQueryable<TestEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _mockDbSet.As<IQueryable<TestEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var result = _repository.GetAll();
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetById_ShouldReturnEntity() {
            var entity = new TestEntity();
            _mockDbSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(entity);
            var result = _repository.GetById(1);
            Assert.AreEqual(entity, result);
        }

        [Test]
        public void GetById_ShouldThrowExceptionIfEntityNotFound() {
            _mockDbSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns((TestEntity)null);
            Assert.Throws<Exception>(() => _repository.GetById(1));
        }

        [Test]
        public void Update_ShouldUpdateEntity() {
            var entity = new TestEntity();
            _mockDbSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(entity);
            _repository.Update(entity);
            _mockDbSet.Verify(m => m.Update(It.IsAny<TestEntity>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void Update_ShouldThrowExceptionIfEntityNotFound() {
            var entity = new TestEntity();
            _mockDbSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns((TestEntity)null);
            Assert.Throws<Exception>(() => _repository.Update(entity));
        }
    }

    public class TestEntity {
        public int Id { get; set; }
    }
}