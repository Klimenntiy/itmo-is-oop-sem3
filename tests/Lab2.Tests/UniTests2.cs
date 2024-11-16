using Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Programs;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;
using Xunit;

namespace Lab2.Tests;

public class UniTests2
{
    [Fact]
    public void ItsNotTheAuthorWhoWantsToChangeHisIdentity()
    {
        var id0 = new ValueObjectId.Id(1000);
        var id1 = new ValueObjectId.Id(1123);
        var id2 = new ValueObjectId.Id(2123);
        var id3 = new ValueObjectId.Id(3123);
        var id4 = new ValueObjectId.Id(1223);
        var id5 = new ValueObjectId.Id(1133);

        var points1 = new ValueObjectNumberOfPoints.NumberOfPoints(50);

        var semestr = new ValueObjectSemestr.Semestr(1);

        var user1 = new User("Genna", id1);

        var user2 = new User("Shreder", id0);

        var builderLabWork1 = new LaboratoryWorkBuilder();
        builderLabWork1.AddId(id2);
        builderLabWork1.AddName("Math1");
        builderLabWork1.AddDescription("fart a lot");
        builderLabWork1.AddCreator(user1);
        builderLabWork1.AddEvaluationCriteria("be cool");
        builderLabWork1.AddNumberOfPoints(points1);
        LaboratoryWork laboratoryWork1 = builderLabWork1.BuildLaboratoryWork();

        var builderLecMaterial1 = new LectureMaterialBuilder();
        builderLecMaterial1.AddId(id3);
        builderLecMaterial1.AddName("Math1_Lec");
        builderLecMaterial1.AddCreator(user1);
        builderLecMaterial1.AddDescription("fart a lot");
        builderLecMaterial1.AddContent("2 + 2 = 4");
        LectureMaterial lecMaterial1 = builderLecMaterial1.BuildLectureMaterial();

        var laboratoryWorks = new List<LaboratoryWork>();
        laboratoryWorks.Add(laboratoryWork1);
        var lecMaterials = new List<LectureMaterial>();
        lecMaterials.Add(lecMaterial1);
        var builderSubject1 = new SubjectBuilder();
        builderSubject1.AddId(id4);
        builderSubject1.AddName("Math");
        builderSubject1.AddCreator(user1);
        builderSubject1.AddLabWork(laboratoryWorks);
        builderSubject1.AddLectureMaterial(lecMaterials);
        builderSubject1.AddTypeOfCredit("examination");
        builderSubject1.AddPoints("60 - 3" +
                                  "74 - 4" +
                                  "85+ - 5");
        Subject subject1 = builderSubject1.Build();

        var subjects = new List<Subject>();
        subjects.Add(subject1);
        var builderProgram1 = new ProgramBuilder();
        builderProgram1.AddName("applied farting");
        builderProgram1.AddDirector(user1);
        builderProgram1.AddSemestr(semestr);
        builderProgram1.AddSubject(subjects);
        builderProgram1.AddId(id5);
        Program program1 = builderProgram1.Build();

        var subjectDirector = new SubjectDirector(builderSubject1);
        (Subject? Sub, FinalResult Res) newSub = subjectDirector.Modify(subject1, user2, "Matematika");
        FinalResult resSub = newSub.Res;
        Assert.True(resSub == new FinalResult.ItsNotTheAuthorWhoChangesTheEssence());

        var laboratoryWorkDirector = new LaboratoryWorkDirector(builderLabWork1);
        (LaboratoryWork? LabWork, FinalResult Res) newLab =
            laboratoryWorkDirector.Modify(laboratoryWork1, user2, "Matematika");
        FinalResult resLab = newLab.Res;
        Assert.True(resLab == new FinalResult.ItsNotTheAuthorWhoChangesTheEssence());

        var lectureMaterialDirector = new LectureMaterialDirector(builderLecMaterial1);
        (LectureMaterial? LecMaterial, FinalResult Res) newLec =
            lectureMaterialDirector.Modify(lecMaterial1, user2, "Matematika");
        FinalResult resLec = newLec.Res;
        Assert.True(resLec == new FinalResult.ItsNotTheAuthorWhoChangesTheEssence());
    }

