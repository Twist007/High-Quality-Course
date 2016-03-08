using System;

namespace Abstraction
{
    public class Circle : Figure
    {
        private double width;
        private double radius;
        private double height;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public sealed override double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Radius must be valid numbre.");
                }
                this.radius = value;
            }
        }

        public override double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Circle does not have Width ");
                }
                this.width = value;
            }
        }

        public override double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Circle does not have Height");
                }
                this.height=value;
            }
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
