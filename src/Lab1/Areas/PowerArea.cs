// <copyright file="PowerArea.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Itmo.ObjectOrientedProgramming.Lab1.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Areas;

public class PowerArea(int distance, int power) : IArea
{
    public Result Move(Train train)
    {
        double currentSpeed = train.Speed;
        train.Acceleration = power / train.Weight;
        train.Speed = Math.Sqrt(Math.Pow(train.Speed, 2) - (2 * train.Acceleration * distance));
        if (train.PowerOn < power)
        {
            return new Result.TheTrainCouldntHandleTheAcceleration();
        }

        if (train.Speed <= 0)
        {
            return new Result.TheTrainHasNoSpeed();
        }

        train.Time = (train.Speed / train.Acceleration) - (currentSpeed / train.Acceleration);
        return new Result.Success();
    }
}
