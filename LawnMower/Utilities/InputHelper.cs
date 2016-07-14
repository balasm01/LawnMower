using System;

namespace LawnMower
{
    public class InputHelper : IInputHelper
    {
        private const string LawnInputMessage = "Please enter valid non zero integers for the lawn in '5 5' format";
        private const string MowerInputMessage = "Please enter the Mower position or enter x to exit.eg '1 2 N'";
        private const string MowerInstructionMessage = "Please enter mowing instructions. Valid instructions are L R M";

        public InputHelper(IValidationHelper validationHelper, IReader reader)
        {
            ValidationHelper = validationHelper;
            Reader = reader;
        }

        public IValidationHelper ValidationHelper { get; set; }
        public IReader Reader { get; set; }

        public string ReadLawnInput()
        {
            Console.WriteLine(LawnInputMessage);
            var lawnInput = Reader.ReadInput();
            while (!ValidationHelper.IsValidLawnParam(lawnInput))
            {
                Console.WriteLine(LawnInputMessage);
                lawnInput = Reader.ReadInput();
            }
            return lawnInput;
        }

        public string ReadMowerInput()
        {
            Console.WriteLine(MowerInputMessage);
            var mowerInput = Reader.ReadInput();
            while (!ValidationHelper.IsValidMowerParam(mowerInput) && mowerInput != null &&
                   mowerInput.Trim().ToUpper() != "X")
            {
                Console.WriteLine(MowerInputMessage);
                mowerInput = Reader.ReadInput();
            }
            return mowerInput;
        }

        public string ReadMowerInstructions()
        {
            Console.WriteLine(MowerInstructionMessage);
            var instructions = Reader.ReadInput();
            while (!ValidationHelper.IsValidMowerInstruction(instructions))
            {
                Console.WriteLine(MowerInstructionMessage);
                instructions = Reader.ReadInput();
            }
            return instructions;
        }
    }
}