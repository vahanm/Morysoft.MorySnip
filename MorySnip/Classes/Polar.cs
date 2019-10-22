using System.Drawing;
using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Morysoft.MorySnip
{
    public class Polar
    {
        public float Radius { get; set; }

        public float Angle { get; set; }

        public static PointF Convert(Polar Source)
        {
            return new PointF(Conversions.ToSingle(Source.Radius * Math.Cos(Source.Angle)), Conversions.ToSingle(Source.Radius * Math.Sin(Source.Angle)));
        }

        public static Polar Convert(Point Source)
        {
            return Convert(new PointF(Source.X, Source.Y));
        }

        public static Polar Convert(PointF Source)
        {
            float Angle;
            float Radius;
            float X = Source.X;
            float Y = Source.Y;


            if (X > 0 & Y >= 0)
            {
                Angle = Conversions.ToSingle(Math.Atan(Y / X));
            }
            else if (X > 0 & Y < 0)
            {
                Angle = Conversions.ToSingle(Math.Atan(Y / X) + 2 * Math.PI);
            }
            else if (X < 0)
            {
                Angle = Conversions.ToSingle(Math.Atan(Y / X) + Math.PI);
            }
            else if (X == 0 & Y > 0)
            {
                Angle = Conversions.ToSingle(Math.PI / 2);
            }
            else if (X == 0 & Y < 0)
            {
                Angle = Conversions.ToSingle(Math.PI * 3 / 2);
            }
            else if (X == 0 & Y == 0)
            {
                Angle = 0;
            }
            else
            {
                throw new Exception("The impossible is possible");
            }

            Radius = Conversions.ToSingle(Math.Pow(Math.Pow(X, 2) + Math.Pow(Y, 2), 0.5));

            return new Polar(Angle, Radius);
        }

        public static implicit operator Polar(Point Source)
        {
            return Convert(Source);
        }

        public static implicit operator Polar(PointF Source)
        {
            return Convert(Source);
        }

        public static implicit operator Point(Polar Source)
        {
            var Result = Convert(Source);
            return new Point(Conversions.ToInteger(Result.X), Conversions.ToInteger(Result.Y));
        }

        public static implicit operator PointF(Polar Source)
        {
            return Convert(Source);
        }

        public static implicit operator Size(Polar Source)
        {
            var Result = Convert(Source);
            return new Size(Conversions.ToInteger(Result.X), Conversions.ToInteger(Result.Y));
        }

        public static implicit operator SizeF(Polar Source)
        {
            var Result = Convert(Source);
            return new SizeF(Result.X, Result.Y);
        }

        public static Polar operator -(Polar a, Polar b) => new Polar { Angle = a.Angle - b.Angle, Radius = a.Radius - b.Radius };

        public static Polar operator +(Polar a, Polar b) => new Polar { Angle = a.Angle + b.Angle, Radius = a.Radius + b.Radius };

        public Polar() { }

        public Polar(float angle, float radius)
        {
            this.Angle = angle;
            this.Radius = radius;
        }
    }
}
