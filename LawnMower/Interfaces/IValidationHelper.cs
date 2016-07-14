namespace LawnMower
{
    public interface IValidationHelper
    {
        bool IsValidLawnParam(string lawnParams);
        bool IsValidMowerParam(string mowerParams);
        bool IsValidMowerInstruction(string mowerInstructions);
    }
}