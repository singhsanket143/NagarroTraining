using System;
using System.Collections;
using System.Collections.Generic;
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
    
    public static void LevelOrder(Node root) {
        if(root == null) return;
        LinkedList<Node> qu = new LinkedList<Node>();
        qu.AddLast(root);
        while(qu.Count != 0) {
            Node to_be_removed = (Node)qu.First;
            qu.RemoveFirst();
            Console.WriteLine(to_be_removed.data);
            if(to_be_removed.left!=null) {
                qu.AddLast(to_be_removed.left);
            }
            if(to_be_removed.right!=null) {
                qu.AddLast(to_be_removed.right);
            }
        }
    }
    
	public static void Main()
	{
		Node root = BuildTree();
		LevelOrder(root);
		
	}
}
