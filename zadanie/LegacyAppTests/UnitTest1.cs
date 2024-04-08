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
            DateTime.Parse("2020-01-01"),
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
    
    
}