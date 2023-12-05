using System.Text.RegularExpressions;

namespace AoC_2023
{
    public class Day2(string input) : GeneralDay(input)
    {
        public override long ComputeResultFirstPart()
        {
            string[] inputArray = Input.Split('\n');
            ResultFirst = 0;

            string pattern = @"(\d+)\s{1}([a-z]+)";

            Dictionary<string, int> colorMappings = new()
            {
                { "red", 12 },
                { "green", 13 },
                { "blue", 14 }
            };

            for (int i = 0; i < inputArray.Length; i++)
            {
                bool isPossibleGame = true;
                foreach (Match match in Regex.Matches(inputArray[i], pattern).Cast<Match>())
                {
                    if (colorMappings[match.Groups[2].Value] < Convert.ToInt32(match.Groups[1].Value))
                    {
                        isPossibleGame = false;
                        break;
                    }
                }

                if (isPossibleGame)
                    ResultFirst = ResultFirst + i + 1;
            }

            return ResultFirst;
        }

        public override long ComputeResultSecondPart()
        {
            string[] inputArray = Input.Split('\n');
            ResultSecond = 0;

            string pattern = @"(\d+)\s{1}([a-z]+)";

            for (int i = 0; i < inputArray.Length; i++)
            {
                Dictionary<string, int> colorMappings = new Dictionary<string, int>()
                {
                    { "red", 0 },
                    { "green", 0 },
                    { "blue", 0 }
                };

                foreach (Match match in Regex.Matches(inputArray[i], pattern).Cast<Match>())
                {
                    if (colorMappings[match.Groups[2].Value] < Convert.ToInt32(match.Groups[1].Value))
                        colorMappings[match.Groups[2].Value] = Convert.ToInt32(match.Groups[1].Value);
                }

                int power = 1;
                foreach (KeyValuePair<string, int> kvp in colorMappings)
                    power *= kvp.Value;

                ResultSecond += power;
            }

            return ResultSecond;
        }
    }
}