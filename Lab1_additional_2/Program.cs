using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_additional_2
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            string[] data1 = Console.ReadLine().Split();
            long[] box1 = new long[3];
            for (int i = 0; i < 3; i++) box1[i] = long.Parse(data1[i]);
            Sort(box1);
            string[] data2 = Console.ReadLine().Split();
            long[] box2 = new long[3];
            for (int i = 0; i < 3; i++) box2[i] = long.Parse(data2[i]);
            Sort(box2);

            bool[] flags = Processing(box1, box2);

            if (flags[0] == false) Console.WriteLine("Жодна з коробок не поміщається в іншу");
            else if (flags[1]) Console.WriteLine("Перша коробка поміщається у другу");
            else Console.WriteLine("Друга коробка поміщається у першу");
            Console.ReadLine();
        }
        static bool[] Processing(long[] size1, long[] size2)
        {
            long[] max_box = new long[3];
            long[] min_box = new long[3];
            bool first_box = true;
            bool flag = true;

            if (size1[0] * size1[1] * size1[2] < size2[0] * size2[1] * size2[2])
            {
                min_box = size1;
                max_box = size2;
            }
            else
            {
                max_box = size1;
                min_box = size2;
                first_box = false;
            }
            for (int i = 0; i < 3; i++)
            {
                if (min_box[i] >= max_box[i]) flag = false;
            }
            return new bool[] {flag, first_box};
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
