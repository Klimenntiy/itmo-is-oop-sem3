namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Alerts;

public record ConnectionAlert(string Message = "You are not connected to any file system") : Alert;