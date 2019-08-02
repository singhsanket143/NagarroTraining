using System;
namespace HelloWorld
{
    class Hello
    {
        static int minStepsToOne(int n) {
            if(n==1) return 0;
            if(n==2 || n==3) return 1;
            int div_by_3 = int.MaxValue;
            int div_by_2 = int.MaxValue;
            if(n%3==0) {
                div_by_3 = minStepsToOne(n/3);
            }
            if(n%2==0) {
                div_by_2 = minStepsToOne(n/2);
            }

            int sub_by_1 = minStepsToOne(n-1);
            return 1 + Math.Min(sub_by_1, Math.Min(div_by_2, div_by_3));
        }
        static void Main()
        {
            Console.WriteLine(minStepsToOne(19));
        }
    }
}
