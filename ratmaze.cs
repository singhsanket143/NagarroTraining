using System;
namespace HelloWorld
{
    class Hello
    {
        static bool isSafe(int n, int x, int y, int[,] arr, bool[,] visited) {
            return x>=0 && y>=0 && x<n && y<n && arr[x,y] == 0 && visited[x,y]==false;
        }

        static int ratMaze(int n, int[,] arr, int x, int y, bool[,] visited) {
            if(x==n-1 && y==n-1) {
                return 1;
            }
            visited[x,y] = true;
            int result = 0;
            if(isSafe(n, x-1, y, arr, visited)) {
                result+=ratMaze(n,arr, x-1, y, visited);
            }
            if(isSafe(n, x, y-1, arr, visited)) {
                result+=ratMaze(n,arr, x, y-1, visited);
            }
            if(isSafe(n, x+1, y, arr, visited)) {
                result+=ratMaze(n,arr, x+1, y, visited);
            }
            if(isSafe(n, x, y+1, arr, visited)) {
                result+=ratMaze(n,arr, x, y+1, visited);
            }

            visited[x,y] = false;
            return result;
        }

        static void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] arr = new int[n, n];
            bool[,] visited = new bool[n, n];            
            for(int i=0;i<n;i++) {
                string[] temp = new string[n];
                temp = Console.ReadLine().Split();
                for(int j=0;j<n;j++) {
                    arr[i, j] = int.Parse(temp[j]);
                    visited[i,j] = false;
                }
            }
            
            Console.WriteLine(ratMaze(n,arr, 0, 0, visited));
        }
    }
}
