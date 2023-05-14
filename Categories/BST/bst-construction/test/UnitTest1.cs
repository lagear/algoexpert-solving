using bst_construction;

namespace test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestCase1()
    {
        var root = new Program.BST(10);
        root.left = new Program.BST(5);
        root.left.left = new Program.BST(2);
        root.left.left.left = new Program.BST(1);
        root.left.right = new Program.BST(5);
        root.right = new Program.BST(15);
        root.right.left = new Program.BST(13);
        root.right.left.right = new Program.BST(14);
        root.right.right = new Program.BST(22);

        //Delete

        Assert.IsTrue(root.Contains(22) == true);
        Assert.IsTrue(root.Contains(12) == false);

        root.Insert(12);
        Assert.IsTrue(root.right.left.left.value == 12);

        root.Remove(10);
        Assert.IsTrue(root.Contains(10) == false);
        Assert.IsTrue(root.value == 12);

        Assert.IsTrue(root.Contains(15));
    }

    [Test]
    public void TestCase2()
    {
        var root = new Program.BST(10);
        root.Insert(5);
        root.Insert(15);
        root.Insert(2);
        root.Insert(5);
        root.Insert(13);
        root.Insert(22);
        root.Insert(1);
        root.Insert(14);

        Assert.IsTrue(root.Contains(22) == true);
        Assert.IsTrue(root.Contains(12) == false);

        root.Insert(12);
        Assert.IsTrue(root.right.left.left.value == 12);

        root.Remove(10);
        Assert.IsTrue(root.Contains(10) == false);
        Assert.IsTrue(root.value == 12);

        Assert.IsTrue(root.Contains(15));
    }

    [Test]
    public void TestCase4()
    {
        /*
         * {
    "arguments": [5],
    "method": "insert"
  },
  {
    "arguments": [15],
    "method": "insert"
  },
  {
    "arguments": [5],
    "method": "remove"
  },
  {
    "arguments": [15],
    "method": "remove"
  },
  {
    "arguments": [10],
    "method": "remove"
  }
         */
        var root = new Program.BST(10);
        root.Insert(5);
        root.Insert(15);
        root.Remove(5);
        root.Remove(15);
        root.Remove(10);


        Assert.IsTrue(root.Contains(22) == true);
        Assert.IsTrue(root.Contains(12) == false);

        root.Insert(12);
        Assert.IsTrue(root.right.left.left.value == 12);

        root.Remove(10);
        Assert.IsTrue(root.Contains(10) == false);
        Assert.IsTrue(root.value == 12);

        Assert.IsTrue(root.Contains(15));
    }
}
