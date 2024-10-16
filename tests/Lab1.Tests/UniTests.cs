using Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab1.Tests;

/// <summary>
/// Класс, содержащий тесты для проверки работы сервиса перемещения поездов.
/// </summary>
public class UniTests
{
    /// <summary>
    /// Тест, проверяющий успешное перемещение поезда через последовательность областей с разными типами.
    /// </summary>
    [Fact]
    public void Test_1()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));

        var train = new Train(1000, 0, 0, 0, 500);

        Result finish = Travel.Drive(train, collectionOfAreas, 10);

        bool result = finish is Result.Success;
        Assert.True(result);
    }

    /// <summary>
    /// Тест, проверяющий успешное перемещение поезда через последовательность областей с разными типами.
    /// </summary>
    [Fact]
    public void Test_2()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));

        var train = new Train(1000, 0, 0, 0, 500);

        Result finish = Travel.Drive(train, collectionOfAreas, 1);

        bool result = finish is Result.MaximumPermissibleSpeed;
        Assert.True(result);
    }

    /// <summary>
    /// Тест, проверяющий успешное перемещение поезда через последовательность областей с разными типами.
    /// </summary>
    [Fact]
    public void Test_3()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new StationArea(30, 10));

        var train = new Train(1000, 0, 0, 0, 500);

        Result finish = Travel.Drive(train, collectionOfAreas, 10);

        bool result = finish is Result.Success;
        Assert.True(result);
    }

    /// <summary>
    /// Тест, проверяющий успешное перемещение поезда через последовательность областей с разными типами.
    /// </summary>
    [Fact]
    public void Test_4()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new StationArea(30, 5));

        var train = new Train(1000, 0, 0, 0, 500);

        Result finish = Travel.Drive(train, collectionOfAreas, 10);

        bool result = finish is Result.TheStationDidNotStopTheTrain;
        Assert.True(result);
    }

    /// <summary>
    /// Тест, проверяющий успешное перемещение поезда через последовательность областей с разными типами.
    /// </summary>
    [Fact]
    public void Test_5()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new StationArea(30, 10));

        var train = new Train(1000, 0, 0, 0, 500);

        Result finish = Travel.Drive(train, collectionOfAreas, 6);

        bool result = finish is Result.MaximumPermissibleSpeed;
        Assert.True(result);
    }

    /// <summary>
    /// Тест, проверяющий успешное перемещение поезда через последовательность областей с разными типами.
    /// </summary>
    [Fact]
    public void Test_6()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 500));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new PowerArea(100, -150));
        collectionOfAreas.Add(new StationArea(30, 10));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new PowerArea(100, 500));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new PowerArea(100, -500));

        var train = new Train(1000, 0, 0, 0, 500);

        Result finish = Travel.Drive(train, collectionOfAreas, 100);

        bool result = finish is Result.Success;
        Assert.True(result);
    }

    /// <summary>
    /// Тест, проверяющий успешное перемещение поезда через последовательность областей с разными типами.
    /// </summary>
    [Fact]
    public void Test_7()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new NormalArea(100));

        var train = new Train(1000, 0, 0, 0, 500);

        Result finish = Travel.Drive(train, collectionOfAreas, 6);

        bool result = finish is Result.TheTrainHasNoSpeed;
        Assert.True(result);
    }

    /// <summary>
    /// Тест, проверяющий успешное перемещение поезда через последовательность областей с разными типами.
    /// </summary>
    [Fact]
    public void Test_8()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 1000));
        collectionOfAreas.Add(new PowerArea(100, -2000));

        var train = new Train(1000, 0, 0, 0, 500);

        Result finish = Travel.Drive(train, collectionOfAreas, 6);

        bool result = finish is Result.TheTrainCouldntHandleTheAcceleration;
        Assert.True(result);
    }
}