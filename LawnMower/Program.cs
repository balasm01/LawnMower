using System;
using Microsoft.Practices.Unity;

namespace LawnMower
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BeginMowing(GetLawnMower());
        }

        private static ILawnMower GetLawnMower()
        {
            var container = new UnityContainer();
            container.RegisterType<IValidationHelper, ValidationHelper>();
            container.RegisterType<IReader, Reader>();
            container.RegisterType<IInputHelper, InputHelper>();
            container.RegisterType<ILawnMower, LawnMower>();
            return container.Resolve<ILawnMower>();
        }

        private static void BeginMowing(ILawnMower lawnMower)
        {
            var lawn = lawnMower.GetLawnFromInput();
            var mowerInput = lawnMower.GetMowerInput();
            while (mowerInput.ToUpper() != "X")
            {
                var mower = lawnMower.CreateMower(mowerInput, lawn);
                var instructions = lawnMower.GetMowerInstructions();
                Console.WriteLine(mower.Mowe(instructions));
                mowerInput = lawnMower.GetMowerInput();
            }
        }
    }
}