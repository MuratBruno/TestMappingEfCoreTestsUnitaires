using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMappingEfCore.Controllers;
using TestMappingEfCore.Models;
using TestMappingEfCore.Models.DonneeDAO;
using TestMappingEfCore.Repository;
using TestMappingEfCore.Repository.Impl;
using TestMappingEfCore.Services.Impl;
using Xunit;

namespace TestMappingEfCore.Tests
{
    public class ControllerTest
    {
        ClientController clientController;
        public ControllerTest()
        {
            //TODO : injecter
            this.clientController = ClientController.getClientController();
        }

        [Fact]
        public void Get_SingleClient_FindClient()
        {
            //Arrange
            Mock<IClientRepository> clientRepositoryMock = new Mock<IClientRepository>();
            ClientDAO clientDAO = new ClientDAO();
            clientDAO.id = 1;

            Task<ClientDAO> taskClient = new Task<ClientDAO>(()=> clientDAO);

            clientRepositoryMock.Setup(m => m.GetById(1)).Returns(taskClient);

            // Act
            ClientDTO actual = clientController.GetById(1).Value;

            ClientDTO clientDTO = new ClientDTO();
            clientDTO.id = 1;

            // Assert
            Xunit.Assert.Equal(clientDTO, actual);

            Xunit.Assert.Equal(2, 2);
        }

        [Test]
        public void test_Add()
        {
            // Assert
            NUnit.Framework.Assert.AreEqual(2, 2);
        }
    }
}
