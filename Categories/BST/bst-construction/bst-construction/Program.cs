namespace bst_construction;
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
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

        public BST Insert(int value)
        {
            // Write your code here.
            BST current = this;
            if (current.value == value)
                return this;
            BST lastNode = current;
            while (current != null)
            {
                lastNode = current;

                if (value < current.value)
                {
                    current = current.left;
                }
                else if (value > current.value)
                {
                    current = current.right;
                }
                else if ((value == current.value))
                {
                    current = null;
                }
            }

            BST temp;
            BST newNode = new BST(value);
            if (value < lastNode.value)
            {
                temp = lastNode.left;
                if (temp == null)
                {
                    lastNode.left = newNode;
                }
                else
                {
                    newNode.left = temp;
                    lastNode.left = newNode;
                }
            }
            else if (value >= lastNode.value)
            {
                temp = lastNode.right;
                if (temp == null)
                {
                    lastNode.right = newNode;
                }
                else
                {
                    newNode.right = temp;
                    lastNode.right = newNode;
                }
            }
                // Do not edit the return statement of this method.
                return this;
        }

        public bool Contains(int value)
        {
            // Write your code here.
            BST current = this;
            if (current.value == value)
            { return true; }

            while (current != null)
            {
                if (current.value == value)
                { return true; }

                if (value < current.value)
                { current = current.left; }
                else if (value > current.value)
                { current = current.right; }
                else { return true; }
            }

            return false;
        }

        public BST Remove(int value)
        {
            // Write your code here.
            BST temp;
            BST current = this;
            if (current.value == value)
            {
                temp = current;
                //Current must to be removed
                if (current.left != null && current.right != null)
                {
                    var closeLeft = FindClosestValueInBst(current.left, value);
                    var closeRigth = FindClosestValueInBst(current.right, value);

                    if (Math.Abs(closeLeft.value - current.value) < Math.Abs(closeRigth.value - current.value) )
                    {
                        this.value = closeLeft.value;
                        if (closeLeft.left == null && closeLeft.right == null)
                        {
                            RemoveLeft(this.left, this.value, this.left);
                        }
                    }
                    else
                    {
                        this.value = closeRigth.value;
                        if (closeRigth.left == null && closeRigth.right == null)
                        {
                            RemoveLeft(this.right, this.value, this.right);
                        }
                    }
                }

                ///if (current.left
            }

            // Write your code here.
            BST parent = null;
            while (current != null)
            {
                if (value < current.value)
                {
                    parent = current;
                    current = current.left;
                }
                else if (value > current.value)
                {
                    parent = current;
                    current = current.right;
                }
                else {

                    if (current.left == null && current.right == null)
                    {
                        RemoveLeft(current, value, parent);
                        current = null;
                    }
                }
            }

            // Do not edit the return statement of this method.
            return this;
        }

        private void RemoveLeft(BST current, int value, BST parent = null)
        {
            while (current != null)
            {
                if (current.value == value)
                {
                    if (parent == null)
                    {
                        current = null;
                        return;
                    }
                    if (parent!= null && parent.left != null && parent.left.value == value)
                    {
                        parent.left = null;
                    } else if (parent != null && parent.right != null && parent.right.value == value)
                    {
                        parent.right = null;
                    }

                    return;
                }
                if (value < current.value)
                {
                    parent = current;

                    current = current.left;
                }
                else if (value > current.value)
                {
                    parent = current;

                    current = current.right;
                }
                else {
                    current = null;
                    return;
                }
            }
        }

        private BST FindClosestValueInBst(BST tree, int target)
        {
            int min = 00;
            BST current = null;
            BST closet = null;

            if (tree != null)
            {
                min = Math.Abs(target - tree.value);
                closet = tree;
                if (target < tree.value)
                {
                    current = tree.left;
                }
                else
                {
                    current = tree.right;
                }
            }

            while (current != null)
            {
                if (min > Math.Abs(target - current.value))
                {
                    min = Math.Abs(target - current.value);
                    closet = current;
                    if (min == 0)
                    {
                        return closet;
                    }
                }

                if (target < current.value)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }

            // Write your code here.
            return closet;
        }
    }
}

