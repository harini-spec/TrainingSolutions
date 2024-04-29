using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
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
    public class MinimumDepthOfBinaryTree
    {
        int MinDepth = Int32.MaxValue;
        public static void Main()
        {
            int MinDepthOfTree = new MinimumDepthOfBinaryTree().CalculateMinimumDepthOfBinaryTree().Result;
            Console.WriteLine(MinDepthOfTree);
        }

        private async Task<int> CalculateMinimumDepthOfBinaryTree()
        {
            TreeNode root = await GetInput();
            int DepthCount = 0;
            if (root == null)
                return 0;
            else if (root.left == null && root.right == null)
                return 1;
            else TraverseTree(DepthCount, root);
            return MinDepth;
        }

        private async Task<TreeNode> TraverseTree(int DepthCount, TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            else
            {
                DepthCount++;
                TreeNode left = await TraverseTree(DepthCount, root.left);
                TreeNode right = await TraverseTree(DepthCount, root.right);
                if(left ==  null && right == null)
                    if (DepthCount < MinDepth && DepthCount != 1)
                        MinDepth = DepthCount;
            }
            return root;
        }

        private async Task<TreeNode> GetInput()
        {
            TreeNode node1 = new TreeNode(6, null, null);
            TreeNode node2 = new TreeNode(5, null, node1);
            TreeNode node3 = new TreeNode(4, null, node2);
            TreeNode node4 = new TreeNode(3, null, node3);
            TreeNode root = new TreeNode(2, null, node4);
            return root;
        }
    }
}
