using System.Net;
using Microsoft.AspNetCore.Mvc;
using Services;
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
    
    private class TestDto  
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    [Test]
    public async Task HandleResultAsync_WhenServiceResultHttpResponseTypeIsIsSuccessWithBody_ShouldReturnOk()
    {
        // Arrange
        var someResultDto = new TestDto { Id = 1, Name = "TestName" };
        var result = new ServiceResult<TestDto>(true, HttpStatusCode.OK,"This is success", someResultDto);{}
        
        // Act
        var response = await _responseService.HandleResultAsync(result);
        var okResult = response as OkObjectResult;
        
        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Is.Not.InstanceOf<NotFoundObjectResult>());
        Assert.That(response, Is.InstanceOf<OkObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<NoContentResult>());
        Assert.That(response, Is.Not.InstanceOf<NotFoundResult>());
        Assert.That(response, Is.Not.InstanceOf<BadRequestObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<UnauthorizedObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<ConflictObjectResult>());
        Assert.That(okResult?.Value, Is.Not.Null);
        Assert.That(okResult?.StatusCode, Is.EqualTo(200));
    }
    
    [Test]
    public async Task HandleResultAsync_WhenServiceResultHttpResponseTypeIsIsSuccessWithoutBody_ShouldReturnNoContent()
    {
        // Arrange
        var somePostDto = new TestDto { Id = 1, Name = "TestName" };
        var result = new ServiceResult<TestDto>(true, HttpStatusCode.NoContent,"This is success with no content");{}
        
        // Act
        var response = await _responseService.HandleResultAsync(result);
        var okResult = response as NoContentResult;
        
        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Is.Not.InstanceOf<NotFoundObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<OkObjectResult>());
        Assert.That(response, Is.InstanceOf<NoContentResult>());
        Assert.That(response, Is.Not.InstanceOf<NotFoundResult>());
        Assert.That(response, Is.Not.InstanceOf<BadRequestObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<UnauthorizedObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<ConflictObjectResult>());
        Assert.That(okResult?.StatusCode, Is.EqualTo(204));
    }
    
    [Test]
    public async Task HandleResultAsync_WhenServiceResultHttpResponseTypeIsIsFailureWithNotFound_ShouldReturnNotFound()
    {       
        // Arrange  
        var somePostDto = new TestDto { Id = 1, Name = "TestName" };
        var result = new ServiceResult<TestDto>(false, HttpStatusCode.NotFound,$"The id={somePostDto.Id} is not found");{}
        
        // Act
        var response = await _responseService.HandleResultAsync(result);
        var okResult = response as NotFoundObjectResult;
        
        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Is.InstanceOf<NotFoundObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<OkObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<NoContentResult>());
        Assert.That(response, Is.Not.InstanceOf<NotFoundResult>());
        Assert.That(response, Is.Not.InstanceOf<BadRequestObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<UnauthorizedObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<ConflictObjectResult>());
        Assert.That(okResult?.StatusCode, Is.EqualTo(404));
        Assert.That(okResult?.Value, Is.Not.Null);
        
    }
    
    [Test]
    public async Task HandleResultAsync_WhenServiceResultHttpResponseTypeIsIsFailureWithBadRequest_ShouldReturnBadRequest()
    {       
        // Arrange  
        var somePostDto = new TestDto { Id = 1, Name = "TestName", Email = "testemail.com" };
        var result = new ServiceResult<TestDto>(false, HttpStatusCode.BadRequest,$"Email is missing @");{}
        
        // Act
        var response = await _responseService.HandleResultAsync(result);
        var okResult = response as BadRequestObjectResult;
        
        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Is.Not.InstanceOf<NotFoundObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<OkObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<NoContentResult>());
        Assert.That(response, Is.Not.InstanceOf<NotFoundResult>());
        Assert.That(response, Is.InstanceOf<BadRequestObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<UnauthorizedObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<ConflictObjectResult>());
        Assert.That(okResult?.StatusCode, Is.EqualTo(400));
        Assert.That(okResult?.Value, Is.Not.Null);
        
    }
    
    [Test]
    public async Task HandleResultAsync_WhenServiceResultHttpResponseTypeIsIsFailureWithUnauthorized_ShouldReturnUnauthorized()
    {       
        // Arrange  
        var somePostDto = new TestDto { Id = 1, Name = "TestName", Email = "testemail.com" };
        var result = new ServiceResult<TestDto>(false, HttpStatusCode.Unauthorized,$"Not logged in");{}
        
        // Act
        var response = await _responseService.HandleResultAsync(result);
        var okResult = response as UnauthorizedObjectResult;
        
        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Is.Not.InstanceOf<NotFoundObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<OkObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<NoContentResult>());
        Assert.That(response, Is.Not.InstanceOf<NotFoundResult>());
        Assert.That(response, Is.Not.InstanceOf<BadRequestObjectResult>());
        Assert.That(response, Is.InstanceOf<UnauthorizedObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<ConflictObjectResult>());
        Assert.That(okResult?.StatusCode, Is.EqualTo(401));
        Assert.That(okResult?.Value, Is.Not.Null);
        
    }
    
    [Test]
    public async Task HandleResultAsync_WhenServiceResultHttpResponseTypeIsIsFailureWithForbidden_ShouldReturnForbidden() 
    {       
        // Arrange  
        var somePostDto = new TestDto { Id = 1, Name = "TestName", Email = "testemail.com" };
        var result = new ServiceResult<TestDto>(false, HttpStatusCode.Forbidden,$"Insufficient access");{}
        
        // Act
        var response = await _responseService.HandleResultAsync(result);
        var okResult = response as ObjectResult;
        
        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Is.Not.InstanceOf<NotFoundObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<OkObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<NoContentResult>());
        Assert.That(response, Is.Not.InstanceOf<NotFoundResult>());
        Assert.That(response, Is.Not.InstanceOf<BadRequestObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<UnauthorizedObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<ConflictObjectResult>());
        Assert.That(response, Is.InstanceOf<ObjectResult>());
        Assert.That(okResult?.StatusCode, Is.EqualTo(403));
        Assert.That(okResult?.Value, Is.Not.Null);
        
    }
    
    [Test]
    [TestCase(HttpStatusCode.Accepted)]
    [TestCase(HttpStatusCode.Ambiguous)]
    [TestCase(HttpStatusCode.Continue)]
    [TestCase(HttpStatusCode.Gone)]
    [TestCase(HttpStatusCode.FailedDependency)]
    [TestCase(HttpStatusCode.LoopDetected)]
    [TestCase(HttpStatusCode.Found)]
    [TestCase(HttpStatusCode.ServiceUnavailable)] 
    public async Task HandleResultAsync_WhenServiceResultHttpResponseTypeIsNotSpecifiedInTheResponseService_ShouldReturnConflict(HttpStatusCode httpStatus) 
    {       
        // Arrange  
        var somePostDto = new TestDto { Id = 1, Name = "TestName", Email = "testemail.com" };
        var result = new ServiceResult<TestDto>(false, httpStatus,$"Returning conflict for status code thats not handle in the reponseservice yet YAGNI");{}
        
        // Act
        var response = await _responseService.HandleResultAsync(result);
        var okResult = response as ConflictObjectResult;
        
        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Is.Not.InstanceOf<NotFoundObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<OkObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<NoContentResult>());
        Assert.That(response, Is.Not.InstanceOf<NotFoundResult>());
        Assert.That(response, Is.Not.InstanceOf<BadRequestObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<UnauthorizedObjectResult>());
        Assert.That(response, Is.InstanceOf<ConflictObjectResult>());
        Assert.That(okResult?.StatusCode, Is.EqualTo(409));
        Assert.That(okResult?.Value, Is.Not.Null);
        
    }
   
    [Test]
    public void HandleResultAsync_WhenServiceResultIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        ServiceResult<TestDto>? result = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => _responseService.HandleResultAsync(result));

        // Assert
        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.ParamName, Is.EqualTo("result"));
    }
}   