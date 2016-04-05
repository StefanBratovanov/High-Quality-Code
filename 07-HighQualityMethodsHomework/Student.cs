namespace Methods
{
    using System;

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = this.GetDateFromStudentInfoProperty(this.OtherInfo);
            DateTime secondDate = this.GetDateFromStudentInfoProperty(other.OtherInfo);

            return firstDate < secondDate;

            //this.BirthDate = DateTime.Parse(birthDate, CultureInfo.CreateSpecificCulture("bg-BG"));
        }

        private DateTime GetDateFromStudentInfoProperty(string otherInfo)
        {
            const int stringDateLength = 10;
            var dateString = otherInfo.Substring(otherInfo.Length - stringDateLength);
            DateTime dateTime;

            if (DateTime.TryParse(dateString, out dateTime))
            {
                return dateTime;
            }

            throw new ArgumentException("date", "Invalid date format. Try mm/dd/YYYY");
        }
    }
}
