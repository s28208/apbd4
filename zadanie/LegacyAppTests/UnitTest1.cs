namespace LegacyAppTests;
using System;
using LegacyApp;

public class UnitTest1
{
    [Fact]
    public void AddUser_ReturnFalseWhenFirstNameIsEmpty()
    {
        var userService = new UserService();
        var result = userService.AddUser(  
            null,
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnFalseWhenSecondNameIsEmpty()
    {
        var userService = new UserService();
        var result = userService.AddUser(  
            "Jan",
            null,
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1);
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnFalseWhenEmailWithoutAt()
    {
        var userService = new UserService();
        var result = userService.AddUser(  
            "Jan",
            "Kowalski",
            "kowalskikowal.com",
            DateTime.Parse("2000-01-01"),
            1);
        Assert.False(result);
    }
    [Fact]
    public void AddUser_ReturnFalseWhenEmailWithoutDot()
    {
        var userService = new UserService();
        var result = userService.AddUser(  
            "Jan",
            "Kowalski",
            "kowalski@kowalcom",
            DateTime.Parse("2000-01-01"),
            1);
        Assert.False(result);
    }
    [Fact]
    public void AddUser_ReturnFalseWhenAgeLessThan21()
    {
        var userService = new UserService();
        var result = userService.AddUser(  
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2004-01-01"),
            1);

        Assert.False(result);
    }
    [Fact]
    public void AddUser_ReturnFalseWhenCreditLimitIsLessThan500()
    {
        var userService = new UserService();
        var result = userService.AddUser(  
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        var userService = new UserService();
        var result = userService.AddUser(  
            "Jan",
            "Malewski",
            "malewski@gmail.pl",
            DateTime.Parse("2000-01-01"),
            2);
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        var userService = new UserService();
        var result = userService.AddUser(  
            "John",
            "Smith",
            "smith@gmail.pl",
            DateTime.Parse("2000-01-01"),
            3);
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        var userService = new UserService();
        var result = userService.AddUser(  
            "John",
            "Kwiatkowski",
            "akwiatkowski@wp.pl",
            DateTime.Parse("2000-01-01"),
            5);
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        var userService = new UserService();
        var result = userService.AddUser(  
            "John",
            "Kowalski",
            "kowalski@wp.pl",
            DateTime.Parse("2000-01-01"),
            1);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        var userService = new UserService();
        Action action = () => userService.AddUser(
            "Jan", 
            "Andrzejewicz", 
            "andrzejewicz@wp.pl",
            DateTime.Parse("2000-01-01"),
            6
        );
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        var userService = new UserService();
        Action action = () => userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            13873
        );
        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
    {
        var userService = new UserService();
        Action action = () => userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            100
        );
        Assert.Throws<ArgumentException>(action);
    }
    
    
}