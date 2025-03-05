using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.WriteLine("Введіть всі сторони:");
        string[] data1 = Console.ReadLine().Split();
        double[] legs = new double[data1.Length];
        for (int i = 0; i < data1.Length; i++) legs[i] = double.Parse(data1[i]);

        Console.WriteLine(Count(legs));
        Console.WriteLine(CountOptimized(legs));
        Console.ReadLine();
    }
    static int Count(double[] lengths)
    {
        int n = lengths.Length;

        int count = 0;

        for (int i = 0; i < n; i++)
            for (int j = i + 1; j < n; j++)
                for (int k = j + 1; k < n; k++)
                    if (lengths[i] + lengths[j] > lengths[k] &&
                        lengths[i] + lengths[k] > lengths[j] &&
                        lengths[j] + lengths[k] > lengths[i])
                        count++;
        return count;
    }
    static int CountOptimized(double[] lengths)
    {
        SortArray(lengths, 0, lengths.Length - 1);
        int n = lengths.Length;
        int count = 0;

        for (int i = 0; i < n - 2; i++)
        {
            for (int j = i + 1; j < n - 1; j++)
            {
                int k = j + 1;
                while (k < n && lengths[i] + lengths[j] > lengths[k]) k++;
                count += k - j - 1;
            }
        }
        return count;
    }
    private static void SortArray(double[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);
            SortArray(arr, left, pivot - 1);
            SortArray(arr, pivot, right);
        }
    }
    private static int Partition(double[] arr, int left, int right)
    {
        double pivot = arr[(left + right) / 2];
        while (left <= right)
        {
            while (arr[left] < pivot) left++;
            while (arr[right] > pivot) right--;

            if (left <= right)
            {
                double temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;

                left++;
                right--;
            }
        }
        return left;
    }
}
