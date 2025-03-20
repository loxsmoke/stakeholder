using System;
using System.Threading;

namespace Stakeholder.Utils
{
    /// <summary>
    /// Some random rust crap that I had to emulate in c#.
    /// One standard library function doing two things gives superiority complex to the engineer.
    /// Ha! I can build my own superiority complex in a few lines.
    /// </summary>
    public static class Rng
    {
        public static int RandomRange(Range range) => RandomRange(range.Start.Value, range.End.Value);

        public static int RandomRange(int min, int max)
        {
            var rng = new Random((int)DateTime.UtcNow.Ticks);
            return rng.Next(min, max);
        }

        public static void RandomSleep(Range range)
        { 
            RandomSleep(range.Start.Value, range.End.Value);
        }

        public static void RandomSleep(int minMs, int maxMs)
        {
            var rng = new Random((int)DateTime.UtcNow.Ticks);
            Thread.Sleep(rng.Next(minMs, maxMs));
        }

        public static bool RandomTrue(double trueProbability)
        {
            var rng = new Random((int)DateTime.UtcNow.Ticks);
            return rng.NextDouble() <= trueProbability;
        }
    }
}
