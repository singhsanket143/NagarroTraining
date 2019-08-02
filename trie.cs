using System;
using System.Collections;

public class Node {
    public char data;
    public bool isTerminal;
    public Node[] arr;
}

public class Test
{
    
    public static Node addWord(Node root, string word) {
        Node temp = root;
        for(int i=0;i<word.Length;i++) {
            int ch = word[i]-'a';
            if(temp.arr[ch]==null) {
                temp.arr[ch] = new Node();
                temp.arr[ch].data = word[i];
                temp.arr[ch].arr = new Node[26];
            } 
            
            temp = temp.arr[ch];
        }
        temp.isTerminal = true;
        return root;
    }
    
    public static bool search(Node root, string word) {
        Node temp = root;
        for(int i=0;i<word.Length;i++) {
            int ch = word[i]-'a';
            if(temp.arr[ch]==null) {
                return false;
            }
            temp = temp.arr[ch];
        }
        return temp.isTerminal;
    }
    
	public static void Main()
	{
		Node root = new Node();
		root.data = '\0';
		root.arr = new Node[26];
		root = addWord(root, "ape");
		root = addWord(root, "apple");
		root = addWord(root, "applet");
		root = addWord(root, "bag");
		root = addWord(root, "ace");
		root = addWord(root, "age");
		root = addWord(root, "appy");
		Console.WriteLine(search(root, "bag"));
	}
}