    [Fact]
    public void IdOverwriteCheck()
    {
        var id0 = new ValueObjectId.Id(1000);
        var id1 = new ValueObjectId.Id(1123);
        var id2 = new ValueObjectId.Id(2123);
        var id3 = new ValueObjectId.Id(3123);
        var id4 = new ValueObjectId.Id(1223);
        var id5 = new ValueObjectId.Id(1133);

        var points1 = new ValueObjectNumberOfPoints.NumberOfPoints(100);

        var semestr = new ValueObjectSemestr.Semestr(1);

        var user1 = new User("Genna", id1);

        var user2 = new User("Shreder", id0);

        var builderLabWork1 = new LaboratoryWorkBuilder();
        builderLabWork1.AddId(id2);
        builderLabWork1.AddName("Math1");
        builderLabWork1.AddDescription("fart a lot");
        builderLabWork1.AddCreator(user1);
        builderLabWork1.AddEvaluationCriteria("be cool");
        builderLabWork1.AddNumberOfPoints(points1);
        LaboratoryWork laboratoryWork1 = builderLabWork1.BuildLaboratoryWork();

        var builderLecMaterial1 = new LectureMaterialBuilder();
        builderLecMaterial1.AddId(id3);
        builderLecMaterial1.AddName("Math1_Lec");
        builderLecMaterial1.AddCreator(user1);
        builderLecMaterial1.AddDescription("fart a lot");
        builderLecMaterial1.AddContent("2 + 2 = 4");
        LectureMaterial lecMaterial1 = builderLecMaterial1.BuildLectureMaterial();

        var laboratoryWorks = new List<LaboratoryWork>();
        laboratoryWorks.Add(laboratoryWork1);
        var lecMaterials = new List<LectureMaterial>();
        lecMaterials.Add(lecMaterial1);
        var builderSubject1 = new SubjectBuilder();
        builderSubject1.AddId(id4);
        builderSubject1.AddName("Math");
        builderSubject1.AddCreator(user1);
        builderSubject1.AddLabWork(laboratoryWorks);
        builderSubject1.AddLectureMaterial(lecMaterials);
        builderSubject1.AddTypeOfCredit("examination");
        builderSubject1.AddPoints("60 - 3" +
                                  "74 - 4" +
                                  "85+ - 5");
        Subject subject1 = builderSubject1.Build();

        var subjects = new List<Subject>();
        subjects.Add(subject1);
        var builderProgram1 = new ProgramBuilder();
        builderProgram1.AddName("applied farting");
        builderProgram1.AddDirector(user1);
        builderProgram1.AddSemestr(semestr);
        builderProgram1.AddSubject(subjects);
        builderProgram1.AddId(id5);
        Program program1 = builderProgram1.Build();

        Subject cloneSub = subject1.CloneSubject(subject1, "dis math", lecMaterials, laboratoryWorks, user1, "Zachet", "60+ - zachet");
        Assert.True(subject1.Id == cloneSub.Id);

        LaboratoryWork cloneLab = laboratoryWork1.CloneWork(laboratoryWork1, "Dis Math lab", user1, "not fart", "be cool", points1);
        Assert.True(laboratoryWork1.Id == cloneLab.Id);

        LectureMaterial cloneLec = lecMaterial1.CloneMaterial(lecMaterial1, "dis math lec", "not fart", "easy", user1);
        Assert.True(lecMaterial1.Id == cloneLec.Id);
    }

    [Fact]
    public void CheckingTheNumberOfPointsInTheSubject()
    {
        var id0 = new ValueObjectId.Id(1000);
        var id1 = new ValueObjectId.Id(1123);
        var id2 = new ValueObjectId.Id(2123);
        var id3 = new ValueObjectId.Id(3123);
        var id4 = new ValueObjectId.Id(1223);
        var id5 = new ValueObjectId.Id(1133);

        var points1 = new ValueObjectNumberOfPoints.NumberOfPoints(50);

        var semestr = new ValueObjectSemestr.Semestr(1);

        var user1 = new User("Genna", id1);

        var user2 = new User("Shreder", id0);

        var builderLabWork1 = new LaboratoryWorkBuilder();
        builderLabWork1.AddId(id2);
        builderLabWork1.AddName("Math1");
        builderLabWork1.AddDescription("fart a lot");
        builderLabWork1.AddCreator(user1);
        builderLabWork1.AddEvaluationCriteria("be cool");
        builderLabWork1.AddNumberOfPoints(points1);
        LaboratoryWork laboratoryWork1 = builderLabWork1.BuildLaboratoryWork();

        var builderLecMaterial1 = new LectureMaterialBuilder();
        builderLecMaterial1.AddId(id3);
        builderLecMaterial1.AddName("Math1_Lec");
        builderLecMaterial1.AddCreator(user1);
        builderLecMaterial1.AddDescription("fart a lot");
        builderLecMaterial1.AddContent("2 + 2 = 4");
        LectureMaterial lecMaterial1 = builderLecMaterial1.BuildLectureMaterial();

        var laboratoryWorks = new List<LaboratoryWork>();
        laboratoryWorks.Add(laboratoryWork1);
        var lecMaterials = new List<LectureMaterial>();
        lecMaterials.Add(lecMaterial1);
        var builderSubject1 = new SubjectBuilder();
        builderSubject1.AddId(id4);
        builderSubject1.AddName("Math");
        builderSubject1.AddCreator(user1);
        builderSubject1.AddLabWork(laboratoryWorks);
        builderSubject1.AddLectureMaterial(lecMaterials);
        builderSubject1.AddTypeOfCredit("examination");
        builderSubject1.AddPoints("60 - 3" +
                                  "74 - 4" +
                                  "85+ - 5");
        Subject subject1 = builderSubject1.Build();

        var subjects = new List<Subject>();
        subjects.Add(subject1);
        var builderProgram1 = new ProgramBuilder();
        builderProgram1.AddName("applied farting");
        builderProgram1.AddDirector(user1);
        builderProgram1.AddSemestr(semestr);
        builderProgram1.AddSubject(subjects);
        builderProgram1.AddId(id5);
        Program program1 = builderProgram1.Build();

        FinalResult res = Subject.CheckOfScore(laboratoryWorks);
        Assert.True(res == new FinalResult.SubjectScoresDoNotEqualAHundred());
    }
}