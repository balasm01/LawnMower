namespace LawnMower
{
    public interface IInputHelper
    {
        IValidationHelper ValidationHelper { get; set; }
        IReader Reader { get; set; }
        string ReadLawnInput();
        string ReadMowerInput();
        string ReadMowerInstructions();
    }
}