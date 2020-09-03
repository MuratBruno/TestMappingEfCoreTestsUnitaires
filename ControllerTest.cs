using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMappingEfCore.Controllers;
using TestMappingEfCore.Data;
using TestMappingEfCore.Helper;
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
          
        }

        [Fact]
        public void Get_SingleClient_FindClient()
        {
            

            //Arrange
            Mock<ClientContext> clientContextMock = new Mock<ClientContext>();
            Mock<DbSet<ClientDAO>> mockDbSet = new Mock<DbSet<ClientDAO>>();
            clientContextMock.Object.Clients = mockDbSet.Object;
            ClientProvider.clientContext = clientContextMock.Object;

            this.clientController = ClientProvider.getClientController();

            ClientDAO clientDAO = new ClientDAO();
            clientDAO.id = 1;

            
            clientContextMock.Setup(x => x.Set<ClientDAO>()).Returns(mockDbSet.Object);
            mockDbSet.Setup(x => x.Find(It.IsAny<int>())).Returns(clientDAO);

            // Act
            ClientDTO actual = clientController.GetById(1).Value;

            ClientDTO clientDTO = new ClientDTO();
            clientDTO.id = 1;

            // Assert
            Xunit.Assert.Equal(clientDTO.id, actual.id);
            Xunit.Assert.Equal(clientDTO.nbAchat, actual.nbAchat);


        }


    }
}
