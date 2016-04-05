namespace Abstraction.Models
{
    using System;

    public abstract class Figure
    {
        private double width { get; set; }
        private double height { get; set; }

        protected Figure(double width = 0, double height = 0)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get { return this.width; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width cannot be negative!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height cannot be negative!");
                }

                this.height = value;
            }
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();
    }
}
