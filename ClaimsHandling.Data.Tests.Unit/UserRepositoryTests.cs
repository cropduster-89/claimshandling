using ClaimsHandling.Data.DataModels;
using ClaimsHandling.Data.Repositories;
using ClaimsHandling.Domain;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ClaimsHandling.Data.Tests.Unit
{
    public class UserRepositoryTests
    {
        private UserRepository _userRepository;
        private Mock<ClaimsHandlingContext> _mockContext;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<ClaimsHandlingContext>().Options;
            _mockContext = new Mock<ClaimsHandlingContext>(dbOptions);
            _mockContext.Setup(_ => _.Users).Returns(CreateMockSet(GetMockUsers()).Object);

            _userRepository = new UserRepository(_mockContext.Object);
        }

        [Test]
        public void UserWithLoginExists_WhenUserIsActiveAndCredentialsAreCorrect_ReturnsTrue()
        {
            var result = _userRepository.UserWithLoginExists(new Login
            {
                Username = "testUser1",
                Password = "testPassword1"
            });

            Assert.AreEqual(true, result);
        }

        [Test]
        public void UserWithLoginExists_WhenUserIsNotActiveAndCredentialsAreCorrect_ReturnsFalse()
        {
            var result = _userRepository.UserWithLoginExists(new Login
            {
                Username = "testUser2",
                Password = "testPassword2"
            });

            Assert.AreEqual(false, result);
        }

        [Test]
        public void UserWithLoginExists_WhenNoUserWithCredentialsExists_ReturnsFalse()
        {
            var result = _userRepository.UserWithLoginExists(new Login
            {
                Username = "testUser3",
                Password = "testPassword3"
            });

            Assert.AreEqual(false, result);
        }

        private Mock<DbSet<T>> CreateMockSet<T>(IEnumerable<T> set) where T : class
        {
            var queryableSet = set.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableSet.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableSet.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableSet.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryableSet.GetEnumerator());

            return mockSet;
        }

        private IEnumerable<User> GetMockUsers()
        {
            return new List<User>
            {
                new User
                {
                    UserName = "testUser1",
                    Password = "testPassword1",
                    Active = true
                },
                new User
                {
                    UserName = "testUser2",
                    Password = "testPassword2",
                    Active = false
                }
            };
        }
    }
}