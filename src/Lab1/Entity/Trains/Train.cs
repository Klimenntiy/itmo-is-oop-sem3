// <copyright file="Train.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;

/// <summary>
/// Класс, представляющий собой поезд с набором свойств, таких как вес, скорость, ускорение, время и мощность.
/// </summary>
public class Train
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Train"/> class.
    /// Инициализирует новый экземпляр класса <see cref="Train"/> с заданными весом, скоростью, ускорением, временем и мощностью.
    /// </summary>
    /// <param name="weight">Вес поезда.</param>
    /// <param name="speed">Текущая скорость поезда.</param>
    /// <param name="acceleration">Текущее ускорение поезда.</param>
    /// <param name="time">Текущее время.</param>
    /// <param name="powerOn">Мощность, которую потребляет поезд.</param>
    public Train(double weight, double speed, double acceleration, double time, double powerOn, int aim)
    {
        this.Weight = weight;
        this.Speed = speed;
        this.Acceleration = acceleration;
        this.Time = time;
        this.PowerOn = powerOn;
        this.Aim = aim;
    }

    /// <summary>
    /// Gets вес поезда.
    /// </summary>
    public double Weight { get; }

    /// <summary>
    /// Gets or sets текущая скорость поезда.
    /// </summary>
    public double Speed { get; set; }

    /// <summary>
    /// Gets or sets текущее ускорение поезда.
    /// </summary>
    public double Acceleration { get; set; }

    /// <summary>
    /// Gets or sets текущее время.
    /// </summary>
    public double Time { get; set; }

    /// <summary>
    /// Gets мощность, которую потребляет поезд.
    /// </summary>
    public double PowerOn { get; }

    /// <summary>
    /// Gets мощность, которую потребляет поезд.
    /// </summary>
    public int Aim { get; }
}