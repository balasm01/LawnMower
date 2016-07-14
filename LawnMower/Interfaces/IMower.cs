namespace LawnMower
{
    public interface IMower
    {
        int X { get; set; }
        int Y { get; set; }
        Heading Heading { get; set; }
        ILawn Lawn { get; set; }
        string Mowe(string instructions);
        string ToString();
    }
}