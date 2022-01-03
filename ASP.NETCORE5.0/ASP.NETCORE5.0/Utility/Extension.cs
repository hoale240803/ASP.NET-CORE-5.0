using System.Collections.Generic;
using System.Linq;

namespace ASP.NETCORE5._0.Utility
{
    public static class Extension
    {
        /// <summary>
        /// Split the huge list
        /// </summary>
        public static List<List<T>> ChunkBy<T>(this IEnumerable<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}