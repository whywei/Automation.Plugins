using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Plugins.Share.Stocking.Util
{
    public static class ArrayExtension
    {
        public static T[][] ConvertToNewArray<T>(this T[] array, int count)
        {
            return array.ConvertToNewEnumerable(count).ToArray();
        }

        public static IEnumerable<T[]> ConvertToNewEnumerable<T>(this T[] array, int count)
        {
            int i = 0;
            T[] newArray = new T[count];             
            foreach (var item in array)
            {
                if (i <= newArray.Length)
                {
                    newArray[i] = item;
                    i++;
                }
                else
                {
                    yield return newArray;
                    newArray = new T[count]; 
                }                
            }
        }
    }
}
