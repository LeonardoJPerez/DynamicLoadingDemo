using System;

namespace DynamicLoadingDemo
{
    public interface IService
    {
        void Execute();
    }

    public class A : IService
    {
        public void Execute()
        {
            Console.WriteLine("Executing Class A");
        }
    }

    public class B : IService
    {
        public void Execute()
        {
            Console.WriteLine("Executing Class B");
        }
    }

    public class Program
    {
        public static IService GetNewService(string serviceName)
        {
            var type = Type.GetType(serviceName, true);
            var newInstance = Activator.CreateInstance(type);
            return newInstance as IService;
        }

        private static void Main(string[] args)
        {
            GetNewService("DynamicLoadingDemo.A").Execute();
            GetNewService("DynamicLoadingDemo.B").Execute();

            Console.ReadLine();
        }
    }
}