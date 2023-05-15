using System.Net.Http.Headers;

namespace SmallestDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOne = new int[] { -1, 5, 10, 20, 28, 3 };
            int[] arrayTwo = new int[] { 26, 134, 135, 15, 17 };
            var result = SmallestDifference(arrayOne, arrayTwo);
        }

        public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
        {
            // Write your code here.
            int min = 0;
            int minOne = arrayOne[0];
            int minTwo = arrayTwo[0];
            List<Item> aMinusb = new List<Item>();
            for (int i = 0; i < arrayOne.Length; i++)
            {
                for (int j = 0; j < arrayTwo.Length; j++)
                {
                    aMinusb.Add(
                        new Item()
                        {
                            Difference = Math.Abs(arrayOne[i] - arrayTwo[j]),
                            OneValue = arrayOne[i],
                            TwoValue = arrayTwo[j]
                        }
                        );
                }
            }

            var orderred = aMinusb.OrderBy(x => x.Difference).ToList().FirstOrDefault();
            if (orderred != null)
            {
                return new int[] { orderred.OneValue, orderred.TwoValue };
            } else 
            {
                return new int[] { };
            };
        }

        class Item { 
            public int Difference { get; set; }
            public int OneValue { get; set; }   
            public int TwoValue { get; set; }
        }
    }
}