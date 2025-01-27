using Services.ResponseService;

namespace Tests.ResponseServiceTests;

[TestFixture]
public class HandleResultAsyncTests
{
    private IResponseService _responseService;
    
    [SetUp]
    public void Setup()
    {
        _responseService = new ResponseService();
    }

    [Test]
    public async Task HandleResultAsync_WhenServiceResultIsSuccess_ShouldReturnOk()
    {
        // Arrange
        // Act
        // Assert
    }
}   