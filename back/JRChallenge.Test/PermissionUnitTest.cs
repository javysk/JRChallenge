using JRChallenge.API.DTO;
using JRChallenge.Application.Permission.Commands;
using JRChallenge.Application.Permission.Queries;
using JRChallenge.Domain.Entities;
using JRChallengeAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JRChallenge.Test
{
    public class Tests
    {
        private Mock<IMediator> _mediatorMock;
        private PermissionController _permissionController;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _permissionController = new PermissionController(_mediatorMock.Object);
        }

        [Test]
        public async Task Get_ReturnsListOfPermissions()
        {
            // Arrange
            var permissions = new List<Permissions>
            {
                new Permissions { },
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPermissions>(), default))
                .ReturnsAsync(permissions);

            // Act
            var result = await _permissionController.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(IEnumerable<Permissions>), result);

            var resultList = result as IEnumerable<Permissions>;
            Assert.AreEqual(permissions.Count, resultList?.Count());
        }

        [Test]
        public async Task GetPermissionById_ReturnsPermission()
        {
            // Arrange
            var permissionId = 1;
            var expectedPermission = new Permissions
            {
                Id = permissionId,
                // ... Initialize other properties
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPermissionById>(), default))
                .ReturnsAsync(expectedPermission);

            // Act
            var result = await _permissionController.GetPermissionById(permissionId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(expectedPermission.Id));
        }

        [Test]
        public async Task ModifyPermission_ReturnsNoContent()
        {
            // Arrange
            var permissionDto = new PermissionDTO() { Id = 1, Name = "test" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdatePermission>(), default));

            // Act
            var result = await _permissionController.ModifyPermission(permissionDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<StatusCodeResult>(result);

            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual((int)HttpStatusCode.NoContent, statusCodeResult?.StatusCode);
        }
    }
}