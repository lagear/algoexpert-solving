namespace find_closest_value_in_bst;
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public static int FindClosestValueInBst(BST tree, int target)
    {
        int min=0, closet=0;
        BST current=null;

        if (tree != null)
        {
            min = Math.Abs(target - tree.value);
            closet = tree.value;
            if (target < tree.value)
            {
                current = tree.left;
            }
            else
            {
                current = tree.right;
            }
        }

        bool finished = false;

        while (current != null)
        {
            if (min > Math.Abs(target - current.value))
            {
                min = Math.Abs(target - current.value);
                closet = current.value;
            }

            if (target < current.value)
            {
                current = current.left;
            }
            else
            {
                current = current.right;
            }

            /*if (current.left != null)
            {
                current = current.left;
            }
            else if (current.right != null)
            {
                current = current.right;
            }
            else
            {
                current = null;
            }
            */
        }

        // Write your code here.
        return closet;
    }

    public class BST
    {
        public int value;
        public BST left;
        public BST right;

        public BST(int value)
        {
            this.value = value;
        }
    }
}
