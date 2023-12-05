using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC_2023
{
    public class Day5(string input) : GeneralDay(input)
    {
        public override long ComputeResultFirstPart()
        {
            string[] chunks = Input.Split("\n\n");
            long[] seeds = chunks[0].Split(": ")[1].Split(" ").Select(long.Parse).ToArray();

            long location = long.MaxValue;
            for (int i = 1; i < seeds.Length; i++)
            {
                long value = seeds[i];

                for (int j = 1; j < chunks.Length; j++)
                {
                    string[] mappingsValues = chunks[j].Split("\n");
                    value = GetMappedValue(mappingsValues , value);
                }

                if (value < location)
                    location = value;
            }

            return location;
        }

        public static long GetMappedValue(string[] listMap, long source)
        {
            long mappedValue = -1;

            for (int j = 1; j < listMap.Length; j++)
                {
                    long[] values = listMap[j].Split(" ").Select(long.Parse).ToArray();

                    if (source >= values[1] & source <= values[1] + values[2] - 1)
                    {
                        mappedValue = source - values[1] + values[0];
                        break;
                    } 
                }

            if (mappedValue == -1)
                mappedValue = source;

            return mappedValue;
        }

        public override long ComputeResultSecondPart()
        {
            string[] chunks = Input.Split("\n\n");
            long[] seeds = chunks[0].Split(": ")[1].Split(" ").Select(long.Parse).ToArray();

            long location = long.MaxValue;

            for (int i = 0; i < seeds.Length; i += 2)
            {
                long[] interval = GetMappedValuesRec(seeds[i], seeds[i] + seeds[i + 1] - 1, chunks);
                long value = interval.Min();

                if (value < location)
                    location = value;
            }

            return location;
        }

        public static long[] GetMappedValuesRec(long seedA, long seedB, string[] chunks)
        {
            long a = seedA;
            long b = seedB;

            for (int j = 1; j < chunks.Length; j++)
            {
                string[] mappingsValues = chunks[j].Split("\n");
                a = GetMappedValue(mappingsValues, a);
                b = GetMappedValue(mappingsValues, b);
            }

            if (seedB - seedA == 1)
                return [a, b];

            if ((b - a) == (seedB - seedA))
                return [a];

            long middle = (seedB - seedA) / 2;
            return [
                .. GetMappedValuesRec(seedA, seedA + middle, chunks), 
                .. GetMappedValuesRec(seedA + middle + 1, seedB, chunks)
            ];
        }
    }
}