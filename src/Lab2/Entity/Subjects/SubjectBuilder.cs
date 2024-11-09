using Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;

public class SubjectBuilder
{
        private string? _name;
        private Id? _id;
        private IReadOnlyCollection<LaboratoryWork>? _labWorks;
        private IReadOnlyCollection<LectureMaterial>? _lecMaterials;
        private User? _creator;
        private string? _typeOfCredit;
        private string? _points;

        public SubjectBuilder AddName(string name)
        {
            _name = name;
            return this;
        }

        public SubjectBuilder AddId(Id id)
        {
            _id = id;
            return this;
        }

        public SubjectBuilder AddLabWork(IReadOnlyCollection<LaboratoryWork> labWorks)
        {
            _labWorks = labWorks;
            return this;
        }

        public SubjectBuilder AddLectureMaterial(IReadOnlyCollection<LectureMaterial> lecMaterials)
        {
            _lecMaterials = lecMaterials;
            return this;
        }

        public SubjectBuilder AddCreator(User creator)
        {
            _creator = creator;
            return this;
        }

        public SubjectBuilder AddTypeOfCredit(string typeOfCredit)
        {
            _typeOfCredit = typeOfCredit;
            return this;
        }

        public SubjectBuilder AddPoints(string points)
        {
            _points = points;
            return this;
        }

        public Subject Build()
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                throw new InvalidOperationException("Name must be provided.");
            }

            if (_id == null)
            {
                throw new InvalidOperationException("ID must be provided.");
            }

            if (_labWorks == null)
            {
                throw new InvalidOperationException("At least one laboratory work must be provided.");
            }

            if (_lecMaterials == null)
            {
                throw new InvalidOperationException("At least one lecture material must be provided.");
            }

            if (_creator == null)
            {
                throw new InvalidOperationException("Creator must be provided.");
            }

            if (string.IsNullOrWhiteSpace(_typeOfCredit))
            {
                throw new InvalidOperationException("Type of credit must be provided.");
            }

            if (string.IsNullOrWhiteSpace(_points))
            {
                throw new InvalidOperationException("Points must be provided.");
            }

            return new Subject(_name, _id, _labWorks, _lecMaterials, _typeOfCredit, _points, _creator);
        }
    }