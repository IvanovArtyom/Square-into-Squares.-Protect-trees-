using System.Collections.Generic;
using System.Linq;

public class Decompose
{
    public static void Main()
    {
        Decompose dc = new();
        // Test
        var t = dc.decompose(11);
        // ...should return "1 2 4 10"
    }

    public string? decompose(long n)
    {
        long remainder = 0;
        List<long> indexes = new() { n };

        while (true)
        {
            if (indexes.Count == 0)
                return null;

            long curInd = indexes[^1];
            indexes.Remove(indexes[^1]);
            remainder += curInd * curInd;

            for (long i = curInd - 1; i > 0; i--)
            {
                if (remainder - i * i >= 0)
                {
                    remainder -= i * i;
                    indexes.Add(i);

                    if (remainder == 0)
                        return string.Join(" ", indexes.OrderBy(i => i).Select(i => i.ToString()));
                }
            }
        }
    }
}