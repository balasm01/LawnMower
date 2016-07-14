using System.Linq;

namespace LawnMower
{
    public class ValidationHelper : IValidationHelper
    {
        public bool IsValidLawnParam(string lawnParams)
        {
            int x = 0, y = 0;
            var paramList = lawnParams.Trim().Split(' ').ToList();
            if (paramList.Count != 2)
            {
                return false;
            }
            if (!int.TryParse(paramList[0], out x))
            {
                return false;
            }
            if (!int.TryParse(paramList[1], out y))
            {
                return false;
            }
            if (x <= 0 || y <= 0)
            {
                return false;
            }
            return true;
        }

        public bool IsValidMowerParam(string mowerParams)
        {
            int x = 0, y = 0;
            const string directions = "NEWS";
            var paramList = mowerParams.Trim().ToUpper().Split(' ').ToList();
            if (paramList.Count != 3)
            {
                return false;
            }
            if (!int.TryParse(paramList[0], out x))
            {
                return false;
            }
            if (!int.TryParse(paramList[1], out y))
            {
                return false;
            }
            if (x <= 0 || y <= 0)
            {
                return false;
            }
            if (!directions.Contains(paramList[2]) || paramList[2].Length > 1)
            {
                return false;
            }
            return true;
        }

        public bool IsValidMowerInstruction(string mowerInstructions)
        {
            const string instructions = "LRM";
            var paramList = mowerInstructions.Trim().ToUpper().ToCharArray().ToList();
            if (string.IsNullOrWhiteSpace(mowerInstructions))
            {
                return false;
            }
            if (string.IsNullOrEmpty(mowerInstructions))
            {
                return false;
            }
            if (paramList.Any(i => !instructions.Contains(i)))
            {
                return false;
            }
            return true;
        }
    }
}