namespace LawnMower
{
    public interface ILawnMower
    {
        string GetMowerInput();
        string GetMowerInstructions();
        ILawn GetLawnFromInput();
        ILawn CreateLawn(string lawnInput);
        IMower CreateMower(string mowerInput, ILawn lawn);
    }
}