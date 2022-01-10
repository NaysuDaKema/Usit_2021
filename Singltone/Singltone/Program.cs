using System;

namespace Singleton
{
    public class Computer
    {
        static Computer comp;
        protected Computer()
        {
            Console.WriteLine("Windows 10");
        }
        public static Computer Instance()
        {
            if (comp == null)
                comp = new Computer();
            else
                Console.WriteLine("На одном компьютере можно запустить только одну операционную систему");
            return comp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Computer a = Computer.Instance();
            Computer b = Computer.Instance();
        }
    }
}