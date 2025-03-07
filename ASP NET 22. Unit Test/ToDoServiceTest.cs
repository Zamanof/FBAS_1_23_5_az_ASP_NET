using ASP_NET_22._ToDo_WebApi_For_Unit_Test.Data;
using Microsoft.EntityFrameworkCore;
using ASP_NET_22._ToDo_WebApi_For_Unit_Test.Models;
using ASP_NET_22._ToDo_WebApi_For_Unit_Test.Services;
using FluentAssertions;
using ASP_NET_22._ToDo_WebApi_For_Unit_Test.DTOs.Pagination;
using ASP_NET_22._ToDo_WebApi_For_Unit_Test.DTOs;
using Moq;

namespace ASP_NET_22._Unit_Test;
public class ToDoServiceTest
{
    public static IEnumerable<object[]> AddData()
    {
        yield return new object[] { 1, 2, 3 };
        yield return new object[] { 2, 2, 4 };
        yield return new object[] { 5, 26, 31 };
        yield return new object[] { 69, 96, 165 };
        yield return new object[] { -2, -2, -4 };
        yield return new object[] { 10, 20, 30 };
        yield return new object[] { 11, 22, 33 };
    }
    [Theory]
    [MemberData(nameof(AddData))]
    //[InlineData(1, 2, 3)]
    //[InlineData(5, 26, 31)]
    //[InlineData(69, 96, 165)]
    public void Add_ReturnResult(int left, int right, int exceptResult)
    {
        // Arrange
        var calc = new Calculator();
        // Act
        var actualResult = calc.Add(left, right);
        // Assert
        Assert.Equal(actualResult, exceptResult);
    }
    [Fact]
    public async Task GetToDoItem_ReturnToDoItemWhichBelongUser()
    {
        // AAA
        // Arrange
        var dbContext = new ToDoContext(
            new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase("Test").Options);
        var user = dbContext.Users.Add(new AppUser
        {
            UserName = "Nadir",
            Email = "zamanov@gmail"
        }).Entity;
        var createdToDoItem = dbContext.ToDoItems.Add(new ToDoItem
        {
            Text = "Salam",
            UserId = user.Id
        }).Entity;
        dbContext.SaveChanges();
        var service = new ToDoService(dbContext);

        // Act
        var retrivedToDoItem = await service.GetToDoItemAsync(user.Id, createdToDoItem.Id);

        // Assert
        Assert.NotNull(retrivedToDoItem);
    }

    [Fact]
    public async Task GetToDoItem_ReturnToDoItemWhichNotBelongUser()
    {
        // AAA
        // Arrange
        var dbContext = new ToDoContext(
            new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase("Test").Options);
        var user = dbContext.Users.Add(new AppUser
        {
            UserName = "Nadir",
            Email = "zamanov@itstep.org"
        }).Entity;

        var otherUser = dbContext.Users.Add(new AppUser
        {
            UserName = "Ali",
            Email = "aliyev@gmail.com"
        }).Entity;
        var createdToDoItem = dbContext.ToDoItems.Add(new ToDoItem
        {
            Text = "Salam",
            UserId = user.Id
        }).Entity;
        dbContext.SaveChanges();
        var service = new ToDoService(dbContext);

        // Act
        var retrivedToDoItem = await service.GetToDoItemAsync(otherUser.Id, createdToDoItem.Id);

        // Assert
        Assert.Null(retrivedToDoItem);
    }

