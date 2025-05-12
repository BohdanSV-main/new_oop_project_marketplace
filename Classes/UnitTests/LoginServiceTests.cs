using Xunit;
using Moq;
using Marketplace;

public class LoginServiceTests
{
    private readonly Mock<IUserRepository> _mockRepo;
    private readonly LoginService _service;

    public LoginServiceTests()
    {
        _mockRepo = new Mock<IUserRepository>();
        _service = new LoginService(_mockRepo.Object);
        SessionManager.SetCurrentUser(null);
    }

    [Fact]
    public void LoginUser_ValidCredentials_ReturnsTrue()
    {
        var password = "1234";
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new User(1, "test", hashedPassword, false);
        _mockRepo.Setup(r => r.GetUserByLogin("test")).Returns(user);

        var result = _service.LoginUser("test", "1234");

        Assert.True(result);
        Assert.Equal(user, SessionManager.CurrentUser);
    }

    [Fact]
    public void LoginUser_InvalidPassword_ReturnsFalse()
    {
        var user = new User(1, "test", BCrypt.Net.BCrypt.HashPassword("correct"), false);
        _mockRepo.Setup(r => r.GetUserByLogin("test")).Returns(user);

        var result = _service.LoginUser("test", "wrong");

        Assert.False(result);
        Assert.Null(SessionManager.CurrentUser);
    }

    [Fact]
    public void RegisterUser_UserAlreadyExists_ReturnsFalse()
    {
        var existingUser = new User(1, "existing", "pass", false);
        _mockRepo.Setup(r => r.GetUserByLogin("existing")).Returns(existingUser);

        var result = _service.RegisterUser("existing", "password");

        Assert.False(result);
        _mockRepo.Verify(r => r.Add(It.IsAny<User>()), Times.Never);
    }

    [Fact]
    public void ValidateLoginModel_InvalidUser_ReturnsErrors()
    {
        var user = new User(0, "", "", false);

        var errors = _service.ValidateLoginModel(user);

        Assert.NotEmpty(errors);
    }

    [Fact]
    public void ValidateLoginModel_ValidUser_ReturnsNoErrors()
    {
        var user = new User(1, "valid", "password", false);

        var errors = _service.ValidateLoginModel(user);

        Assert.Empty(errors);
    }
}
