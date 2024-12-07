namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Enams;

public class SubjectFormat
{
    public string Name { get; }

    public string Description { get; }

    public SubjectFormat(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static SubjectFormat Pass => new SubjectFormat("Pass", "Формат, при котором студент получает зачет.");

    public static SubjectFormat Exam => new SubjectFormat("Exam", "Формат, при котором студент сдает экзамен.");
}
