using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using CarAPI.Entities;
using Moq.EntityFrameworkCore;

namespace CarFactoryAPI_Tests
{
    public class OwnerRepositoryTests
    {
        // Create Mock of Dependencies
        Mock<FactoryContext> contextMock;
        // use fake object as dependency
        OwnerRepository ownerRepository;

        public OwnerRepositoryTests()

        {
            // Create Mock of Dependencies
            contextMock = new();

            // use fake object as dependency
            ownerRepository = new(contextMock.Object);


        }
        [Fact()]

        [Trait("Author", "Shymaa")]

        [Trait("Priorty", "50")]



        public void GetOwnerById_AskForOwnerId4_OwnerObject() {


            List<Owner> owners = new List<Owner>() {

             new Owner() { Id = 1 },

             new Owner() { Id = 4},

              new Owner() { Id = 2 }

             };

            // setup called Dbsets

            contextMock.Setup(o => o.Owners).ReturnsDbSet(owners);

            // Act

            Owner result = ownerRepository.GetOwnerById(2);

            // Assert

            Assert.NotNull(result);
        }

        [Fact()]
        [Trait("Author", "Shymaa")]

        [Trait("Priorty", "60")]


        public void GetAllOwners_AskForAllOwners_OwnerObject()
        {

            // Arrange

            // Build the mock data

            List<Owner> owners = new List<Owner>()
            {
            new Owner() { Id = 1, Name = "shymaa" },

            new Owner() { Id = 2, Name = "hany" },

            new Owner() { Id = 3, Name = "lOtfy" }};

            // setup called Dbsets

            contextMock.Setup(o => o.Owners).ReturnsDbSet(owners);

            // Act

            List<Owner> result = ownerRepository.GetAllOwners();

            // Assert

            Assert.NotEmpty(result);

        }
    } 
}
