namespace DistanceFromX0AndY0
{
    internal class DistanceFromZero
    {
        private double x1Input, y1Input;
        internal double distanceOut;
        internal double X1
        {
            get { return x1Input; }
            set { x1Input = value; }
        }
        internal double Y1
        {
            get { return y1Input; }
            set { y1Input = value; }
        }
        internal DistanceFromZero(double X1, double Y1)
        {
            this.X1 = X1;
            this.Y1 = Y1;
            distanceOut = Distance();
        }
        internal double Distance()
        {
            return Math.Pow(X1, 2) + Math.Pow(Y1, 2);
        }
        internal void Properties()
        {
            Console.WriteLine($"Точка має такі координати: ({X1}, {Y1})");
        }
    }
    internal class Circle : DistanceFromZero
    {
        private double radiusInput;
        private readonly double dRad;
        internal bool dotInCircle;
        internal double CircleRadius
        {
            get { return radiusInput; } 
            set { radiusInput = value; }
        }
        internal Circle(double CircleRadius, DistanceFromZero dfz) : base(dfz.X1, dfz.Y1) 
        {
            this.CircleRadius = CircleRadius;
            dRad = Distance();
            dotInCircle = CheckDotInCircle();
        }
        internal bool CheckDotInCircle()
        {
            if (dRad < CircleRadius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            double abscissa = 0;
            double ordinate = 0;
            double radius = 0;
            while (true)
            {
                try
                {
                    Console.Write("Введіть координату точки на осі X: ");
                    abscissa = double.Parse(Console.ReadLine());
                    if (abscissa is double){ break; }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено недопустиме значення" +
                    " координати точки. Спробуйте ще раз.");
                }
            }
            while (true)
            {
                try
                {
                    Console.Write("Введіть координату точки на осі Y: ");
                    ordinate = double.Parse(Console.ReadLine());
                    if (abscissa is double) { break; }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено недопустиме значення" +
                    " координати точки. Спробуйте ще раз.");
                }
            }
            DistanceFromZero inputCoordinates = new(abscissa, ordinate);
            EvalPropsNDistance(inputCoordinates);
            while (true)
            {
                try
                {
                    Console.Write("Введіть довжину радіуса круга: ");
                    radius = double.Parse(Console.ReadLine());
                    if (radius >= 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введено недопустиме значення" +
                            " довжини радіуса. Спробуйте ще раз.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено недопустиме значення" +
                            " довжини радіуса. Спробуйте ще раз.");
                }
            }
            Circle inputRadius = new(radius, inputCoordinates);
            EvalDotInCircle(inputRadius);

        }
        static void EvalPropsNDistance(DistanceFromZero from_zero)
        {
            from_zero.Properties();
            double distance_output = from_zero.distanceOut;
            Console.WriteLine($"Відстань від початку координат до точки становить {distance_output}.");
        }
        static void EvalDotInCircle(Circle circle_check)
        {
            bool checkInCircle = circle_check.dotInCircle;
            switch (checkInCircle)
            {
                case true:
                    Console.WriteLine("Точка, координати якої введено раніше, лежить у крузі.");
                    break;
                case false:
                    Console.WriteLine("Точка, координати якої введено раніше, не лежить у крузі.");
                    break;
            }
        }
    }
     
}