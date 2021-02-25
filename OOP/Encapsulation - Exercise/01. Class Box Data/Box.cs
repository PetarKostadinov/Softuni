using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
   public class Box
    {

        private const double MinimumSizeObject = 0;
        private const string InvalidSideMessage = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length  
        {
            get
            {
                return this.length;
            }
            private set
            {
                ValidateSide(value, nameof(this.Length));

                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
             }
            private set
            {
                ValidateSide(value, nameof(this.Width));

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
                ValidateSide(value, nameof(this.Height));

                this.height = value;
            }
        }

        public double CalculateSuRfaceArea()
        {
            double result = (2 * this.Length * this.Width) 
                          + (2 * this.Length * this.Height) 
                          + (2 * this.Width * this.Height);
            return result;
        }

        public double CalculateLateralSurface()
        {
            double result = (2 * this.Length * this.Height) 
                          + (2 * this.Width * this.Height );

            return result;
        }

        public double CalculateVolume()
        {
            double result = this.Length * this.Width * this.Height;

            return result;
        }

        private void ValidateSide(double value, string name)
        {
            if (value <= MinimumSizeObject)
            {
                throw new ArgumentException(string.Format(InvalidSideMessage, name));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {CalculateSuRfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {CalculateLateralSurface():f2}");
            sb.AppendLine($"Volume - {CalculateVolume():f2}");

            return sb.ToString().TrimEnd();
        }

    }
}
