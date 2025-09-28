using System.Net;
using System.Net.Http.Json;
using AwesomeAssertions;
using Presentation.Endpoints.CreateBook;
using Presentation.Endpoints.UpdateBook;
using Xunit.Abstractions;

namespace MinimalApi.Tests;

public class IntegrationTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public IntegrationTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public async Task Should_Get_Books_Returns_200()
    {
        // arrange
        var fixture = new IntegrationTestsFactory(_testOutputHelper);
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync("api/v1/books");

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    public async Task Should_Get_Book_Returns_200(string bookId)
    {
        // arrange
        var fixture = new IntegrationTestsFactory(_testOutputHelper);
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync($"api/v1/books/{bookId}");

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    public async Task Should_Search_Books_Returns_200(string searchTerm)
    {
        // arrange
        var fixture = new IntegrationTestsFactory(_testOutputHelper);
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync($"api/v1/books/search?searchTerm={searchTerm}");

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact]
    public async Task Should_Create_Book_Returns_201()
    {
        // arrange
        var fixture = new IntegrationTestsFactory(_testOutputHelper);
        var client = fixture.CreateClient();
        var title = Guid.NewGuid().ToString();
        var author = Guid.NewGuid().ToString();
        var request = new CreateBookRequest(title, author);

        // act
        var response = await client.PostAsJsonAsync("api/v1/books", request);

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    public async Task Should_Update_Book_Returns_200(string bookId)
    {
        // arrange
        var fixture = new IntegrationTestsFactory(_testOutputHelper);
        var client = fixture.CreateClient();
        var title = Guid.NewGuid().ToString();
        var author = Guid.NewGuid().ToString();
        var request = new UpdateBookRequest(title, author);

        // act
        var response = await client.PutAsJsonAsync($"api/v1/books/{bookId}", request);

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    public async Task Should_Delete_Book_Returns_200(string bookId)
    {
        // arrange
        var fixture = new IntegrationTestsFactory(_testOutputHelper);
        var client = fixture.CreateClient();

        // act
        var response = await client.DeleteAsync($"api/v1/books/{bookId}");

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}