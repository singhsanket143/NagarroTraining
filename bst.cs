using System;
using System.Collections;

public class Node {
    public int data;
    public Node left;
    public Node right;
}

public class Test
{
    
    public static Node insertInBst(Node root, int data) {
        if(root == null) {
            Node new_node = new Node();
            new_node.data = data;
            return new_node;
        }
        
        if(data < root.data) {
            root.left = insertInBst(root.left, data);
        } else {
            root.right = insertInBst(root.right, data);
        }
        
        return root;
    }
    
    public static void inOrder(Node root) {
        if(root == null) return;
        inOrder(root.left);
        Console.WriteLine(root.data);
        inOrder(root.right);
    }
    
    public static void preOrder(Node root) {
        if(root == null) return;
        Console.WriteLine(root.data);
        preOrder(root.left);
        preOrder(root.right);
    }
    
    public static bool search(Node root, int key) {
        if(root == null) {
            return false;
        }
        if(root.data == key) return true;
        if(key < root.data) {
            return search(root.left, key);
        } else {
            return search(root.right, key);
        }
    }
    
    public static Node delete(Node root, int data) {
        if(root == null) return root;
        if(data < root.data) {
            root.left = delete(root.left, data);
        } else if(data > root.data) {
            root.right = delete(root.right, data);
        } else {
            if(root.left==null && root.right == null) {
                root = null;
                return null;
            } else if(root.left == null) {
                Node temp = root.right;
                root = null;
                return temp;
            } else if(root.right == null) {
                Node temp = root.left;
                root = null;
                return temp;
            } else {
                Node temp = root.right;
                while(temp.left!=null) {
                    temp = temp.left;
                }
                root.data = temp.data;
                root.right = delete(root.right, temp.data);
                return root;
            }
        }
        return root;
    }
    
	public static void Main()
	{
		int n = Convert.ToInt32(Console.ReadLine());
		Node root = null;
		for(int i=0;i<n;i++) {
		    int x = Convert.ToInt32(Console.ReadLine());
		    root = insertInBst(root, x);
		}
// 		inOrder(root);
// 		Console.WriteLine("***");
// 		preOrder(root);
// 		Console.WriteLine(search(root, 62));
		root = delete(root, 100);
// 		inOrder(root);
		preOrder(root);
	}
}
