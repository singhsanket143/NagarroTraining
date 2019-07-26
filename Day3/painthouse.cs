using System;

public class Test
{
    static int minIdx(int[,] dp, int row, int k) {
        int retval = int.MaxValue;
        int idx = -1;
        for(int i=0;i<k;i++) {
            if(dp[row,i] < retval) {
                retval = dp[row,i];
                idx = i;
            }
        }
        return idx;
    }
    static int secondminIdx(int[,] dp, int row, int k, int minIdx) {
        int retval = int.MaxValue;
        int idx = -1;
        for(int i=0;i<k;i++) {
            if(i!=minIdx && dp[row,i] < retval) {
                retval = dp[row,i];
                idx = i;
            }
        }
        return idx;
    }
    static int paintHouse(int[,] cost, int n, int k) {
        int[,] dp = new int[n,k];
        for(int i=0;i<k;i++) {
            dp[0,i] = cost[0,i];
        }
        for(int i=1;i<n;i++) {
            int min_idx = minIdx(dp, i-1, k);
            int second_min_idx = secondminIdx(dp, i-1, k, min_idx);
            for(int j=0;j<k;j++) {
                if(j==min_idx) {
                    dp[i,j] = cost[i,j] + dp[i-1,second_min_idx];
                } else {
                    dp[i,j] = cost[i,j] + dp[i-1,min_idx];
                }
            }
        }
        int result = int.MaxValue;
        for(int i=0;i<k;i++) {
            result = Math.Min(result, dp[n-1,i]);
        }
        return result;
    }
    
	public static void Main()
	{
		int n = 3, k=3;
		int[,] arr = {{14,2,11},{11,14,5},{14,3,10}};
		
		int result = paintHouse(arr, n, k);
		Console.WriteLine(result);
	}
}
