using System;

namespace ThreeNumberSum;
class Program
{
    static void Main(string[] args)
    {
        var array = new int[] { 12, 3, 1, 2, -6, 5, -8, 6 };
        int targetSum = 0;
        var result = ThreeNumberSum2(array, targetSum);

    }

    public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
    {
        // Write your code here.
        var result = new List<int[]>();
        Array.Sort(array);
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                for (int k = j + 1; k < array.Length; k++)
                {
                    if (array[i] + array[j] + array[k] == targetSum)
                    {
                        var sum = new int[] { array[i], array[j], array[k] };
                        Array.Sort(sum);
                        result.Add((sum));
                    }
                }
            }
        }

        return result;
    }

    public static List<int[]> ThreeNumberSum2(int[] array, int targetSum)
    {
        // Write your code here.
        var result = new List<int[]>();
        Array.Sort(array);
        int indexLeft = 0;
        int left = array[indexLeft];
        int indexRigth = array.Length - 1;
        int rigth = array[indexRigth];

        for (int i = 0; i < array.Length - 2; i++)
        {
            left = i + 1;
            rigth = array.Length - 1;
            while (left < rigth)
            {
                if (array[i] + array[left] + array[rigth] == targetSum)
                {
                    var sum = new int[] { array[i], array[left], array[rigth] };
                    Array.Sort(sum);
                    result.Add((sum));
                    rigth--;
                    left++;
                }
                else if (array[i] + array[left] + array[rigth] > targetSum)
                {
                    rigth--;
                } else if (array[i] + array[left] + array[rigth] < targetSum)
                {
                    left++;
                }
            }
              }

        return result;
    }
}

