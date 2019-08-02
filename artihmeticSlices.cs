using System;

public class Test
{
    static int arithmeticSlices(int[] arr, int n) {
        int[] dp = new int[n];
        dp[0] = 0;
        dp[1] = 0;
        for(int i=2;i<n;i++) {
            if(arr[i]-arr[i-1] == arr[i-1]-arr[i-2]) {
                dp[i] = 1+dp[i-1];
            } else {
                dp[i] = 0;
            }
        }
        int result = 0;
        for(int i=0;i<n;i++) {
            result+=dp[i];
        }
        return result;
    }
    
	public static void Main()
	{
		int n = 10;
		int[] arr = {1,3,5,7,9,8,12,16,20,7};
		int result = arithmeticSlices(arr, n);
		Console.WriteLine(result);
	}
}
