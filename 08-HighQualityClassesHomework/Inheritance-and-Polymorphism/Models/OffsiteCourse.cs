namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name)
            : base(name)
        {
        }

        public OffsiteCourse(string name, string teacherName)
            : base(name, teacherName)
        {
        }

        public OffsiteCourse(string name, string teacherName, IList<string> students)
            : base(name, teacherName, students)
        {
        }

        public OffsiteCourse(string name, string teacherName, IList<string> students, string town)
            : base(name, teacherName, students)
        {
            this.Town = town;
        }

        public string Town
        {
            get { return this.town; }

            protected internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("town", "Town cannot be null, empty");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("OffsiteCourse { Name = ");
            result.Append(this.Name);
            result.Append(base.ToString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }
            result.Append(" }");

            return result.ToString();
        }
    }
}
