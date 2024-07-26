using ConsoleAPI.API.Menu.Commands;
using ConsoleAPI.Application.Users;
using ConsoleAPI.Application.Users.Dto;
using ConsoleAPI.Application.Users.Validators;
using FluentValidation;
using Moq;

public class AddCommandHandler_Tests
{
    private readonly Mock<IUserAppService> _userAppServiceMock;
    private readonly IValidator<UserDto> _validator;
    private readonly AddCommandHandler _handler;

    public AddCommandHandler_Tests()
    {
        _userAppServiceMock = new Mock<IUserAppService>();
        _validator = new UserDtoValidator();
        _handler = new AddCommandHandler(_userAppServiceMock.Object, _validator);
    }

    [Fact]
    public async Task Handle_ValidInput_AddsUser()
    {
        var args = new[] { "-add", "FirstName:John", "LastName:Doe", "SalaryPerHour:100,50" };

        await _handler.Handle(args);

        _userAppServiceMock.Verify(x => x.CreateOrUpdate(It.IsAny<UserDto>()), Times.Once);
    }

    [Fact]
    public async Task Handle_InvalidInput_ShowsValidationError()
    {
        var args = new[] { "-add", "FirstName:", "LastName:Doe", "SalaryPerHour:100.50" };

        await Assert.ThrowsAsync<FormatException>(async () => await _handler.Handle(args));
    }

}