using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Demo1.TestApi.MockData;
using Elasticsearch.Net;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using N5Challenge.Api.Contracts;
using N5Challenge.Api.Contracts.Request;
using N5Challenge.Api.Services;
using N5Challenge.Api.Tests.Mocks;
using N5Challenge.Controllers;
using N5Challenge.Domain.Entities;
using N5Challenge.Mediator.Commands;
using N5Challenge.Mediator.Queries;
using Nest;
using Newtonsoft.Json;
using Xunit;

namespace N5Challenge.Api.Tests
{
    public class PermissionsControllerTests
    {
        private readonly Mock<IMediator> mockMediator;
        private readonly Mock<IElasticSearchService> mockElasticSearchService;
        private readonly PermissionsController controller;
        private ElasticClient client;
        public PermissionsControllerTests()
        {
            mockMediator = new Mock<IMediator>();
            mockElasticSearchService = new Mock<IElasticSearchService>();
            controller = new PermissionsController(mockMediator.Object, mockElasticSearchService.Object);

            byte[] responseBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ElasticSearchMockData.GetSearchResponse()));
            InMemoryConnection connection = new InMemoryConnection(responseBytes, 200);
            SingleNodeConnectionPool connectionPool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
            ConnectionSettings settings = new ConnectionSettings(connectionPool, connection).DefaultIndex("permissions");
            client = new ElasticClient(settings);
        }

        [Fact]
        public async void GetPermissions_ShouldReturn200Status()
        {
            /// Arrange
            ISearchResponse<PermissionInformation> searchResponse = client.Search<PermissionInformation>(s => s.MatchAll());
            mockElasticSearchService.Setup(x => x.GetAll()).ReturnsAsync(searchResponse);

            /// Arrange
            OkObjectResult result = (OkObjectResult)await controller.GetPermissions();

            /// Assert
            result.StatusCode.Should().Be(200);
        }


        [Fact]
        public async void GetPermissions_ShouldReturnData()
        {
            /// Arrange
            ISearchResponse<PermissionInformation> searchResponse = client.Search<PermissionInformation>(s => s.MatchAll());
            mockElasticSearchService.Setup(x => x.GetAll()).ReturnsAsync(searchResponse);

            /// Arrange
            OkObjectResult result = (OkObjectResult)await controller.GetPermissions();

            /// Assert
            List<PermissionInformation> items = Assert.IsType<List<PermissionInformation>>(result.Value);
            Assert.Equal(5, items.Count);
        }

        [Fact]
        public async void RequestPermission_ShouldInsertData()
        {
            /// Arrange
            mockMediator.Setup(x => x.Send(It.IsAny<CreatePermissionCommand>(), CancellationToken.None))
                                     .ReturnsAsync(MediatorMockData.GetPermissionData());
            mockMediator.Setup(x => x.Send(It.IsAny<GetPermissionTypeByIdQuery>(), CancellationToken.None))
                                     .ReturnsAsync(MediatorMockData.GetPermissionTypeData());
            mockElasticSearchService.Setup(x => x.IndexDocument(It.IsAny<PermissionInformation>()));
            CreatePermissionRequest request = new CreatePermissionRequest
            {
                EmployeeName = "Ricky",
                EmployeeLastName = "Martin",
                PermissionTypeId = 1
            };

            /// Arrange
            OkResult result = (OkResult)await controller.RequestPermission(request);

            /// Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async void ModifyPermission_ShouldReturnBadRequestForPermission()
        {
            /// Arrange
            mockMediator.Setup(x => x.Send(It.IsAny<GetPermissionByIdQuery>(), CancellationToken.None))
                                     .ReturnsAsync((Permission)null);
            UpdatePermissionRequest request = new UpdatePermissionRequest
            {
                Id = 1,
                EmployeeName = "Ricky",
                EmployeeLastName = "Martin",
                PermissionTypeId = 1
            };

            /// Arrange
            BadRequestObjectResult result = (BadRequestObjectResult)await controller.ModifyPermission(request);

            /// Assert
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async void ModifyPermission_ShouldReturnBadRequestForPermissionType()
        {
            /// Arrange
            mockMediator.Setup(x => x.Send(It.IsAny<CreatePermissionCommand>(), CancellationToken.None))
                                     .ReturnsAsync(MediatorMockData.GetPermissionData());
            mockMediator.Setup(x => x.Send(It.IsAny<GetPermissionTypeByIdQuery>(), CancellationToken.None))
                                     .ReturnsAsync((PermissionType)null);
            UpdatePermissionRequest request = new UpdatePermissionRequest
            {
                Id = 1,
                EmployeeName = "Ricky",
                EmployeeLastName = "Martin",
                PermissionTypeId = 1
            };

            /// Arrange
            BadRequestObjectResult result = (BadRequestObjectResult)await controller.ModifyPermission(request);

            /// Assert
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async void ModifyPermission_ShouldModifyData()
        {
            /// Arrange
            mockMediator.Setup(x => x.Send(It.IsAny<GetPermissionByIdQuery>(), CancellationToken.None))
                                     .ReturnsAsync(MediatorMockData.GetPermissionData());
            mockMediator.Setup(x => x.Send(It.IsAny<GetPermissionTypeByIdQuery>(), CancellationToken.None))
                                     .ReturnsAsync(MediatorMockData.GetPermissionTypeData());
            mockMediator.Setup(x => x.Send(It.IsAny<UpdatePermissionCommand>(), CancellationToken.None))
                                    .ReturnsAsync(MediatorMockData.GetPermissionData());
            mockElasticSearchService.Setup(x => x.UpdateIndexDocument(It.IsAny<PermissionInformation>()));
            UpdatePermissionRequest request = new UpdatePermissionRequest
            {
                Id = 1,
                EmployeeName = "Ricky",
                EmployeeLastName = "Martin",
                PermissionTypeId = 1
            };

            /// Arrange
            OkResult result = (OkResult)await controller.ModifyPermission(request);

            /// Assert
            result.StatusCode.Should().Be(200);
        }
    }
}