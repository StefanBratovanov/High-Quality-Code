namespace AirConditionerTestingSystem.Models
{
    using System;
    using Utilities;

    public class Command
    {
        public string Name { get; private set; }

        public string[] Parameters { get; private set; }

        public Command(string inputLine)
        {
            try
            {
                string[] inputLineParts = inputLine.Split(' ');
                this.Name = inputLineParts[0];

                this.Parameters = inputLineParts[1].Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            catch (Exception ex)
            {
                throw new InvalidOperationException(Constants.Invalidcommand, ex);
            }
        }
    }
}
