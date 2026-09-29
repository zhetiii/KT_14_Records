using System;

namespace KT_14_Records
{
    public record Vector3(double X, double Y, double Z)
    {
        public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);
    }
}