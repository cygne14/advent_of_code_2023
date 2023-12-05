namespace AoC_2023
{
    public class GeneralDay
    {
        public string Input;
        public long ResultFirst;
        public long ResultSecond;


        public GeneralDay(string input)
        {
            Input = input;
        }

        public virtual long ComputeResultFirstPart()
        {
            ResultFirst = 0;
            return ResultFirst;
        }

        public virtual long ComputeResultSecondPart()
        {
            ResultSecond = 0;
            return ResultSecond;
        }
    }
}