// See https://aka.ms/new-console-rootlate for more information
namespace LeetCodeTrees
{
    public class Program
    {
         public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
             }
        }

        public class Solution
        {
            public IList<int> InorderTraversal(TreeNode root)
            {
                IList<int> finalList = new List<int>();
                
                TreeNode left = root.left;
                Boolean flag = true;

                Stack<TreeNode> rightStack = new Stack<TreeNode>();
                Stack<TreeNode> leftStack = new Stack<TreeNode>();

                leftStack.Push(root);
                rightStack.Push(root.right);
                while (flag)
                {
                    while (left != null)
                    {
                        if (left.right != null)
                            rightStack.Push(left.right);
                        
                        leftStack.Push(left);
                        left = left.left;                        
                    }

                    Console.WriteLine($"{((leftStack.Count() > 0) ? leftStack.Peek().val : "Nothing")} | {(rightStack.Count() > 0 ? rightStack.Peek().val : "Nothing")} ");
                    finalList.Add(leftStack.Pop().val);
                    if (rightStack.Count > 0)
                    {
                        if (leftStack.Count > 0)
                            finalList.Add(leftStack.Pop().val );
                        left = rightStack.Pop();                        
                    }
                    else if (leftStack.Count > 0)
                    {
                        left = leftStack.Pop();
                        finalList.Add((int)left.val);
                    }
                    else
                        flag = false;
                }

                return finalList;
            }
        }


        public static void Main(string[] args)
        {
            TreeNode root = new TreeNode(0);
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);
            TreeNode node7 = new TreeNode(7);

            root.left = node1;
            root.right = node2;
            node1.left = node3;
            node1.right = node4;
            node2.left = node5;
            node2.right = node6;
            node6.right = node7;

            Solution questionRunner = new Solution();

            Console.WriteLine("-------INORDER TRAVERSAL----------");
            Console.WriteLine(String.Join(" ", questionRunner.InorderTraversal(root)));

        }
    }
}


