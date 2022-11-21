namespace ConsoleSnake.ExtensionMethods
{
    using System.Numerics;

    public static class Vector2Extensions
    {
        public static int GetX(this Vector2 extension)
        {
            return (int)extension.X;
        }

        public static int GetY(this Vector2 extension)
        {
            return (int)extension.Y;
        }
    }
}