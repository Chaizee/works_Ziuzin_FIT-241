namespace Delegates
{

    public class Calculate
    {
        public int a;
        public int b;

        public Calculate(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public int Add()
        {
            return a + b;
        }

        public int Subtract()
        {
            return a - b;
        }

        public int Multiply()
        {
            return a * b;
        }

        public int Divide()
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Деление на ноль невозможно");
            }
            return a / b;
        }
    }

    public delegate int OperationDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            Calculate Obj1 = new Calculate(10, 5);

            OperationDelegate delegate1 = () =>
            {
                int FirstAction1 = Obj1.Add();

                int SecondAction1 = new Calculate(FirstAction1, Obj1.b).Multiply();

                int LastAction1 = new Calculate(SecondAction1, Obj1.b).Divide();

                return LastAction1;
            };

            int result1 = delegate1();

            Console.WriteLine($"Результат работы первого действия: {result1}");

            Calculate Obj2 = new Calculate(6, 2);

            OperationDelegate delegate2 = () =>
            {
                int FirstAction2 = Obj2.Divide();

                int SecondAction2 = new Calculate(FirstAction2, Obj2.b).Subtract();

                int LastAction2 = new Calculate(SecondAction2, Obj2.b).Multiply();

                return LastAction2;
            };

            int result2 = delegate2();
            Console.WriteLine($"Результат работы второго действия: {result2}");
        }
    }
}

