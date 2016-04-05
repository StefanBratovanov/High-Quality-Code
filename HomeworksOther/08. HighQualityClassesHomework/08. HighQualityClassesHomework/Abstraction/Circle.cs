namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            private set
            {
                ValidateNumber(value,nameof(this.Radius));

                this.radius = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter;
            checked
            {
                perimeter = 2 * Math.PI * this.Radius;
            }

            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface;
            checked
            {
                surface = Math.PI * this.Radius * this.Radius;
            }

            return surface;
        }
    }
}
