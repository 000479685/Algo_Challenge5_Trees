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
                
                TreeNode left = root;
                
                Stack<TreeNode> leftStack = new Stack<TreeNode>();                
                
                while (left != null || leftStack.Count > 0)
                {
                    while (left != null)
                    {   
                        leftStack.Push(left);
                        left = left.left;                        
                    }
                    
                left = leftStack.Peek().right;
                finalList.Add(leftStack.Pop().val);

                }

                return finalList;
            }


            public IList<int> PostorderTraversal(TreeNode root)
            {
                IList<int> finalList = new List<int>();
                TreeNode left = root;
                Stack<TreeNode> leftStack = new Stack<TreeNode>();

                TreeNode lastFound = null;

                while (left != null || leftStack.Count > 0)
                {
                    if (left != null)
                    {
                        leftStack.Push(left);
                        left = left.left;
                    }
                    else
                    {
                        TreeNode temp = leftStack.Peek();
                        if (temp.right != null && lastFound != temp.right)
                        {
                            left = temp.right;
                        }
                        else
                        {
                            leftStack.Pop();
                            finalList.Add(temp.val);                            
                            lastFound = temp;
                        }
                    }

                }


                return finalList;
            }


            public IList<int> PreorderTraversal(TreeNode root)
            {
                IList<int> finalList = new List<int>();

                TreeNode left = root;

                Stack<TreeNode> leftStack = new Stack<TreeNode>();

                while (left != null || leftStack.Count > 0)
                {
                    while (left != null)
                    {
                        finalList.Add(left.val);
                        leftStack.Push(left);
                        left = left.left;
                    }

                    left = leftStack.Peek().right;
                    leftStack.Pop();

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
            Console.WriteLine(String.Join(" ", questionRunner.InorderTraversal(node7)));


            Console.WriteLine("-------POSTORDER TRAVERSAL----------");
            Console.WriteLine(String.Join(" ", questionRunner.PostorderTraversal(root)));

            Console.WriteLine("-------PREORDER TRAVERSAL----------");
            Console.WriteLine(String.Join(" ", questionRunner.PreorderTraversal(root)));
        }
    }
}


