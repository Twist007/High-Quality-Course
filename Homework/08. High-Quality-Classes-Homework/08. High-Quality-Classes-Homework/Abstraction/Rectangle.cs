using System;

namespace Abstraction
{
    public class Rectangle : Figure
    {
        private double radius;

        public Rectangle()
            : base(0, 0)
        {
        }

        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value<=0)
                {
                throw new ArgumentOutOfRangeException(nameof(value),"Rectangle does not have Radius");
                }
                this.radius = value;
            }
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
