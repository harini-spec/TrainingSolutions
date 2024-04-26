using ShoppingDALLibrary;
using ShoppingModelLibrary;
using static ShoppingModelLibrary.Customer;

namespace Shopping
{
    internal class Program
    {
        void PrintNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("By " + Thread.CurrentThread.Name + " " + i);
                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Thread t1 = new Thread(program.PrintNumbers);
            t1.Name = "You";
            Thread t2 = new Thread(program.PrintNumbers);
            t2.Name = "Me";
            t1.Start();
            t2.Start();
            Console.WriteLine("After the thread call");
        }
    }
}
