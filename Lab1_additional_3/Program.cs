using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_additional_3
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.WriteLine("Введіть довжини прогалин:");
            string[] data1 = Console.ReadLine().Split();
            long[] gaps = new long[data1.Length];
            for (int i = 0; i < data1.Length; i++) gaps[i] = long.Parse(data1[i]);
            Sort(gaps);
            Console.WriteLine("Введіть довжини мостів:");
            string[] data2 = Console.ReadLine().Split();
            long[] bridges = new long[data2.Length];
            for (int i = 0; i < data2.Length; i++) bridges[i] = long.Parse(data2[i]);
            Sort(bridges);

            int j = 0;
            for (int i = 0; i < bridges.Length && j < gaps.Length; i++)
            {
                if (bridges[i] > gaps[j]) j++;
            }
            Console.WriteLine("Кількість перекритих прогалин = " + j);
            Console.ReadLine();
        }
        static void Sort(long[] nums)
        {
            int n = nums.Length;
            for (int i = 1; i < n; ++i)
            {
                long key = nums[i];
                int j = i - 1;
                while (j >= 0 && nums[j] > key)
                {
                    nums[j + 1] = nums[j];
                    j = j - 1;
                }
                nums[j + 1] = key;
            }
        }
    }
}
