using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_additional
{
    internal class Program
    {
        static void Main()
        {
            string[] data = Console.ReadLine().Split();
            int[] nums = new int[3];
            for (int i = 0; i < 3; i++)
            {
                nums[i] = int.Parse(data[i]);
            }
            Sort(nums, out int cnt);

            if (cnt == 2) Console.WriteLine(string.Join(" ", nums));
            else if (cnt == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == i) Console.Write(nums[2] + " ");
                        else Console.Write(nums[0] + " ");
                    }
                    Console.WriteLine();
                }
                //Console.WriteLine($"{nums[0]} {nums[0]} {nums[2]}");
                //Console.WriteLine($"{nums[0]} {nums[2]} {nums[0]}");
                //Console.WriteLine($"{nums[2]} {nums[0]} {nums[0]}");
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if(i != j && i != k && j != k)
                            Console.WriteLine($"{nums[i]} {nums[j]} {nums[k]}");
                        }
                    }
                }
            }
            Console.ReadLine();
        }
        static void Sort(int[] nums, out int cnt)
        {
            int n = nums.Length;
            cnt = 0;
            for (int i = 1; i < n; ++i)
            {
                int key = nums[i];
                int j = i - 1;
                while (j >= 0 && nums[j] > key)
                {
                    nums[j + 1] = nums[j];
                    j = j - 1;
                }
                nums[j + 1] = key;
            }
            for (int i = 1; i < n; i++)
                if (nums[i] == nums[i-1]) cnt++;
        }
    }
}
