// <copyright file="Service.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Itmo.ObjectOrientedProgramming.Lab1.Areas;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model;

public class Service
{
    public static Result Drive(Train train, Collection<IArea> areas)
    {
        foreach (IArea area in areas)
        {
            Result result = area.Move(train);
            if (result is not Result.Success)
            {
                return result;
            }
        }

        return new Result.Success();
    }
}