using System;
using System.Collections.Generic;
using System.Text;
using Timelogger.Entities;

namespace Timelogger.Extensions
{
    internal static class ListExtensions
    {
        /// <summary>
        /// Extension method to transform a list to DTO
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        internal static List<T> AsDTO<T>(this IEnumerable<BaseDocument<T>> items)
        {
            List<T> values = new List<T>();
            foreach(var item in items)
            {
                values.Add(item.AsDTO());
            }

            return values;
        }

    }
}
