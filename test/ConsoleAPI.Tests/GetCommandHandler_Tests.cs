using ConsoleAPI.API.Menu.Commands;
using ConsoleAPI.Application.Users;
using ConsoleAPI.Application.Users.Dto;
using Moq;

namespace ConsoleAPI.Tests;

public class GetCommandHandler_Tests
{
    private readonly Mock<IUserAppService> _userAppServiceMock;
    private readonly GetCommandHandler _handler;

    public GetCommandHandler_Tests()
    {
        _userAppServiceMock = new Mock<IUserAppService>();
        _handler = new GetCommandHandler(_userAppServiceMock.Object);
    }

    [Fact]
    public async Task Handle_UserFound_DisplaysUser()
    {
        var args = new[] { "-get", "Id:1" };
        var existingUser = new UserDto { Id = 1, FirstName = "John", LastName = "Doe", SalaryPerHour = 100 };

        _userAppServiceMock.Setup(x => x.GetById(1)).Returns(existingUser);

        await _handler.Handle(args);

        _userAppServiceMock.Verify(x => x.GetById(1), Times.Once);
    }

    [Fact]
    public async Task Handle_UserNotFound_ShowsError()
    {
        var args = new[] { "-get", "Id:1" };

        _userAppServiceMock.Setup(x => x.GetById(1));

        await Assert.ThrowsAsync<NullReferenceException>(async () => await _handler.Handle(args));
    }
}