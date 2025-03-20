using System;
using System.Collections.Generic;
using System.Linq;

namespace Stakeholder.Utils
{
    public static class ListExtensions
    {
        public static T RandomElement<T>(this List<T> list)
        {
            var rng = new Random((int)DateTime.UtcNow.Ticks);
            return list[rng.Next(list.Count)];
        }

        public static T RandomElement<T>(this List<T> list, double probability, List<T> otherList)
        {
            var rng = new Random((int)DateTime.UtcNow.Ticks);
            return rng.NextDouble() <= probability ? list[rng.Next(list.Count)] : otherList[rng.Next(otherList.Count)];
        }

        public static T RandomWeightedElement<T>(this List<T> list, List<int> distribution)
        {
            var rng = new Random((int)DateTime.UtcNow.Ticks);
            var total = distribution.Sum();
            var choice = rng.Next(total);
            for (int i = 0; i < distribution.Count; i++)
            {
                if (choice < distribution[i])
                {
                    return list[i];
                }
                choice -= distribution[i];
            }
            return list[0];
        }

        public static void Shuffle<T>(this List<T> list)
        {
            Random rng = new Random((int)DateTime.UtcNow.Ticks);
            int n = list.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = rng.Next(0, i + 1);  // Random index between 0 and i
                                             // Swap the elements at positions i and j
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}
