using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_additional_4
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.WriteLine("Введіть всі сторони:");
            string[] data1 = Console.ReadLine().Split();
            double[] legs = new double[data1.Length];
            for (int i = 0; i < data1.Length; i++) legs[i] = double.Parse(data1[i]);
            Sort(legs);

            for (int i = 0; i < legs.Length - 2; i++)
            {
                double a = legs[i], b = legs[i + 1], c = legs[i + 2];
                if (a < b + c)
                {
                    double p = (a + b + c) / 2;
                    double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                    Console.WriteLine($"Відрізки: {a} {b} {c}");
                    Console.WriteLine($"Площа трикутника: {area}");
                    Console.ReadLine();
                    return;
                }
            }
            Console.WriteLine("Жодного трикутника не існує");
            Console.ReadLine();
        }
        static void Sort(double[] nums)
        {
            int n = nums.Length;
            for (int i = 1; i < n; ++i)
            {
                double key = nums[i];
                int j = i - 1;
                while (j >= 0 && nums[j] < key)
                {
                    nums[j + 1] = nums[j];
                    j = j - 1;
                }
                nums[j + 1] = key;
            }
        }
    }
}
