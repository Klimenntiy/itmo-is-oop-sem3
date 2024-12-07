using Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectSemestr;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Programs;

    public class ProgramBuilder
    {
        private Id? _id;
        private string? _name;
        private IReadOnlyCollection<Subject>? _subjects;
        private Semestr? _semestr;
        private User? _director;

        public ProgramBuilder AddId(Id id)
        {
            _id = id;
            return this;
        }

        public ProgramBuilder AddName(string name)
        {
            _name = name;
            return this;
        }

        public ProgramBuilder AddSubject(IReadOnlyCollection<Subject> subjects)
        {
            _subjects = subjects;
            return this;
        }

        public ProgramBuilder AddSemestr(Semestr semestr)
        {
            _semestr = semestr;
            return this;
        }

        public ProgramBuilder AddDirector(User director)
        {
            _director = director;
            return this;
        }

        public Program Build()
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                throw new InvalidOperationException("Name must be provided.");
            }

            if (_id == null)
            {
                throw new InvalidOperationException("ID must be provided.");
            }

            if (_subjects == null)
            {
                throw new InvalidOperationException("At least one subject must be provided.");
            }

            if (_semestr == null)
            {
                throw new InvalidOperationException("Semester must be greater than zero.");
            }

            if (_director == null)
            {
                throw new InvalidOperationException("Director must be provided.");
            }

            return new Program(_id, _name, _subjects, _semestr, _director);
        }
    }
