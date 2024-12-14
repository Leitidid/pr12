

namespace liba12
{
    public static class Calculations
    {
        public static double CalculateVolume(double a, double b, double c)
        {
            return a * b * c;
        }

        public static double CalculateSurfaceArea(double a, double b, double c)
        {
            return 2 * (a * b + b * c + a * c);
        }

        public static int CalculateSumOfDigits(int number)
        {
            return (number / 10) + (number % 10);
        }

        public static int CalculateProductOfDigits(int number)
        {
            return (number / 10) * (number % 10);
        }

    }
}


