using System;

public class Test
{
    static int lbs(int[] arr, int n) {
        int[] lis1 = new int[n];
        int[] lis2 = new int[n];
        for(int i=0;i<n;i++) {
            lis1[i] = 1;
            lis2[i] = 1;
        }
        
        for(int i=1;i<n;i++) {
            for(int j=0;j<i;j++) {
                if(arr[j] < arr[i]) {
                    lis1[i] = Math.Max(lis1[i], 1+lis1[j]);
                }
            }
        }
        
        for(int i=n-2;i>=0;i--) {
            for(int j=i+1;j<n;j++) {
                if(arr[j] < arr[i]) {
                    lis2[i] = Math.Max(lis2[i], 1+lis2[j]);
                }
            }
        }
        
        for(int i=0;i<n;i++) {
            lis2[i] = lis2[i] + lis1[i] - 1;
        }
        int result = 1;
        for(int i=0;i<n;i++) {
            result = Math.Max(result, lis2[i]);
        }
        return result;
    }
    
	public static void Main()
	{
		int n = 9;
		int[] arr = {-3,2,1,4,2,9,8,10,5};
		int result = lbs(arr, n);
		Console.WriteLine(result);
	}
}
