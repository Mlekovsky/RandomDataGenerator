using System;
using System.Collections.Generic;
using System.Text;

namespace RandomDataGenerator
{
    public static class ExtensionMethods
    {
        public static T PopAt<T>(this List<T> list, int index)
        {
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }
    }
}
