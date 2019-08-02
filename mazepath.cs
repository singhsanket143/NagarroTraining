using System;
namespace HelloWorld
{
    class Hello
    {
        static int countMazePath(int n, int m, int sr, int sc) {
            if(sr >= n || sc >= m) {
                return 0;
            }
            if(sr == n-1 && sc == m-1) {
                return 1;
            }
            int hresult = countMazePath(n, m, sr, sc+1);
            int vresult = countMazePath(n, m, sr+1, sc);
            return hresult+vresult;
        }

        static void printMazePath(int n, int m, int sr, int sc, string osf) {
            if(sr >= n || sc >= m) {
                return;
            }
            if(sr == n-1 && sc == m-1) {
                Console.WriteLine(osf);
                return;
            }
            printMazePath(n, m, sr, sc+1, osf+"H");
            printMazePath(n, m, sr+1, sc, osf+"V");
            return;
        }
        static void Main()
        {
            printMazePath(3,3,0,0, "");
        }
    }
}
