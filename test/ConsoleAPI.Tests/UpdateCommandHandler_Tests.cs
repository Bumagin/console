using ConsoleAPI.API.Menu.Commands;
using ConsoleAPI.Application.Users;
using ConsoleAPI.Application.Users.Dto;
using Moq;

namespace ConsoleAPI.Tests;

public class UpdateCommandHandler_Tests
{
    private readonly Mock<IUserAppService> _userAppServiceMock;
    private readonly UpdateCommandHandler _handler;

    public UpdateCommandHandler_Tests()
    {
        _userAppServiceMock = new Mock<IUserAppService>();
        _handler = new UpdateCommandHandler(_userAppServiceMock.Object);
    }

    [Fact]
    public async Task Handle_ValidInput_UpdatesUser()
    {
        var args = new[] { "-update", "Id:1", "FirstName:James" };
        var existingUser = new UserDto { Id = 1, FirstName = "John", LastName = "Doe", SalaryPerHour = 100 };

        _userAppServiceMock.Setup(x => x.GetById(1)).Returns(existingUser);

        await _handler.Handle(args);

        _userAppServiceMock.Verify(x => x.CreateOrUpdate(It.Is<UserDto>(u => u.Id == 1 && u.FirstName == "James")), Times.Once);
    }

    [Fact]
    public async Task Handle_UserNotFound_ShowsError()
    {
        var args = new[] { "-update", "Id:1", "FirstName:James" };

        _userAppServiceMock.Setup(x => x.GetById(1)).Returns((UserDto)null);
        
        await Assert.ThrowsAsync<NullReferenceException>(async () => await _handler.Handle(args));
    }
}