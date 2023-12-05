using System.Text.RegularExpressions;

namespace AoC_2023
{
    public class Day3(string input) : GeneralDay(input)
    {
        public override long ComputeResultFirstPart()
        {
            string[] inputArray = Input.Split('\n');
            ResultFirst = 0;
            string pattern = @"(\d+)";

            for (int i = 0; i < inputArray.Length; i++)
            {

                foreach (Match match in Regex.Matches(inputArray[i], pattern).Cast<Match>())
                {
                    if (IsAdjacent(match.Index, match.Length, i, inputArray))
                        ResultFirst += Convert.ToInt32(match.Value);
                }
            }

            return ResultFirst;
        }

        public static bool IsAdjacent(int col, int len, int row, string[] inputMatrix)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                if (i < 0 || i > inputMatrix.Length - 1)
                    continue;

                for (int j = col - 1; j <= col + len; j++)
                {
                    if (j < 0 || j > inputMatrix[0].Length - 1)
                        continue;

                    if (!(inputMatrix[i][j].ToString() == "." || Char.IsDigit(inputMatrix[i][j])))
                        return true;
                }
            }

            return false;
        }

        public override long ComputeResultSecondPart()
        {
            string[] inputArray = Input.Split('\n');
            ResultSecond = 0;
            string pattern = @"(\d+)";

            Dictionary<Tuple<int, int>, Tuple<int, int>> numbers = [];

            for (int i = 0; i < inputArray.Length; i++)
            {

                foreach (Match match in Regex.Matches(inputArray[i], pattern).Cast<Match>())
                {
                    Tuple<int, int> coord = AdjacentStar(match.Index, match.Length, i, inputArray);

                    if (coord.Item1 > -1)
                    {
                        if (numbers.ContainsKey(coord))
                            numbers[coord] = Tuple.Create(
                                numbers[coord].Item1 * Convert.ToInt32(match.Value),
                                numbers[coord].Item2 + 1
                            );
                        else
                            numbers[coord] = Tuple.Create(Convert.ToInt32(match.Value), 1);
                    }    
                }
            }

            foreach (var pair in numbers)
            {
                if (pair.Value.Item2 == 2)
                    ResultSecond += pair.Value.Item1;
            }

            return ResultSecond;
        }

        public static Tuple<int, int> AdjacentStar(int col, int len, int row, string[] inputMatrix)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                if (i < 0 || i > inputMatrix.Length - 1)
                    continue;

                for (int j = col - 1; j <= col + len; j++)
                {
                    if (j < 0 || j > inputMatrix[0].Length - 1)
                        continue;

                    if (inputMatrix[i][j].ToString() == "*")
                        return Tuple.Create(i, j);
                }
            }

            return Tuple.Create(-1, -1);
        }
    }
}