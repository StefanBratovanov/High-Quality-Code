using Exceptions_Homework.Exceptions;
using System;

public class ExamResult : Exception
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new NegativeGradeException("The grade cannot be negative!");
        }

        if (minGrade < 0)
        {
            throw new NegativeGradeException("The minimal grade cannot be negative!");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("The maximal grade cannot be less than the minimal one!");
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException("The comments cannot be null or empty!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
