using System;
using System.Linq;

namespace LawnMower
{
    public class Mower : IMower
    {
        public Mower(int x, int y, string c, ILawn lawn)
        {
            X = x > lawn.X || x < 1 ? 1 : x;
            Y = y > lawn.Y || y < 1 ? 1 : y;
            Heading = (Heading) Enum.Parse(typeof (Heading), c.ToUpper());
            Lawn = lawn;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Heading Heading { get; set; }
        public ILawn Lawn { get; set; }

        public string Mowe(string instructions)
        {
            var instructionList = instructions.Trim().ToUpper().ToCharArray().ToList();
            instructionList.ForEach(ProcessInstruction);
            return ToString();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", X, Y, Heading.ToString().Substring(0, 1));
        }

        private void ProcessInstruction(char c)
        {
            switch (c)
            {
                case 'L':
                    Heading = Heading == Heading.N ? Heading.W : Heading - 1;
                    break;
                case 'R':
                    Heading = Heading == Heading.W ? Heading.N : Heading + 1;
                    break;
                case 'M':
                    Move();
                    break;
            }
        }

        private void Move()
        {
            switch (Heading)
            {
                case Heading.N:
                    if (Y < Lawn.Y)
                        Y++;
                    break;
                case Heading.E:
                    if (X < Lawn.X)
                        X++;
                    break;
                case Heading.S:
                    if (Y > 1)
                        Y--;
                    break;
                case Heading.W:
                    if (X > 1)
                        X--;
                    break;
            }
        }
    }
}