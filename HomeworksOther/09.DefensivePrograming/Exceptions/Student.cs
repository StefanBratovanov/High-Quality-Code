using System;
using System.Linq;
using System.Collections.Generic;
using Exceptions_Homework.Exceptions;

public class Student
{
    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        if (firstName == null)
        {
            throw new ArgumentNullException("The first name of a student cannot be null");
        }

        if (lastName == null)
        {
            throw new ArgumentNullException("The last name of a student cannot be null");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IList<Exam> Exams { get; set; }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new NullExamsException("The exams cannot be null! They should not be missing");
        }

        if (this.Exams.Count == 0)
        {
            Console.WriteLine("The student has no exams!");
            return null;
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            throw new NullExamsException("The exams cannot be null! They should not be missing");
        }

        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Exams count cannot be zero");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
