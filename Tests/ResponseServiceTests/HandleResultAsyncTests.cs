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
    }

    [Test]
    public async Task HandleResultAsync_WhenServiceResultIsSuccessWithBody_ShouldReturnOk()
    {
        // Arrange
        var someResultDto = new TestDto { Id = 1, Name = "TestName" };
        var result = new ServiceResult<TestDto>(true, HttpStatusCode.OK,"This is success", someResultDto);{}
        
        // Act
        var response = await _responseService.HandleResultAsync(result);
        var okResult = response as OkObjectResult;
        
        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Is.InstanceOf<OkObjectResult>());
        Assert.That(response, Is.Not.InstanceOf<NoContentResult>());
        Assert.That(okResult?.Value, Is.Not.Null);
        Assert.That(okResult?.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
    }
    
    [Test]
    public async Task HandleResultAsync_WhenServiceResultIsSuccessWithoutBody_ShouldReturnNoContent()
    {
        // Arrange
        var somePostDto = new TestDto { Id = 1, Name = "TestName" };
        var result = new ServiceResult<TestDto>(true, HttpStatusCode.NoContent,"This is success with no content");{}
        
        // Act
        var response = await _responseService.HandleResultAsync(result);
        var okResult = response as NoContentResult;
        
        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Is.InstanceOf<NoContentResult>());
        Assert.That(response, Is.Not.InstanceOf<OkObjectResult>());
        Assert.That(okResult?.StatusCode, Is.EqualTo((int)HttpStatusCode.NoContent));
    }
}   