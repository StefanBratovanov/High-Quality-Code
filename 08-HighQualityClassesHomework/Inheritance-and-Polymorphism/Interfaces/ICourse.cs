namespace InheritanceAndPolymorphism.Interfaces
{
    using System.Collections.Generic;

    interface ICourse
    {
        string Name { get; }

        string TeacherName { get; }

        IList<string> Students { get; }
    }
}
