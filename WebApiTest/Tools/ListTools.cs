using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApiTest.Tools
{
    public static class ListTools
    {
        public static List<List<T>> SplitList<T>(this List<T> locations, int nSize = 30)
        {
            var list = new List<List<T>>();
            for (var i = 0; i < locations.Count; i += nSize)
            {
                list.Add(locations.GetRange(i, Math.Min(nSize, locations.Count - i)));
            }
            return list;
        }

        public static List<List<T>> SplitListDistinct<T>(this List<T> listItems, int nSize = 30)
        {
            var list = new List<List<T>>();
            var locations = listItems.Distinct().ToList();
            for (var i = 0; i < locations.Count; i += nSize)
            {
                list.Add(locations.GetRange(i, Math.Min(nSize, locations.Count - i)));
            }
            return list;
        }

        public static List<List<T>> SplitListForThread<T>(List<T> source, int nSize, bool orderBy)
        {
            var list = new List<List<T>>();
            if (nSize > 0)
            {
                for (var i = 0; i < source.Count; i += nSize)
                {
                    if (orderBy)
                    {
                        var batch = source.GetRange(i, Math.Min(nSize, source.Count - i)).OrderBy(x => x).ToList();
                        list.Add(batch);
                    }
                    else
                    {
                        var batch = source.GetRange(i, Math.Min(nSize, source.Count - i)).ToList();
                        list.Add(batch);
                    }
                }
            }
            else
            {
                list.Add(source);
            }
            return list;
        }
    }
}
