using System;
namespace HelloWorld
{
    class Hello
    {
        static void subseq(string str, string osf) {
            if(str.Length == 0) {
                Console.WriteLine(osf);
                return;
            }
            char ch = str[0];
            string ros = str.Substring(1);
            subseq(ros, osf);
            subseq(ros, osf+ch);
            
        }
        static void Main()
        {
            // Console.WriteLine("Hello World!");
            subseq("abc", "");
        }
    }
}
