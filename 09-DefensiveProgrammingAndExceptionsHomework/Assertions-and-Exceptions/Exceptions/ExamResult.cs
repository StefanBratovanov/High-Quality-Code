using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get { return this.grade; }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("grade", "The grade cannot be negative");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get { return this.minGrade; }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("min grade", "The minimunm grade cannot be negative");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get { return this.maxGrade; }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("max grade", "The maximum grade cannot be negative");
            }

            if (value <= this.minGrade)
            {
                throw new ArgumentException("max grade", "The max grade must be higher than the min grade");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get { return this.comments; }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("comments", "The comments cannot be empty");
            }

            this.comments = value;
        }
    }
}
