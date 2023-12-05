using System.Text.RegularExpressions;

namespace AoC_2023
{
    public class Day1(string input) : GeneralDay(input)
    {
        public override long ComputeResultFirstPart()
        {
            ResultFirst = 0;

            string[] inputArray = Input.Split('\n');
            string pattern = @"\d";

            foreach (string line in inputArray)
            {
                Match m1 = Regex.Match(line, pattern);
                Match m2 = Regex.Match(line, pattern, RegexOptions.RightToLeft);

                int number = Convert.ToInt32(m1.Value + m2.Value);
                ResultFirst += number;
            }

            return ResultFirst;
        }

        public override long ComputeResultSecondPart()
        {
            ResultSecond = 0;

            string[] inputArray = Input.Split('\n');
            string pattern = @"\d";

            for (int i = 0; i < inputArray.Length; i++)
            {
                foreach (KeyValuePair<string, string> kvp in numberMappings)
                {
                    inputArray[i] = Regex.Replace(inputArray[i], kvp.Key, kvp.Key + kvp.Value + kvp.Key);
                }

                Match m1 = Regex.Match(inputArray[i], pattern);
                Match m2 = Regex.Match(inputArray[i], pattern, RegexOptions.RightToLeft);

                int number = Convert.ToInt32(m1.Value + m2.Value);
                ResultSecond += number;
            }

            return ResultSecond;
        }

        Dictionary<string, string> numberMappings = new()
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" }
        };
    }
}
