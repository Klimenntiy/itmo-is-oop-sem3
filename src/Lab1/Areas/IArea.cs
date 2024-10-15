// <copyright file="IArea.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Itmo.ObjectOrientedProgramming.Lab1.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Areas;

/// <summary>
/// Интерфейс, представляющий собой область, через которую может перемещаться поезд.
/// </summary>
public interface IArea
{
    /// <summary>
    /// Перемещает поезд по области и возвращает результат перемещения.
    /// </summary>
    /// <param name="train">Поезд, который перемещается по области.</param>
    /// <returns>Результат перемещения поезда по области.</returns>
    public Result Move(Train train);
}