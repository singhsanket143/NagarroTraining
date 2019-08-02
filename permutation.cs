using System;
namespace HelloWorld
{
    class Hello
    {
        static void permutation(string str, string osf) {
            if(str.Length == 0) {
                Console.WriteLine(osf);
                return;
            }
            for(int i=0;i<str.Length;i++) {
                char ch = str[i];
                string ros = str.Substring(0, i) + str.Substring(i+1);
                permutation(ros, osf+ch);
            }
        }
        static void Main()
        {
            
        }
    }
}
