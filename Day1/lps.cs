using System;
namespace HelloWorld
{
    class Hello
    {
        static int lps(string str, int i, int j, int n) {
            if(n == 0) {
                return 0;
            }
            if(n == 1) {
                return 1;
            }
            if(str[i] == str[j]) {
                return 2 + lps(str, i+1, j-1, n-2);
            } else {
                return Math.Max(lps(str, i+1, j, n-1), lps(str, i, j-1, n-1));
            }
        }
        static void Main()
        {
            string str = "abaaacb";
            Console.WriteLine(lps(str, 0, str.Length-1, str.Length));
        }
    }
}
