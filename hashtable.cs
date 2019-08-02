using System;

public class Node {
    public string key;
    public int value;
    public Node next;
    
    public Node(string key, int value) {
        this.key = key;
        this.value = value;
        this.next = null;
    }
}

public class HashTable {
    public int ts;
    public int cs;
    public Node[] arr;
    
    public HashTable() {
        this.cs = 0;
        this.ts = 4;
        this.arr = new Node[4];
    }
    
    public int hashFunc(string key) {
        int factor = 1;
        long sum = 0;
        for(int i=0;i<key.Length;i++) {
            char ch = key[i];
            sum = ((sum%this.ts) + ((factor%this.ts)*(((int)ch)%this.ts))%this.ts)%this.ts;
            factor = factor*37;
        }
        return (int)sum;
    }
    
    public void rehash() {
        int oldTableSize = this.ts;
        Node[] oldTable = this.arr;
        this.ts = this.ts*2;
        //Console.WriteLine("Rehash Done and size is "+this.ts);
        this.arr = new Node[this.ts];
        this.cs = 0;
        for(int i=0;i<oldTableSize;i++) {
            Node curr = oldTable[i];
            while(curr!=null) {
                this.insert(curr.key, curr.value);
                curr = curr.next;
            }
        }
    }
    
    public void display() {
        for(int i=0;i<this.ts;i++) {
            Node curr = this.arr[i];
            if(curr==null) {
                Console.WriteLine("Empty");
                continue;
            }
            while(curr!=null) {
                Console.Write(curr.key+","+curr.value+"->");
                curr = curr.next;
            }
            Console.WriteLine("\n");
        }
    }
    
    public void insert(string key, int value) {
        int idx = this.hashFunc(key);
        idx = (idx + this.ts)%this.ts;
        Node new_node = new Node(key, value);
        this.cs++;
        if(this.arr[idx] == null) {
            this.arr[idx] = new_node;
        } else {
            new_node.next = this.arr[idx];
            this.arr[idx] = new_node;
        }
        float loadFactor = ((float)this.cs)/this.ts;
        if(loadFactor > 0.5) {
            this.rehash();
        }
    }
    
    public bool search(string key) {
        int idx = this.hashFunc(key);
        idx = (idx + this.ts)%this.ts;
        Node curr = this.arr[idx];
        while(curr!=null) {
            if(curr.key == key) {
                return true;
            }
            curr = curr.next;
        }
        return false;
    }
    
    
}


public class Test
{
	public static void Main()
	{
        HashTable h = new HashTable();
        h.insert("abc", 97);
        h.insert("hgi", 6);
        h.insert("ab", 123);
        h.insert("rt", 98);
        h.insert("nag", 1);
        h.display();
        
	}
}
