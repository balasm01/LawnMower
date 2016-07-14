using System;

namespace LawnMower
{
    public class Reader : IReader
    {
        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}