namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using InheritanceAndPolymorphism.Interfaces;

    public abstract class Course : ICourse
    {
        private string name;
        private string teacherName;
        private IList<string> students = new List<string>();

        protected Course(string name)
        {
            this.Name = name;
        }

        protected Course(string name, string teacherName)
            : this(name)
        {
            this.TeacherName = teacherName;
        }

        protected Course(string name, string teacherName, IList<string> students)
            : this(name, teacherName)
        {
            this.Students = students;
        }

        public string Name
        {
            get { return this.name; }

            protected internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("course name", "Course name cannot be null, empty");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get { return this.teacherName; }

            protected internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("teacher name", "Teacher name cannot be null, empty");
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get { return this.students; }

            protected internal set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("students", "Students List cannot be null, empty");
                }

                this.students = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }

            return "{ " + string.Join(", ", this.Students) + " }";
        }
    }
}
