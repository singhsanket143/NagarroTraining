using System;
using System.Collections.Generic;

public class Graph {
    public int v;
    public LinkedList<int>[] arr;
    
    public Graph(int v) {
        this.v = v;
        arr = new LinkedList<int>[this.v];
        for(int i=0;i<this.v;i++) {
            arr[i] = new LinkedList<int>();
        }
    }
    
    public void addEdge(int u, int v, bool bidir=true) {
        this.arr[u].AddLast(v);
        if(bidir == true) {
            this.arr[v].AddLast(u);
        }
    }
    
    public void display() {
        for(int i=0;i<this.v;i++) {
            Console.Write(i+": ");
            foreach(int el in this.arr[i]) {
                Console.Write(el+",");
            }
            Console.WriteLine();
        }
    }
    
    public void bfs(int src) {
        LinkedList<int> qu = new LinkedList<int>();
        bool[] visited = new bool[this.v];
        for(int i=0;i<this.v;i++) {
            visited[i] = false;
        }
        qu.AddLast(src);
        visited[src] = true;
        while(qu.Count!=0) {
            int curr = qu.First.Value;
            qu.RemoveFirst();
            Console.WriteLine(curr);
            
            foreach(int neighbour in this.arr[curr]) {
                if(visited[neighbour] == false) {
                    qu.AddLast(neighbour);
                    visited[neighbour] = true;
                }
                    
            }
        }
        
    }
    
    public void dfsHelper(int src, bool[] visited) {
        visited[src] = true;
        Console.WriteLine(src);
        foreach(int neighbour in this.arr[src]) {
            if(visited[neighbour]==false) {
                dfsHelper(neighbour, visited);
            }
        }
    }
    
    public int dfs() {
        int component = 0;
        bool[] visited = new bool[this.v];
        for(int i=0;i<this.v;i++) {
            if(visited[i]==false) {
                dfsHelper(i, visited);
                component++;
            }
        }
        return component;
    }
    
    public void topologicalSort() {
        int[] indegree = new int[this.v];
        LinkedList<int> qu = new LinkedList<int>();
        bool[] visited = new bool[this.v];
        
        for(int i=0;i<this.v;i++) {
            visited[i] = false;
        }
        for(int i=0;i<this.v;i++) {
            foreach(int el in this.arr[i]) {
                indegree[el]++;
            }
        }
        
        for(int i=0;i<this.v;i++) {
            if(indegree[i] == 0) {
                qu.AddLast(i);
                visited[i] = true;
            }
        }
        while(qu.Count!=0) {
            int curr = qu.First.Value;
            qu.RemoveFirst();
            Console.WriteLine(curr);
            
            foreach(int neighbour in this.arr[curr]) {
                if(visited[neighbour] == false) {
                    indegree[neighbour]--;
                    if(indegree[neighbour] == 0) {
                        qu.AddLast(neighbour);
                        visited[neighbour]= true;
                    }
                }
                    
            }
        }
        
    }
    
	public static void Main()
	{
		Graph g = new Graph(5);
		g.addEdge(0, 1, false);
		g.addEdge(1, 3, false);
		g.addEdge(1, 2, false);
		g.addEdge(2, 3, false);
		g.addEdge(0, 2, false);
		g.addEdge(2, 4, false);
		
// // 		g.bfs(0);
//         int component = g.dfs();
//         Console.WriteLine("No of connected component are "+component);
    g.topologicalSort();
		
	}
}
