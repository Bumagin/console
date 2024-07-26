using ConsoleAPI.API.Menu.Commands;
using ConsoleAPI.Application.Users;
using ConsoleAPI.Application.Users.Dto;
using Moq;

namespace ConsoleAPI.Tests;

public class DeleteCommandHandler_Tests
{
    private readonly Mock<IUserAppService> _userAppServiceMock;
    private readonly DeleteCommandHandler _handler;

    public DeleteCommandHandler_Tests()
    {
        _userAppServiceMock = new Mock<IUserAppService>();
        _handler = new DeleteCommandHandler(_userAppServiceMock.Object);
    }

    [Fact]
    public async Task Handle_UserFound_DeletesUser()
    {
        var args = new[] { "-delete", "Id:1" };
        var existingUser = new UserDto { Id = 1, FirstName = "John", LastName = "Doe", SalaryPerHour = 100 };

        _userAppServiceMock.Setup(x => x.GetById(1)).Returns(existingUser);

        await _handler.Handle(args);

        _userAppServiceMock.Verify(x => x.Delete(1), Times.Once);
    }
}