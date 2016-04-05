namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name)
            : base(name)
        {
        }

        public LocalCourse(string name, string teacherName)
            : base(name, teacherName)
        {
        }

        public LocalCourse(string name, string teacherName, IList<string> students)
            : base(name, teacherName, students)
        {
        }

        public LocalCourse(string name, string teacherName, IList<string> students, string lab)
            : base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get { return this.lab; }

            protected internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("lab", "Lab cannot be null, empty");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("LocalCourse { Name = ");
            result.Append(this.Name);
            result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }
            result.Append(" }");

            return result.ToString();
        }
    }
}
