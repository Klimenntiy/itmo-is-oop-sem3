using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;

public interface IPrototypeLabWork<T> where T : IPrototypeLabWork<T>
    {
        T CloneWork(
            T existingWork,
            string newName,
            User newCreator,
            string newDescription,
            string newEvaluationCriteria,
            ValueObjectNumberOfPoints.NumberOfPoints newNumberOfPoints);
    }
