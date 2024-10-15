// <copyright file="Result.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Itmo.ObjectOrientedProgramming.Lab1.Model;

public abstract record Result
{
    public sealed record Success() : Result();

    public sealed record TheTrainCouldntHandleTheAcceleration() : Result();

    public sealed record TheStationDidNotStopTheTrain() : Result();

    public sealed record TheTrainHasNoSpeed() : Result();

    public sealed record MaximumPermissibleSpeed() : Result();
}