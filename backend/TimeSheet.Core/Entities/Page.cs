using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Core.Entities
{
    public class Page<T>
    {
        public int Count { get; }

        public IEnumerable<T> Items { get; }

        public Page(int count,IEnumerable<T> items)
        {
            Count = count;
            Items = items;
        }
    }
}
