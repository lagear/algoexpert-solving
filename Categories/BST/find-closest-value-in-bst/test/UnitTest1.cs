using Microsoft.VisualStudio.TestPlatform.TestHost;
using Program = find_closest_value_in_bst.Program;

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

        var expected = 13;
        var actual = Program.FindClosestValueInBst(root, 12);
        Assert.AreEqual(expected, actual);
    }
}
