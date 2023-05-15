using System;
using System.Collections.Generic;

namespace MoveElementToEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var array = new List<int> { 2, 1, 2, 2, 2, 3, 4, 2 };
            var toMove = 2;
            var result = MoveElementToEnd(array, toMove);*/
            var array = new List<int> {3, 1, 2, 4, 5};
            var toMove = 3;
            var result = MoveElementToEnd(array, toMove);
        }

        public static List<int> MoveElementToEnd(List<int> array, int toMove)
        {
            // Write your code here.
            int lastIndex = array.Count - 1;
            int lastIndexToMove = lastIndex -1;
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] == toMove)
                {

                    while (array[lastIndex] == toMove)
                    {
                        lastIndexToMove = lastIndex;
                        lastIndex--;
                        if (lastIndex < 0)
                        {
                            return array;
                        }
                    }

                    if (lastIndexToMove > i)
                    {
                        int tmp = array[lastIndex];
                        array[lastIndex] = array[i];
                        array[i] = tmp;
                    }
                }
            }
            return array;
        }
    }
}
