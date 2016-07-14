namespace LawnMower
{
    public class Lawn : ILawn
    {
        public Lawn(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", X, Y);
        }
    }
}