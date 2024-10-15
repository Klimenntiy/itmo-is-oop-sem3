// <copyright file="Service.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Itmo.ObjectOrientedProgramming.Lab1.Areas;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model;

/// <summary>
/// Сервисный класс, предоставляющий методы для управления поездами.
/// </summary>
public class Service
{
    /// <summary>
    /// Перемещает поезд через последовательность областей и возвращает результат перемещения.
    /// </summary>
    /// <param name="train">Поезд, который перемещается через области.</param>
    /// <param name="areas">Последовательность областей, через которые перемещается поезд.</param>
    /// <param name="maxSpeed">Максимально допустимая скорость.</param>
    /// <returns>Результат перемещения поезда через все области.</returns>
    public static Result Drive(Train train, Collection<IArea> areas, int maxSpeed)
    {
        foreach (IArea area in areas)
        {
            Result result = area.Move(train);
            if (result is not Result.Success)
            {
                return result;
            }
        }

        if (train.Speed > maxSpeed)
        {
            return new Result.MaximumPermissibleSpeed();
        }

        return new Result.Success();
    }
}