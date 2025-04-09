using MathLogic;

namespace ClassAliases
{
    public static class Aliases
    {
        public static Vector3 Color(double red, double green, double blue) => new Vector3(red, green, blue);
        public static Vector3 Pixel(double x, double y, double z) => new Vector3(x, y, z);
    }
}