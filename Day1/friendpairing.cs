using System;
namespace HelloWorld
{
    class Hello
    {
        static int friendPairing(int n) {
            // base case
            if(n==0 || n==1 || n==2) return n;
            return friendPairing(n-1) + (n-1)*friendPairing(n-2);
        }
        static void Main()
        {
            Console.WriteLine(friendPairing(4));
        }
    }
}
