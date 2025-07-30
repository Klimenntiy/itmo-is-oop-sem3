namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Enams;

public class InfoPoints
{
    public string Exam { get; }

    public string Pass { get; }

    public InfoPoints(string exam, string pass)
    {
        Exam = exam;
        Pass = pass;
    }

    public static InfoPoints PassInfo => new InfoPoints("Pass", "60+ = pass");

    public static InfoPoints ExamInfo => new InfoPoints("Exam", "60+ = 3," + "74+ = 4," + "90+ = 5");
}