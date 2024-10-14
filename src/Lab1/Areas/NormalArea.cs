// <copyright file="NormalArea.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Itmo.ObjectOrientedProgramming.Lab1.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Areas;

public class NormalArea(int distance) : IArea
{
    public Result Move(Train train)
    {
        if (train.Speed <= 0)
        {
            return new Result.TheTrainHasNoSpeed();
        }

        train.Time += distance / train.Speed;
        return new Result.Success();
    }
}
