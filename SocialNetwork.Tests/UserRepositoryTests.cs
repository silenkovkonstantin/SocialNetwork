using Moq;
using NUnit.Framework;
using SocialNetwork;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        [Test]
        public void FindAllMustReturnCorrectValue()
        {
            List<UserEntity> users = new List<UserEntity> {
                new UserEntity()
                {
                    firstname = "Антон",
                    lastname = "Антонов",
                    password = "10101010",
                    email = "gmail1@gmail.com"
                },
                new UserEntity()
                {
                    firstname = "Иван",
                    lastname = "Иванов",
                    password = "20202020",
                    email = "gmail2@gmail.com"
                },
                new UserEntity()
                {
                    firstname = "Алексей",
                    lastname = "Алексеев",
                    password = "30303030",
                    email = "gmail3@gmail.com"
                },
            };

            Mock<IUserRepository> mock = new Mock<IUserRepository>();

            mock.Setup(v => v.FindAll()).Returns(users);

            Assert.That(mock.Object.FindAll().Any(user => user.firstname == "Антон"));
            Assert.That(mock.Object.FindAll().Any(user => user.firstname == "Иван"));
            Assert.That(mock.Object.FindAll().Any(user => user.firstname == "Алексей"));
        }
    }
}
