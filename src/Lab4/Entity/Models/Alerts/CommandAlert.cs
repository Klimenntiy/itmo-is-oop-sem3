namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Alerts;

public record CommandAlert(string Message = "Invalid command format") : Alert;