using System.Linq;

namespace AoC_2023
{
    public class Day4(string input) : GeneralDay(input)
    {
        public override long ComputeResultFirstPart()
        {
            string[] inputArray = Input.Split('\n');

            foreach (string line in inputArray)
            {
                string[] split = line.Split(':');
                string[] numbers = split[1].Split('|');

                string[] firstNums = numbers[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] secondNums = numbers[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                int power = -1;

                for (int i = 0; i < secondNums.Length; i++)
                {
                    if (firstNums.Contains(secondNums[i]))
                        power += 1;
                }

                if (power > -1)
                    ResultFirst += 1 << power;
            }

            return ResultFirst;
        }

        public override long ComputeResultSecondPart()
        {
            string[] inputArray = Input.Split('\n');
            int[] countArray = Enumerable.Repeat(1, inputArray.Length).ToArray();

            for (int j = 0; j < inputArray.Length; j++)
            {
                string[] split = inputArray[j].Split(':');
                string[] numbers = split[1].Split('|');

                string[] firstNums = numbers[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] secondNums = numbers[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int winCards = 0;

                for (int i = 0; i < secondNums.Length; i++)
                {
                    if (firstNums.Contains(secondNums[i]))
                        winCards += 1;
                }

                for (int i = 1; i <= winCards; i++)
                    countArray[j + i] += countArray[j];
            }

            foreach (int num in countArray)
                ResultSecond += num;

            return ResultSecond;
        }
    }
}