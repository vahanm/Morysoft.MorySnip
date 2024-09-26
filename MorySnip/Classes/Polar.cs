using System;
using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;

namespace Morysoft.MorySnip.Classes;

public class Polar
{
    public float Radius { get; set; }

    public float Angle { get; set; }

    public static PointF Convert(Polar source) => new(Conversions.ToSingle(source.Radius * Math.Cos(source.Angle)), Conversions.ToSingle(source.Radius * Math.Sin(source.Angle)));

    public static Polar Convert(Point source) => Convert(new PointF(source.X, source.Y));

    public static Polar Convert(PointF source)
    {
        float angle;
        float radius;
        var x = source.X;
        var y = source.Y;

        if (x > 0 && y >= 0)
        {
            angle = Conversions.ToSingle(Math.Atan(y / x));
        }
        else if (x > 0 && y < 0)
        {
            angle = Conversions.ToSingle(Math.Atan(y / x) + 2 * Math.PI);
        }
        else if (x < 0)
        {
            angle = Conversions.ToSingle(Math.Atan(y / x) + Math.PI);
        }
        else if (x == 0 && y > 0)
        {
            angle = Conversions.ToSingle(Math.PI / 2);
        }
        else if (x == 0 && y < 0)
        {
            angle = Conversions.ToSingle(Math.PI * 3 / 2);
        }
        else if (x == 0 && y == 0)
        {
            angle = 0;
        }
        else
        {
            throw new Exception("The impossible is possible");
        }

        radius = Conversions.ToSingle(Math.Pow(Math.Pow(x, 2) + Math.Pow(y, 2), 0.5));

        return new Polar(angle, radius);
    }

    public static implicit operator Polar(Point Source) => Convert(Source);

    public static implicit operator Polar(PointF Source) => Convert(Source);

    public static implicit operator Point(Polar Source)
    {
        var result = Convert(Source);

        return new Point(Conversions.ToInteger(result.X), Conversions.ToInteger(result.Y));
    }

    public static implicit operator PointF(Polar Source) => Convert(Source);

    public static implicit operator Size(Polar Source)
    {
        var result = Convert(Source);

        return new Size(Conversions.ToInteger(result.X), Conversions.ToInteger(result.Y));
    }

    public static implicit operator SizeF(Polar Source)
    {
        var result = Convert(Source);

        return new SizeF(result.X, result.Y);
    }

    public static Polar operator +(Polar left, Polar right) => Add(left, right);

    public static Polar operator -(Polar left, Polar right) => Subtract(left, right);

    public Polar() { }

    public Polar(float angle, float radius)
    {
        this.Angle = angle;
        this.Radius = radius;
    }

    public static Polar Add(Polar left, Polar right) => (PointF)left + (SizeF)right;

    public static Polar Subtract(Polar left, Polar right) => (PointF)left - (SizeF)right;
}
