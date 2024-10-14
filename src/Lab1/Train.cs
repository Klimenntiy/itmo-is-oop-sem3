// <copyright file="Train.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train(double weight, double speed, double acceleration, double time, double powerOn)
{
    public double Weight { get; } = weight;

    public double Speed { get; set; } = speed;

    public double Acceleration { get; set; } = acceleration;

    public double Time { get; set; } = time;

    public double PowerOn { get; } = powerOn;
}