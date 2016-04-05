namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                ValidateNumber(value,nameof(this.Width));

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                ValidateNumber(value, nameof(this.Height));

                this.height = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter;
            checked
            {
                perimeter = 2 * (this.Width + this.Height);
            }

            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface;
            checked
            {
                surface = this.Width * this.Height;
            }

            return surface;
        }
    }
}
