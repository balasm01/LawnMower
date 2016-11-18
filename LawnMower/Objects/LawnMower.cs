using System.Linq;

namespace LawnMower
{
    public class LawnMower : ILawnMower
    {
        public LawnMower(IInputHelper inputHelper)
        {
            _inputHelper = inputHelper;
        }

        private readonly IInputHelper _inputHelper;

        public string GetMowerInput()
        {
            return _inputHelper.ReadMowerInput();
        }

        public string GetMowerInstructions()
        {
            return _inputHelper.ReadMowerInstructions();
        }

        public ILawn GetLawnFromInput()
        {
            return CreateLawn(_inputHelper.ReadLawnInput());
        }

        public ILawn CreateLawn(string lawnInput)
        {
            var lawnCoordinates = lawnInput.Trim().Split(' ').ToList();
            var lawn = new Lawn(int.Parse(lawnCoordinates[0]), int.Parse(lawnCoordinates[1]));
            return lawn;
        }

        public IMower CreateMower(string mowerInput, ILawn lawn)
        {
            var mowerDetails = mowerInput.Trim().Split(' ').ToList();
            var mower = new Mower(int.Parse(mowerDetails[0]), int.Parse(mowerDetails[1]), mowerDetails[2], lawn);
            return mower;
        }
    }
}