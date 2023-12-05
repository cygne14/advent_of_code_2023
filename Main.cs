using AoC_2023;


class Program
{
    static void Main()
    {
        Day1 day1 = new(File.ReadAllText("input1"));
        Console.WriteLine($"Result1 is {day1.ComputeResultFirstPart()}, result2 is {day1.ComputeResultSecondPart()}.");

        Day2 day2 = new(File.ReadAllText("input2"));
        Console.WriteLine($"Result1 is {day2.ComputeResultFirstPart()}, result2 is {day2.ComputeResultSecondPart()}.");

        Day3 day3 = new(File.ReadAllText("input3"));
        Console.WriteLine($"Result1 is {day3.ComputeResultFirstPart()}, result2 is {day3.ComputeResultSecondPart()}.");

        Day4 day4 = new(File.ReadAllText("input4"));
        Console.WriteLine($"Result1 is {day4.ComputeResultFirstPart()}, result2 is {day4.ComputeResultSecondPart()}.");

        Day5 day5 = new(File.ReadAllText("input5"));
        Console.WriteLine($"Result1 is {day5.ComputeResultFirstPart()}, result2 is {day5.ComputeResultSecondPart()}.");
    }
}