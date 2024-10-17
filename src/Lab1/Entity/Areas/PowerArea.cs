// <copyright file="PowerArea.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

        /// <inheritdoc/>
public class PowerArea(int distance, int power) : IArea
{ /// <inheritdoc/>
    public Result Move(Train train)
    {
        double currentSpeed = train.Speed;
        train.Acceleration = power / train.Weight;
        train.Time = Math.Sqrt(2 * distance / train.Acceleration);
        train.Speed = (train.Acceleration * train.Time) + currentSpeed;
        if (train.PowerOn < power)
        {
            return new Result.TheTrainCouldntHandleTheAcceleration();
        }

        if (train.Speed <= 0)
        {
            return new Result.TheTrainHasNoSpeed();
        }

        base.Move(train);
        return new Result.Success();
    }
}
