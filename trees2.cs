using System;
using System.Collections;

public class Node {
    public int data;
    public Node left;
    public Node right;
}

public class Test
{
    public static Node BuildTree() {
        Node root = null;
        int data = Convert.ToInt32(Console.ReadLine());
        if(data == -1) {
            return null;
        } else {
            root = new Node();
            root.data = data;
        }
        root.left = BuildTree();
        root.right = BuildTree();
        return root;
    }
    
    public static void PreOrder(Node root) {
        if(root == null) {
            return;
        }
        Console.WriteLine(root.data);
        PreOrder(root.left);
        PreOrder(root.right);
    }
    
    public static void PostOrder(Node root) {
        if(root == null) {
            return;
        }
        
        PostOrder(root.left);
        PostOrder(root.right);
        Console.WriteLine(root.data);
    }
    
    public static void InOrder(Node root) {
        if(root == null) {
            return;
        }
        InOrder(root.left);
        Console.WriteLine(root.data);
        InOrder(root.right);
    }
    
    public static int maxPathRoot2Leaf(Node root) {
        if(root == null) {
            return int.MinValue;
        }
        
        if(root.left==null && root.right==null) {
            return root.data;
        }
        int ls = maxPathRoot2Leaf(root.left);
        int rs = maxPathRoot2Leaf(root.right);
        
        return Math.Max(ls, rs) + root.data;
        
    }
    
    public static int maxValue = int.MinValue;
    
    public static int maxPathLeaf2Leaf(Node root) {
        if(root == null) {
            return int.MinValue;
        }
        
        if(root.left==null && root.right==null) {
            return root.data;
        }
        int ls = maxPathLeaf2Leaf(root.left);
        int rs = maxPathLeaf2Leaf(root.right);
        int cand = ls+rs+root.data;
        if(cand > maxValue) {
            maxValue = cand;
        }
        return Math.Max(ls, rs) + root.data;
        
    }
    
    public static int maxValue2 = int.MinValue;
    
    public static int maxPathNode2Node(Node root) {
        if(root == null) {
            return 0;
        }
        
        
        int ls = maxPathNode2Node(root.left);
        int rs = maxPathNode2Node(root.right);
        int cand1 = root.data;
        int cand2 = ls + root.data;
        int cand3 = rs + root.data;
        int cand4 = ls+rs+root.data;
        
        maxValue2 = Math.Max(maxValue2, Math.Max(cand1, Math.Max(cand2, Math.Max(cand3, cand4))));
        
        
        return Math.Max(ls, Math.Max(rs, 0)) + root.data;
        
    }
    
	public static void Main()
	{
		Node root = BuildTree();
// 		PreOrder(root);
// 		Console.WriteLine(maxPathRoot2Leaf(root));
		maxPathNode2Node(root);
		Console.WriteLine(maxValue2);
	}
}