    [Fact]
    public async Task GetToDoItems_ReturnsPaginatedToDoItemsWhichBelongUser()
    {
        // Arrange
        var dbContext = new ToDoContext(
           new DbContextOptionsBuilder<ToDoContext>()
           .UseInMemoryDatabase("Test").Options);
        var user = dbContext.Users.Add(new AppUser
        {
            UserName = "Nadir",
            Email = "zamanov@itstep.org"
        }).Entity;

        dbContext.ToDoItems.AddRange(Enumerable
             .Range(1, 10)
             .Select(i => new ToDoItem
             {
                 Text = $"Test {i}",
                 UserId = user.Id
             })
             .ToList());
        dbContext.SaveChanges();
        var service = new ToDoService(dbContext);
        // Act
        var retrivedToDoItems = await service.GetToDoItemsAsync(user.Id, 1, 3, null, null);
        // Assert
        #region simple Assert
        //Assert.NotNull(retrivedToDoItems);

        //Assert.Equal(3, retrivedToDoItems.Items.Count());
        //Assert.Equal(1, retrivedToDoItems.Meta.Page);
        //Assert.Equal(3, retrivedToDoItems.Meta.PageSize);
        //Assert.Equal(4, retrivedToDoItems.Meta.TotalPages);

        //Assert.Collection(retrivedToDoItems.Items,
        //    item => Assert.Equal("Test 1", item.Text),
        //    item => Assert.Equal("Test 2", item.Text),
        //    item => Assert.Equal("Test 3", item.Text));
        #endregion

        #region Fluent Assertion

        retrivedToDoItems.Should().NotBeNull();

        retrivedToDoItems.Items.Count().Should().Be(3);
        //retrivedToDoItems.Meta.PageSize.Should().Be(3);
        //retrivedToDoItems.Meta.Page.Should().Be(1);
        //retrivedToDoItems.Meta.TotalPages.Should().Be(4);
        retrivedToDoItems.Meta.Should().BeEquivalentTo(new PaginationMeta(1, 3, 10));


        //retrivedToDoItems.Items.Should().ContainSingle(item => item.Text == "Test 1");
        //retrivedToDoItems.Items.Should().ContainSingle(item => item.Text == "Test 2");
        //retrivedToDoItems.Items.Should().ContainSingle(item => item.Text == "Test 3");

        retrivedToDoItems.Items.Should().ContainSingle(item => item.Text == "Test 1")
            .And.ContainSingle(item => item.Text == "Test 2")
            .And.ContainSingle(item => item.Text == "Test 3");
        #endregion

    }

    [Fact]
    public async Task CreateToDoItem_ThrowsException_UserNotFound()
    {
        // Arrange
        var dbContext = new ToDoContext(
            new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase("Test").Options);
        var createdToDoItem = new CreateToDoItemRequest() { Text = "Salam" };
        var userId = "1";
        var emailSender = new FakeEmailSender();
        var service = new ToDoService(dbContext, emailSender);

        // Act
        //try
        //{
        //    var retrivedToDoItem = await service.CreateToDoAsync(userId, createdToDoItem);
        //}
        //catch (Exception ex)
        //{
        //    Assert.True(ex is KeyNotFoundException);
        //}

        //Record.ExceptionAsync(async () =>
        //{
        //    var retrivedToDoItem = await service.CreateToDoAsync(userId, createdToDoItem);
        //}).Result.Should().BeOfType<KeyNotFoundException>();

        await service.Awaiting(s=> s.CreateToDoAsync(userId, createdToDoItem))
            .Should()
            .ThrowAsync<KeyNotFoundException>();
    }

    [Fact]

    public async Task CreateToDoItem_CreateNewItem_And_SendsEmailNotification()
    {
        // Arrange
        var dbContext = new ToDoContext(
            new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase("Test").Options);

        var user = dbContext.Users.Add(new AppUser
        {
            UserName = "Test",
            Email = "Test@gmail.com"
        }).Entity;
        var createdToDoItem = new CreateToDoItemRequest() { Text = "Test" };

        var emailSender = new Mock<IEmailSender>(MockBehavior.Strict);
        emailSender.Setup(e => e.SendEmail(user.Email, 
            It.Is<string>(s=>s.Contains(createdToDoItem.Text)), 
            It.IsAny<string>()))
            .Returns(Task.CompletedTask);

        await dbContext.SaveChangesAsync();
        
        var service = new ToDoService(dbContext);

        await service.Awaiting(s => s.CreateToDoAsync("user.Id", createdToDoItem))
            .Should()
            .ThrowAsync<KeyNotFoundException>();
    }
}